using System;

namespace Portfolio.Utils
{
    public class DbConfig
    {
        private readonly string _dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        private readonly string _dbName = Environment.GetEnvironmentVariable("DB_NAME");
        private readonly string _dbUser = Environment.GetEnvironmentVariable("DB_USER");
        private readonly string _dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        public void Deconstruct(out string dbHost, out string dbName, out string dbUser, out string dbPassword)
        {
            dbHost = _dbHost;
            dbName = _dbName;
            dbUser = _dbUser;
            dbPassword = _dbPassword;
        }
    }
}