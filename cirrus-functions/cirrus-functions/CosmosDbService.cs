using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos;

namespace cirrus_functions
{
    public class CosmosDbService
    {
        private string CosmosURI = "https://cirrus-csp.documents.azure.com:443/";
        private string CosmosKey = Environment.GetEnvironmentVariable("CosmosKey");
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
