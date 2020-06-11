namespace HomeExamClientSocket
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
            this.serverIpLbl = new System.Windows.Forms.Label();
            this.serverPortLbl = new System.Windows.Forms.Label();
            this.serverIptxt = new System.Windows.Forms.TextBox();
            this.serverPortTxt = new System.Windows.Forms.TextBox();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.textToSend = new System.Windows.Forms.TextBox();
            this.sendToServerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverIpLbl
            // 
            this.serverIpLbl.AutoSize = true;
            this.serverIpLbl.Location = new System.Drawing.Point(53, 48);
            this.serverIpLbl.Name = "serverIpLbl";
            this.serverIpLbl.Size = new System.Drawing.Size(52, 15);
            this.serverIpLbl.TabIndex = 0;
            this.serverIpLbl.Text = "Server IP";
            // 
            // serverPortLbl
            // 
            this.serverPortLbl.AutoSize = true;
            this.serverPortLbl.Location = new System.Drawing.Point(53, 86);
            this.serverPortLbl.Name = "serverPortLbl";
            this.serverPortLbl.Size = new System.Drawing.Size(29, 15);
            this.serverPortLbl.TabIndex = 1;
            this.serverPortLbl.Text = "Port";
            // 
            // serverIptxt
            // 
            this.serverIptxt.Location = new System.Drawing.Point(137, 48);
            this.serverIptxt.Name = "serverIptxt";
            this.serverIptxt.Size = new System.Drawing.Size(311, 23);
            this.serverIptxt.TabIndex = 2;
            // 
            // serverPortTxt
            // 
            this.serverPortTxt.Location = new System.Drawing.Point(137, 86);
            this.serverPortTxt.Name = "serverPortTxt";
            this.serverPortTxt.Size = new System.Drawing.Size(311, 23);
            this.serverPortTxt.TabIndex = 3;
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.Location = new System.Drawing.Point(70, 232);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConnectToServer.Size = new System.Drawing.Size(378, 105);
            this.btnConnectToServer.TabIndex = 4;
            this.btnConnectToServer.Text = "ConnectToServer";
            this.btnConnectToServer.UseVisualStyleBackColor = true;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            // 
            // textToSend
            // 
            this.textToSend.Location = new System.Drawing.Point(553, 97);
            this.textToSend.Name = "textToSend";
            this.textToSend.Size = new System.Drawing.Size(214, 23);
            this.textToSend.TabIndex = 5;
            // 
            // sendToServerBtn
            // 
            this.sendToServerBtn.Location = new System.Drawing.Point(553, 179);
            this.sendToServerBtn.Name = "sendToServerBtn";
            this.sendToServerBtn.Size = new System.Drawing.Size(205, 40);
            this.sendToServerBtn.TabIndex = 6;
            this.sendToServerBtn.Text = "Send";
            this.sendToServerBtn.UseVisualStyleBackColor = true;
            this.sendToServerBtn.Click += new System.EventHandler(this.sendToServerBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendToServerBtn);
            this.Controls.Add(this.textToSend);
            this.Controls.Add(this.btnConnectToServer);
            this.Controls.Add(this.serverPortTxt);
            this.Controls.Add(this.serverIptxt);
            this.Controls.Add(this.serverPortLbl);
            this.Controls.Add(this.serverIpLbl);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverIpLbl;
        private System.Windows.Forms.Label serverPortLbl;
        private System.Windows.Forms.TextBox serverIptxt;
        private System.Windows.Forms.TextBox serverPortTxt;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.TextBox textToSend;
        private System.Windows.Forms.Button sendToServerBtn;
    }
}

