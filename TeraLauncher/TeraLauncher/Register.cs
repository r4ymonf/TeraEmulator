using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeraLauncher
{
    public partial class Register : Form
    {
        WebAPI webApi = new WebAPI();

        public Register()
        {
            InitializeComponent();

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

            // Register Button
            btnRegister.Image = TeraLauncher.Properties.Resources.teraRegisterBig;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnRegister.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Passwords
            tbPassword.PasswordChar = '*';
            tbRPassword.PasswordChar = '*';
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           webApi.user = WebAPI._register_Callback<UserData>(webApi.webApiUrl, tbUsername.Text, tbPassword.Text, 
               tbRPassword.Text, tbEmail.Text);

           if (!webApi.user.success)
           {
               MessageBox.Show(webApi.user.error);
           }
           else
           {
               MessageBox.Show("You have been registered " + tbUsername.Text + "!");
               Form1 frm = new Form1();
               frm.Show();
               this.Close();
           }
        }
    }
}
