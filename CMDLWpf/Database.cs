using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CMDLWpf
{
    public class Database
    {
        private DataSet _dSet;
        private DataRow[] _returnRow;
        private MySqlDataAdapter _dataAdapter;
        private MySqlCommandBuilder _commandBuilder;
        private MySqlCommand _command;
        private int _length;
        private string _tableName;

        public Database()
        {
            _dSet = new DataSet();
        }

        public void Select(string query, string table, MySqlDB db)
        {
            try
            {
                _tableName = table;

                _dSet.Clear();
                _dataAdapter = new MySqlDataAdapter(query, db.Connection);
                _commandBuilder = new MySqlCommandBuilder(_dataAdapter);

                _dataAdapter.Fill(_dSet, table);
                _dSet.Tables[table].PrimaryKey = new DataColumn[] { _dSet.Tables[table].Columns[0] };
                _returnRow = _dSet.Tables[table].Select();
                _length = _returnRow.Length;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("{0}:{1}", ex.Number, ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error in generating the queries.!");
                throw ex;
            }
        }
        public void SelectWithParametrizedQuery(string query, string table, MySqlDB db,Dictionary<string,object> parameter)
        {
            try
            {
                _tableName = table;

                _dSet.Clear();

                _command = new MySqlCommand(query, db.Connection);
                foreach (var kvp in parameter)
                    _command.Parameters.AddWithValue(kvp.Key, kvp.Value);

                _dataAdapter = new MySqlDataAdapter(_command);
                _commandBuilder = new MySqlCommandBuilder(_dataAdapter);

                _dataAdapter.Fill(_dSet, table);
                _dSet.Tables[table].PrimaryKey = new DataColumn[] { _dSet.Tables[table].Columns[0] };
                _returnRow = _dSet.Tables[table].Select();
                _length = _returnRow.Length;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("{0}:{1}", ex.Number, ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error in generating the queries.!");
                throw ex;
            }
        }
        public bool CRUD(string query, string table, MySqlDB db, Dictionary<string, object> parameter)
        {
            try
            {
                _tableName = table;

                _command = new MySqlCommand(query, db.Connection);
                foreach (var kvp in parameter)
                    _command.Parameters.AddWithValue(kvp.Key, kvp.Value);

                if (_command.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("{0}:{1}", ex.Number, ex.Message));
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error in generating the queries.!");
                return false;
            }
        }
        public bool Insert(string query, string table, MySqlDB db, Dictionary<string, object> parameter)
        {
            try
            {
                _tableName = table;

                _command = new MySqlCommand(query, db.Connection);
                foreach (var kvp in parameter)
                    _command.Parameters.AddWithValue(kvp.Key, kvp.Value);

                if (_command.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("{0}:{1}", ex.Number, ex.Message));
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error in generating the queries.!");
                return false;
            }
        }

        public DataSet DSet
        {
            get { return _dSet; }
            set { _dSet = value; }
        }
        public DataRow[] ReturnRow
        {
            get { return _returnRow; }
            set { _returnRow = value; }
        }
        protected MySqlDataAdapter DataAdapter
        {
            get { return _dataAdapter; }
            set { _dataAdapter = value; }
        }
        protected MySqlCommandBuilder CommandBuilder
        {
            get { return _commandBuilder; }
            set { _commandBuilder = value; }
        }
        protected MySqlCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
    }
}
