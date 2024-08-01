using CMDL.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDL
{
    public static class Global
    {
        public static string GetInnerException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetInnerException(ex.InnerException);
        }
        public static string GetConnectionString()
        {
            return string.Format("server={0};User Id={1};password={2};database={3}",
                                Properties.Settings.Default.Server,
                                Properties.Settings.Default.UserID,
                                Properties.Settings.Default.Password,
                                Properties.Settings.Default.Database);
        }


        public static string AppVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }

            return "1.0.0.0";
        }
    }
}
