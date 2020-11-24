using Microsoft.Azure.Cosmos;

namespace cirrus_functions
{
    public class CosmosDbService
    {
        private string CosmosURI = "";
        private string CosmosKey = "";
        private string CosmosDB = "";
        private string CosmosContainerName = "";

        private CosmosClient CosmosDbClient;
        public Container CosmosContainer;
        public CosmosDbService()
        {
            CosmosDbClient = new CosmosClient(CosmosURI, CosmosKey);
            CosmosContainer = CosmosDbClient.GetContainer(CosmosDB, CosmosContainerName);
        }
    }
}
