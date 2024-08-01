using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace CMDL
{
    public class StoredProcedureParameter
    {

        public StoredProcedureParameter()
        {
            this.Parameter = new MySqlParameter();
        }

        public StoredProcedureParameter(MySqlDbType dbType,
                                        ParameterDirection direction,
                                        string parameterName, 
                                        object value)
        {
            this.Parameter = new MySqlParameter();
            this.ParameterName = parameterName;
            this.DBType = dbType;
            this.Direction = direction;
            this.Value = value;
        }

        private MySqlParameter _parameter;
        public MySqlParameter Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }

        public MySqlDbType DBType
        {
            get { return _parameter.MySqlDbType; }
            set { _parameter.MySqlDbType = value; }
        }

        public ParameterDirection Direction
        {
            get { return _parameter.Direction; }
            set { _parameter.Direction = value; }
        }

        public string ParameterName
        {
            get { return _parameter.ParameterName; }
            set { _parameter.ParameterName = value; }
        }

        public object Value
        {
            get { return _parameter.Value; }
            set { _parameter.Value = value; }

        }





    }
}
