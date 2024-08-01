using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Models
{
    public class UserAccess
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseXRay { get; set; }
        public bool UseNeuro { get; set; }
        public bool UseLaboratory { get; set; }
        public bool CanPrint { get; set; }
        public bool CanRegister { get; set; }
        public bool IsAdmin { get; set; }
    }
}
