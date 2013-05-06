using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace TeraLauncher
{
    public partial class Form1 : Form
    {
        WebAPI webApi = new WebAPI();
        public Form1()
        {
            InitializeComponent();

            // CHange Text if Needed!
            lblFormName.Text = TeraLauncher.Properties.Resources.ApplicationName;

            // Login Button Setup!
            btnLogin.Click += new EventHandler(btnLogin_Click);

            // Default Hide
            pnLoggedIn.Visible = false;
            pnNotLogged.Visible = true;

            // Close / Minimize Buttons, Style CSS
            btnMinimize.Image = TeraLauncher.Properties.Resources.teraMinimizeNormal;
            btnMinimize.MouseEnter += new EventHandler(btnMinimize_Enter);
            btnMinimize.MouseLeave += new EventHandler(btnMinimize_Leave);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.BackColor = Color.FromArgb(0, 255, 255, 255);

            btnClose.Image = TeraLauncher.Properties.Resources.teraCloseNormal;
            btnClose.MouseEnter += new EventHandler(btnClose_Enter);
            btnClose.MouseLeave += new EventHandler(btnClose_Leave);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Login Button, Style CSS
            btnLogin.Image = TeraLauncher.Properties.Resources.teraLogin;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnLogin.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Create Button, Style CSS
            // Login Button, Style CSS
            btnCreate.Image = TeraLauncher.Properties.Resources.teraCreate;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnCreate.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnCreate.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnCreate.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Logout Button, Style CSS
            btnLogout.Image = TeraLauncher.Properties.Resources.teraLogout;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnLogout.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Play Button, Style CSS
            btnPlay.Image = TeraLauncher.Properties.Resources.teraPlayButtonGrey;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnPlay.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnPlay.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnPlay.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Progress Bars are Disabled
            lblProgress.Text = lblProgress.Text + " " + pbTotal.Value + "%";

            // Turn On Password mode!
            tbPassword.PasswordChar = '*';
            tbUsername.MaxLength = 15;
            tbPassword.MaxLength = 15;
        }

        private void btnMinimize_Enter(object sender, EventArgs e)
        {
            btnMinimize.Image = TeraLauncher.Properties.Resources.teraMinimizeHover;
        }

        private void btnMinimize_Leave(object sender, EventArgs e)
        {
            btnMinimize.Image = TeraLauncher.Properties.Resources.teraMinimizeNormal;
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            btnClose.Image = TeraLauncher.Properties.Resources.teraCloseHover;
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            btnClose.Image = TeraLauncher.Properties.Resources.teraCloseNormal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var url = webApi.webApiUrl;
            webApi.user = WebAPI._login_Callback<UserData>(url, tbUsername.Text, tbPassword.Text);
            if (!webApi.user.success)
            {
                MessageBox.Show(webApi.user.error);
            }
            else
            {
                // We are logged in!
                pnNotLogged.Visible = false;
                pnLoggedIn.Visible = true;
                btnPlay.Image = TeraLauncher.Properties.Resources.teraPlayButton;

                WebAPI.isLoggedIn = true;

                // Welcome Change!
                lblWelcomeText.Text = lblWelcomeText.Text + " " + webApi.user.username;
                lblLoggedAs.Text = lblLoggedAs.Text + " " + webApi.user.username;
                lblCoins.Text = lblCoins.Text + " : " + webApi.user.coins + " Coins";
                lblRegisterDate.Text = lblRegisterDate.Text + " : " + webApi.user.regdate;
                lblLastLogin.Text = lblLastLogin.Text + " : " + webApi.user.lastdate;
                lblLastIP.Text = lblLastIP.Text + " : " + webApi.user.lastip;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!WebAPI.isLoggedIn)
                MessageBox.Show("You must be logged in to play!");
            startTera();
        }

        private void startTera()
        {
            // Load Splash
            Splash sl = new Splash();
            sl.Show();
            this.Hide();
            Thread.Sleep(5000);
            sl.Close();
            this.Show();

            // Start Program
            string LaunchString = " 1 " + webApi.user.password + " 0 1 " + webApi.user.username + " en";
            ProcessStartInfo Tera = new ProcessStartInfo();
            Tera.FileName = "TERA-Launcher.exe";
            Tera.Arguments = LaunchString;
            Process.Start(Tera);

            // End
            Thread.Sleep(2000);
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            this.Hide();
            rg.Show();
        }
    }
}
