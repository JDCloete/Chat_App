
namespace LoginTest_Firebase.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.lstMessagees = new System.Windows.Forms.ListBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.btnGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(1, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(137, 30);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "@_______";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Yu Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(213, 377);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(470, 51);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(700, 377);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 51);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstContacts
            // 
            this.lstContacts.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.ItemHeight = 29;
            this.lstContacts.Location = new System.Drawing.Point(13, 56);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(194, 381);
            this.lstContacts.TabIndex = 3;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            // 
            // lstMessagees
            // 
            this.lstMessagees.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.lstMessagees.FormattingEnabled = true;
            this.lstMessagees.ItemHeight = 29;
            this.lstMessagees.Location = new System.Drawing.Point(213, 9);
            this.lstMessagees.Name = "lstMessagees";
            this.lstMessagees.Size = new System.Drawing.Size(575, 352);
            this.lstMessagees.TabIndex = 4;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(794, 9);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.Size = new System.Drawing.Size(575, 352);
            this.rtbMessages.TabIndex = 5;
            this.rtbMessages.Text = "";
            // 
            // btnGroups
            // 
            this.btnGroups.Location = new System.Drawing.Point(794, 377);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(160, 51);
            this.btnGroups.TabIndex = 6;
            this.btnGroups.Text = "Group Management";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 450);
            this.Controls.Add(this.btnGroups);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.lstMessagees);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.ListBox lstMessagees;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Button btnGroups;
    }
}