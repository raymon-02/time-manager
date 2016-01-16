using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TimeManager
{
    public static class DataBaseConnection
    {
        private const string ServerDataBase = "Server=localhost";
        private const string PortDataBase = "Port=5432";
        private const string UserIdDataBase = "User Id=postgres";
        private const string PasswordDataBase = "Password=csc";
        private const string DataBase = "Database=timemanager";

        public static NpgsqlConnection GetConnection()
        {
            var settingsDataBase = new string[] { ServerDataBase, PortDataBase, UserIdDataBase, PasswordDataBase, DataBase };
            var connectionDataBase = string.Join(";", settingsDataBase);
            return new NpgsqlConnection(connectionDataBase);
        }
    }
}
