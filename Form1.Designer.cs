namespace IssueTissue
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUrl = new TextBox();
            btnClean = new Button();
            splitContainer1 = new SplitContainer();
            txtIssue = new TextBox();
            label1 = new Label();
            btnCopy = new Button();
            txtOutput = new TextBox();
            label2 = new Label();
            chkMentionUser = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(12, 12);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(578, 23);
            txtUrl.TabIndex = 0;
            txtUrl.KeyPress += txtUrl_KeyPress;
            // 
            // btnClean
            // 
            btnClean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClean.Location = new Point(596, 11);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 1;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 41);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtIssue);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(chkMentionUser);
            splitContainer1.Panel2.Controls.Add(btnCopy);
            splitContainer1.Panel2.Controls.Add(txtOutput);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(659, 387);
            splitContainer1.SplitterDistance = 167;
            splitContainer1.TabIndex = 2;
            // 
            // txtIssue
            // 
            txtIssue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtIssue.Location = new Point(0, 18);
            txtIssue.Multiline = true;
            txtIssue.Name = "txtIssue";
            txtIssue.ReadOnly = true;
            txtIssue.ScrollBars = ScrollBars.Both;
            txtIssue.Size = new Size(659, 146);
            txtIssue.TabIndex = 1;
            txtIssue.WordWrap = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Issue Text";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.Location = new Point(584, 193);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 23);
            btnCopy.TabIndex = 3;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(0, 18);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(659, 169);
            txtOutput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 0;
            label2.Text = "Output";
            // 
            // chkMentionUser
            // 
            chkMentionUser.AutoSize = true;
            chkMentionUser.Checked = true;
            chkMentionUser.CheckState = CheckState.Checked;
            chkMentionUser.Location = new Point(0, 193);
            chkMentionUser.Name = "chkMentionUser";
            chkMentionUser.Size = new Size(125, 19);
            chkMentionUser.TabIndex = 4;
            chkMentionUser.Text = "@ Mention Author";
            chkMentionUser.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 440);
            Controls.Add(splitContainer1);
            Controls.Add(btnClean);
            Controls.Add(txtUrl);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A tissue for your issue";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Button btnClean;
        private SplitContainer splitContainer1;
        private Label label1;
        private TextBox txtIssue;
        private Button btnCopy;
        private TextBox txtOutput;
        private Label label2;
        private CheckBox chkMentionUser;
    }
}
