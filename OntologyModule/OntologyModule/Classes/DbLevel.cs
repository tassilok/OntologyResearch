using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyToEsConnector;
using OntologyClasses.BaseClasses;

namespace OntologyModule.Classes
{
    [Flags]
    public enum SortEnum
    {
        ASC_Name = 1,
        DESC_Name = 2,
        NONE = 4,
        ASC_OrderID = 8,
        DESC_OrderID = 16
    }
    public class DbLevel
    {
        private EsClient esClient;

        public string Server { get; set; }
        public int Port { get; set; }
        public string Index { get; set; }
        public int SearchRange { get; set; }
        public string Session { get; set; }

        public DbLevel()
        {
            esClient = new EsClient();

        }

        public DbLevel(GlobalConfiguration globals)
        {
            Server = globals.Server;
            Port = globals.Port;
            Index = globals.Index;
            SearchRange = globals.SearchRange;
            Session = globals.Session;

            Initailze_Client();
        }

        public DbLevel(string server, int port, string index, int searchRange, string session)
        {
            Server = server;
            Port = port;
            Index = index;
            SearchRange = searchRange;
            Session = session;

            Initailze_Client();
        }


        public void Initailze_Client(string server = null, int? port = null, string index = null, int? searchRange = null, string session = null)
        {
            if (server != null)
            {
                Server = server;
            }

            if (port != null)
            {
                Port = (int)port;
            }

            if (index != null)
            {
                Index = index;
            }

            if (searchRange != null)
            {
                SearchRange = (int)searchRange;
            }

            if (session != null)
            {
                Session = session;
            }

            esClient = new EsClient();
            esClient.Server = Server;
            esClient.Port = Port;
            esClient.Index = Index;
        }

        public bool CreateIndex()
        {
            var indexSettings = esClient.GetIndexSettings();
            var opResult = esClient.EsConnector.CreateIndex(Index);
            return opResult.IsValid;
        }

        public bool TestIndex()
        {
            var indexDescriptor = esClient.GetIndexExistsDescriptor();
            indexDescriptor.Index(Index);

            return esClient.EsConnector.IndexExists(i => indexDescriptor).Exists;
        }
    }
}
