﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace ToDoCoreApi
{
    public class AppConfig
    {
        public static string ConnectionString = "AccountEndpoint=https://todo-core-db.documents.azure.com:443/;AccountKey=MbJeAuCHBo4G2yoPdK3LCZGTNEAm7EbOHMDV7MJSvWcgNRnlUMqewP63yfyU4dL7OQbduqR58cN5a2uCu83bMw==;";
        public static string ContainerId = "Items";
        public static string DbId = "ToDoList";
        public static string DbUri = "https://todo-core-db.documents.azure.com:443/";
        public static PartitionKey PartitionKey = new PartitionKey("/_partitionKey");
        
        public static string PrimaryKey = "MbJeAuCHBo4G2yoPdK3LCZGTNEAm7EbOHMDV7MJSvWcgNRnlUMqewP63yfyU4dL7OQbduqR58cN5a2uCu83bMw==";
    }
}
