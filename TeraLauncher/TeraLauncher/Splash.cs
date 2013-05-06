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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            this.BackgroundImage = TeraLauncher.Properties.Resources.LogoSplash;
            this.TransparencyKey = Color.Black;
        }
    }
}
