using System.Text;
using System.Text.RegularExpressions;

namespace IssueTissue
{
    public partial class Form1 : Form
    {
        private Octokit.GitHubClient? _client;

        string template = """

            ### Type of issue

            Other (describe below)

            ### Description

            {description}

            ### Page URL

            {pageurl}

            ### Content source URL

            {contentsource}

            ### Document Version Independent Id

            {versionid}

            ### Article author

            {author}

            ### Metadata

            {metadata}

            """;


        public Form1()
        {
            InitializeComponent();

            txtUrl.GotFocus += TxtUrl_GotFocus;
        }

        private void TxtUrl_GotFocus(object? sender, EventArgs e)
        {
            txtUrl.SelectAll();
        }

        private async void btnClean_Click(object sender, EventArgs e)
        {
            btnCopy.Focus();
            btnClean.Enabled = false;
            txtOutput.Clear();

            // Parse URL to get issue info
            Match match = Regex.Match(txtUrl.Text.ToLower().Trim().Replace("\\", "/"), @".*\/(.*)\/(.*)\/issues\/(.*)");
            if (match.Groups.Count != 4)
            {
                MessageBox.Show("URL invalid, should be in format of 'https://github.com/{owner}/{repo}/issues/{issueID}'");
                btnClean.Enabled = true;
                return;
            }

            // Connect to GitHub
            _client ??= new Octokit.GitHubClient(new Octokit.ProductHeaderValue("IssueTissue", "1.0"));

            string owner;
            string repo;
            int issueId;

            try
            {
                owner = match.Groups[1].Value;
                repo = match.Groups[2].Value;
                issueId = int.Parse(match.Groups[3].Value);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Unable to parse URL correctly, possibly not a number at the end.");
                btnClean.Enabled = true;
                return;
            }

            // Get issue body
            Octokit.Issue issue;

            try
            {
                issue = await _client.Issue.Get(owner, repo, issueId);
            }
            catch (Exception)
            {
                MessageBox.Show("Octokit can't get to that issue. Is the URL valid?");
                btnClean.Enabled = true;
                return;
            }

            txtIssue.Text = issue.Body;
            string issueBodyTextOnly;

            match = Regex.Match(txtIssue.Text, "---\\r*\\n####.*");

            if (!match.Success)
            {
                MessageBox.Show("Unable to find metadata in issue body. Missing --- and #### headers.");
                btnClean.Enabled = true;
                return;
            }
            else
            {
                issueBodyTextOnly = txtIssue.Text.Substring(0, match.Index - 1);
            }

            // Find the content link in the issue body
            match = Regex.Match(txtIssue.Text, "\\* Content: \\[.*\\]\\((.*)\\)");
            if (!match.Success)
            {
                MessageBox.Show("Unable to find content link in issue body");
                btnClean.Enabled = true;
                return;
            }

            // Fetch content from URL
            string contentUrl = match.Groups[1].Value;
            using HttpClient webClient = new HttpClient();
            HttpResponseMessage response = await webClient.GetAsync(contentUrl);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Unable to fetch content from URL");
                btnClean.Enabled = true;
                return;
            }

            // Read content and parse link
            string content = await response.Content.ReadAsStringAsync();
            content = content.Replace("/><", "/>\n<");

            // Pull out metadata from HTML head
            MatchCollection metaMatches = Regex.Matches(content, @"<meta .+=""(.+)"" .*""(.*)"" */>");
            Dictionary<string, string> metadata = [];

            foreach (Match item in metaMatches)
                metadata[item.Groups[1].Value] = item.Groups[2].Value;

            if (metadata.Count == 0)
            {
                MessageBox.Show("Unable to find metadata in content");
                btnClean.Enabled = true;
                return;
            }

            // Check for required metadata fields
            bool isMissingMetadataUrl = !metadata.TryGetValue("og:url", out string metaFieldUrl);
            bool isMissingMetadataContentSource = !metadata.TryGetValue("original_content_git_url", out string metaFieldContentSource);
            bool isMissingMetadataVersion = !metadata.TryGetValue("document_version_independent_id", out string metaFieldVersion);
            bool isMissingMetadataAuthor = !metadata.TryGetValue("ms.author", out string metaFieldAuthor);
            bool isMissingMetadataDocId = !metadata.TryGetValue("document_id", out string metaFieldDocId);

            if (isMissingMetadataUrl
                || isMissingMetadataContentSource
                || isMissingMetadataVersion
                || isMissingMetadataAuthor
                || isMissingMetadataDocId)
            {
                MessageBox.Show($"""
                    Unable to find all metadata fields in content
                    isMissingMetadataUrl = {isMissingMetadataUrl}
                    isMissingMetadataContentSource = {isMissingMetadataContentSource}
                    isMissingMetadataVersion = {isMissingMetadataVersion}
                    isMissingMetadataAuthor = {isMissingMetadataAuthor}
                    isMissingMetadataDocId = {isMissingMetadataDocId}
                    """);
                btnClean.Enabled = true;
                return;
            }

            string mentionAuthor = chkMentionUser.Checked ? "@" : string.Empty;

            // Fill out the template
            string output = template
                .Replace("{pageurl}", metaFieldUrl)
                .Replace("{contentsource}", metaFieldContentSource)
                .Replace("{versionid}", metaFieldVersion)
                .Replace("{author}", $"{mentionAuthor}{metaFieldAuthor}");

            StringBuilder metadataStringBuilder = new();
            metadataStringBuilder.AppendLine($"* ID: {metadata["document_id"]}");
            if (metadata.ContainsKey("ms.service"))
                metadataStringBuilder.AppendLine($"* Service: **{metadata["ms.service"]}**");
            if (metadata.ContainsKey("ms.subservice"))
                metadataStringBuilder.AppendLine($"* Sub-service: **{metadata["ms.subservice"]}**");

            txtOutput.Text = output.Replace("{metadata}", metadataStringBuilder.ToString())
                                   .Replace("{description}", issueBodyTextOnly);

            btnClean.Enabled = true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
            MessageBox.Show("Copied!");
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnClean_Click(sender, e);
            }
        }
    }
}
