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
            return SQLselectTest(String.Format("SELECT Name FROM Users WHERE Password = '{0}'", line), sqlBase);
        }

        private static SQLiteConnection CreateDummyDB(string SQLheuristicFileName)
        {
            if (File.Exists(SQLheuristicFileName))
                File.Delete(SQLheuristicFileName);

            SQLiteConnection.CreateFile(SQLheuristicFileName);
            SQLiteConnection sqlBase = new SQLiteConnection(String.Format("Data Source={0};Version=3;", SQLheuristicFileName));
            sqlBase.Open();

            SQLquery(@"CREATE TABLE Users (Name VARCHAR(20), Password VARCHAR(20))", sqlBase);

            for (int i = 0; i < 10; i++)
                SQLquery(@"INSERT INTO Users (Name, Password) VALUES ('root', 'password')", sqlBase);

            return sqlBase;
        }

        private static void SQLquery(string sql, SQLiteConnection sqlBase)
        {
            SQLiteCommand command = new SQLiteCommand(sql, sqlBase);
            command.ExecuteNonQuery();
        }

        private static string SQLselectTest(string sql, SQLiteConnection sqlBase)
        {
            SQLiteCommand command = new SQLiteCommand(sql, sqlBase);
            SQLiteDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                if (RegExp.Test("SQL logic error", ex.Message))
                    return "heuristic panic";

                return String.Empty;
            }

            if (reader.FieldCount > 1)
                return "heuristic panic";

            int rowNumber = 0;

            while (reader.Read())
                rowNumber += 1;

            reader.Close();

            return (rowNumber <= 1 ? String.Empty : "heuristic panic");
        }
    }
}
