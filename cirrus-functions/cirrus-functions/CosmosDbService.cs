using Microsoft.Azure.Cosmos;
using System;

namespace cirrus_functions
{
    public class CosmosDbService
    {
        private string CosmosURI = "https://cirrus-csp.documents.azure.com:443/";
        private string CosmosKey = "VV4xsp3QkDSnqaDllWIpblTo9uJjybNkDHlAzqGhDwA6YUC4TdOHsCQuPkwgU6shIQl4Lfu6s7N844WUQXVEVw=="; //Environment.GetEnvironmentVariable("CosmosKey");
        private string CosmosDB = "cirrus-db";
        private string CosmosContainerName = "cirrus-container";

        private CosmosClient CosmosDbClient;
        public Container CosmosContainer;
        public CosmosDbService()
        {
            CosmosDbClient = new CosmosClient(CosmosURI, CosmosKey);
            CosmosContainer = CosmosDbClient.GetContainer(CosmosDB, CosmosContainerName);
        }
    }
}
