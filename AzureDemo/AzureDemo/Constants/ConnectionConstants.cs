using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AzureDemo.Constants
{
    public static class ConnectionConstants
    {
        private const string DataBaseFileName = "Products.db3";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public static string DataBasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DataBaseFileName);
            }
        }
    }
}
