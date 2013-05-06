using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeraLauncher
{
    public class UserData
    {
        public bool success { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public double coins { get; set; }
        public string error { get; set; }
        public string regdate { get; set; }
        public string lastdate { get; set; }
        public string lastip { get; set; }
    }
}
