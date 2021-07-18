using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace InjectionEater
{
    class SQLheuristic
    {
        public static SQLiteConnection sqlBase = CreateDummyDB(@"heuristic.db");

        public static bool Eat(string line)
        {
            foreach (char quote in new char[] { '\'', '"', ' ' })
            {
                string[] queries = String.Format("SELECT Name FROM Users WHERE Password = {0}{1}{0}", quote, line).Split(';');

                foreach (string query in queries)
                    if (SQLselectTest(query, sqlBase, logicErrorWarn: (quote != ' ')))
                        return true;
            }

            return false;
        }

        private static SQLiteConnection CreateDummyDB(string SQLheuristicFileName)
        {
            if (File.Exists(SQLheuristicFileName))
                File.Delete(SQLheuristicFileName);

            SQLiteConnection.CreateFile(SQLheuristicFileName);

            SQLiteConnection sqlBase = new SQLiteConnection(String.Format("Data Source={0};Version=3;", SQLheuristicFileName));

            sqlBase.Open();

            SQLquery(@"CREATE TABLE Users (Name VARCHAR(20), Password VARCHAR(20))", sqlBase);

            List<string> logins = new List<String>
            {
                "root",
                "admin",
                "username",
                "default",
                "guest"
            };

            foreach (string login in logins)
                SQLquery(String.Format("INSERT INTO Users (Name, Password) VALUES ('{0}', 'injectionEaterPassword')", login), sqlBase);

            return sqlBase;
        }

        private static void SQLquery(string sql, SQLiteConnection sqlBase) => new SQLiteCommand(sql, sqlBase).ExecuteNonQuery();

        private static bool SQLselectTest(string sql, SQLiteConnection sqlBase, bool logicErrorWarn = false)
        {
            SQLiteCommand command = new SQLiteCommand(sql, sqlBase);
            SQLiteDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                if (logicErrorWarn && RegExp.Test("SQL logic error", ex.Message))
                    return true;

                return false;
            }

            if (reader.FieldCount > 1)
                return true;

            while (reader.Read())
                if (reader.GetString(1).Contains("injectionEaterPassword"))
                    return true;

            bool hasRows = reader.HasRows;

            reader.Close();

            return hasRows;
        }
    }
}
