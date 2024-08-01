using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Models
{
    public partial class reg
    {
        private string status = "NOT DONE";

        public string Status
        {
            get { return status; }
            set 
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

    }
}
