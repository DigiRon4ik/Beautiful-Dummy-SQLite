using System.Data;
using ServiceStack.OrmLite;
using Beautiful_Dummy_SQLite.DataBase.Models;

namespace Beautiful_Dummy_SQLite.DataBase
{
    internal class ApplicationContext
    {
        public static string connectionString = "Data\\HMS.db";
        
        public static IDbConnection GetDbConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            return dbFactory.Open();
        }

        public static void InitDB()
        {
            using (var db = GetDbConnection())
            {
                if (db.CreateTableIfNotExists<User>())
                {
                    db.Save(new User { Login = "Support", Password = "support", Role = "Support", Name = "Тех.", Surname = "Поддержка", Phone = "8-(800)-555-35-35" });
                    db.Save(new User { Login = "Doctor", Password = "doctor", Role = "Адмминистратор", Name = "MR.", Surname = "ROBOT", Phone = "8-(928)-999-75-75" });
                }
            }
        }
    }
}
