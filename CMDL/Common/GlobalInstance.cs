using CMDL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMDL.Common
{
    public class GlobalInstance
    {
        private static readonly GlobalInstance instance = new GlobalInstance();
        public UserAccess User
        {
            get;
            set;
        }


        static GlobalInstance()
        {

        }

        private GlobalInstance()
        {

        }

        public static GlobalInstance Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetUser(DataRow dr)
        {
            User = new UserAccess();
            User.UseXRay = dr.Field<string>("access_xray") == "1";
            User.UseNeuro = dr.Field<string>("access_neuro") == "1";
            User.UseLaboratory = dr.Field<string>("access_lab") == "1";
            User.CanPrint = dr.Field<string>("allow_print") == "1";
            User.CanRegister = dr.Field<string>("allow_register") == "1";
            User.IsAdmin = dr.Field<string>("isAdmin") == "1";
            User.UserName = dr.Field<string>("user_name");
            User.Password = dr.Field<string>("user_pwd");
        }
    }
}
