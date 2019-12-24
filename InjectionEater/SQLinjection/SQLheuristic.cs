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

        public static string Eat(string line)
        {
            foreach (char quote in new char[] { '\'', '"', ' ' })
            {
                string fullQuery = String.Format("SELECT Name FROM Users WHERE Password = {0}{1}{0}", quote, line);

                string[] queries = fullQuery.Split(';');

                foreach (string query in queries)
                {
                    string tryToEat = SQLselectTest(query, sqlBase, logicErrorWarn: (quote == ' ' ? false : true));

                    if (!String.IsNullOrEmpty(tryToEat))
                        return tryToEat;
                }
            }

            return String.Empty;
        }

        private static SQLiteConnection CreateDummyDB(string SQLheuristicFileName)
        {
            if (File.Exists(SQLheuristicFileName))
                File.Delete(SQLheuristicFileName);

            SQLiteConnection.CreateFile(SQLheuristicFileName);
            SQLiteConnection sqlBase = new SQLiteConnection(String.Format("Data Source={0};Version=3;", SQLheuristicFileName));
            sqlBase.Open();

            SQLquery(@"CREATE TABLE Users (Name VARCHAR(20), Password VARCHAR(20))", sqlBase);

            foreach (string login in new string[] { "root", "admin", "username", "default", "guest" })
                SQLquery(@"INSERT INTO Users (Name, Password) VALUES ('root', 'password')", sqlBase);

            return sqlBase;
        }

        private static void SQLquery(string sql, SQLiteConnection sqlBase)
        {
            SQLiteCommand command = new SQLiteCommand(sql, sqlBase);
            command.ExecuteNonQuery();
        }

        private static string SQLselectTest(string sql, SQLiteConnection sqlBase, bool logicErrorWarn = false)
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
                    return "heuristic panic";

                return String.Empty;
            }

            if (reader.FieldCount > 1)
                return "heuristic panic";


            bool hasRows = reader.HasRows;

            reader.Close();

            return (hasRows ? "heuristic panic" : String.Empty);
        }
    }
}
