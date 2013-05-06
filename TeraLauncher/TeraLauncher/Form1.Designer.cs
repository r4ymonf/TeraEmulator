namespace TeraLauncher
{
    partial class Form1
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
            this.lblFormName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pbNews = new System.Windows.Forms.PictureBox();
            this.lblWelcomeText = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.pnNotLogged = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblLoggedAs = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCoins = new System.Windows.Forms.Label();
            this.lblRegisterDate = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.lblLastIP = new System.Windows.Forms.Label();
            this.pnLoggedIn = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbNews)).BeginInit();
            this.pnNotLogged.SuspendLayout();
            this.pnLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.Location = new System.Drawing.Point(10, 12);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(85, 17);
            this.lblFormName.TabIndex = 0;
            this.lblFormName.Text = "TeraLauncher";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(786, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(759, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(25, 25);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pbNews
            // 
            this.pbNews.Location = new System.Drawing.Point(183, 104);
            this.pbNews.Name = "pbNews";
            this.pbNews.Size = new System.Drawing.Size(401, 273);
            this.pbNews.TabIndex = 3;
            this.pbNews.TabStop = false;
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.AutoSize = true;
            this.lblWelcomeText.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeText.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeText.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeText.Location = new System.Drawing.Point(182, 65);
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.Size = new System.Drawing.Size(64, 17);
            this.lblWelcomeText.TabIndex = 4;
            this.lblWelcomeText.Text = "Welcome,";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(9, 396);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(56, 17);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "Progress";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(12, 416);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(618, 10);
            this.pbDownload.TabIndex = 6;
            // 
            // pbTotal
            // 
            this.pbTotal.Location = new System.Drawing.Point(12, 432);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(618, 10);
            this.pbTotal.TabIndex = 7;
            // 
            // pnNotLogged
            // 
            this.pnNotLogged.BackColor = System.Drawing.Color.Transparent;
            this.pnNotLogged.Controls.Add(this.btnCreate);
            this.pnNotLogged.Controls.Add(this.btnLogin);
            this.pnNotLogged.Controls.Add(this.tbPassword);
            this.pnNotLogged.Controls.Add(this.lblPassword);
            this.pnNotLogged.Controls.Add(this.tbUsername);
            this.pnNotLogged.Controls.Add(this.lblUsername);
            this.pnNotLogged.Location = new System.Drawing.Point(589, 107);
            this.pnNotLogged.Name = "pnNotLogged";
            this.pnNotLogged.Size = new System.Drawing.Size(222, 158);
            this.pnNotLogged.TabIndex = 8;
            this.pnNotLogged.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(7, 112);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(70, 25);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(145, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(7, 74);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(208, 22);
            this.tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(4, 54);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(7, 25);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(208, 22);
            this.tbUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(4, 4);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(635, 403);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(171, 40);
            this.btnPlay.TabIndex = 10;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblLoggedAs
            // 
            this.lblLoggedAs.AutoSize = true;
            this.lblLoggedAs.BackColor = System.Drawing.Color.Transparent;
            this.lblLoggedAs.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedAs.ForeColor = System.Drawing.Color.White;
            this.lblLoggedAs.Location = new System.Drawing.Point(4, 4);
            this.lblLoggedAs.Name = "lblLoggedAs";
            this.lblLoggedAs.Size = new System.Drawing.Size(79, 17);
            this.lblLoggedAs.TabIndex = 0;
            this.lblLoggedAs.Text = "Logged In As";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(2, 132);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblCoins
            // 
            this.lblCoins.AutoSize = true;
            this.lblCoins.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoins.ForeColor = System.Drawing.Color.White;
            this.lblCoins.Location = new System.Drawing.Point(4, 29);
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(37, 17);
            this.lblCoins.TabIndex = 2;
            this.lblCoins.Text = "Coins";
            // 
            // lblRegisterDate
            // 
            this.lblRegisterDate.AutoSize = true;
            this.lblRegisterDate.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterDate.ForeColor = System.Drawing.Color.White;
            this.lblRegisterDate.Location = new System.Drawing.Point(4, 54);
            this.lblRegisterDate.Name = "lblRegisterDate";
            this.lblRegisterDate.Size = new System.Drawing.Size(88, 17);
            this.lblRegisterDate.TabIndex = 3;
            this.lblRegisterDate.Text = "Registered On";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLogin.ForeColor = System.Drawing.Color.White;
            this.lblLastLogin.Location = new System.Drawing.Point(4, 103);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(86, 17);
            this.lblLastLogin.TabIndex = 4;
            this.lblLastLogin.Text = "Last logged In";
            // 
            // lblLastIP
            // 
            this.lblLastIP.AutoSize = true;
            this.lblLastIP.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastIP.ForeColor = System.Drawing.Color.White;
            this.lblLastIP.Location = new System.Drawing.Point(4, 78);
            this.lblLastIP.Name = "lblLastIP";
            this.lblLastIP.Size = new System.Drawing.Size(45, 17);
            this.lblLastIP.TabIndex = 5;
            this.lblLastIP.Text = "Last IP";
            // 
            // pnLoggedIn
            // 
            this.pnLoggedIn.BackColor = System.Drawing.Color.Transparent;
            this.pnLoggedIn.Controls.Add(this.lblLastIP);
            this.pnLoggedIn.Controls.Add(this.lblLastLogin);
            this.pnLoggedIn.Controls.Add(this.lblRegisterDate);
            this.pnLoggedIn.Controls.Add(this.lblCoins);
            this.pnLoggedIn.Controls.Add(this.btnLogout);
            this.pnLoggedIn.Controls.Add(this.lblLoggedAs);
            this.pnLoggedIn.Location = new System.Drawing.Point(589, 107);
            this.pnLoggedIn.Name = "pnLoggedIn";
            this.pnLoggedIn.Size = new System.Drawing.Size(222, 158);
            this.pnLoggedIn.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::TeraLauncher.Properties.Resources.teraLauncherBG;
            this.ClientSize = new System.Drawing.Size(816, 454);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pnNotLogged);
            this.Controls.Add(this.pbTotal);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblWelcomeText);
            this.Controls.Add(this.pbNews);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.pnLoggedIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tera Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.pbNews)).EndInit();
            this.pnNotLogged.ResumeLayout(false);
            this.pnNotLogged.PerformLayout();
            this.pnLoggedIn.ResumeLayout(false);
            this.pnLoggedIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox pbNews;
        private System.Windows.Forms.Label lblWelcomeText;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.Panel pnNotLogged;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblLoggedAs;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.Label lblRegisterDate;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label lblLastIP;
        private System.Windows.Forms.Panel pnLoggedIn;
    }
}

