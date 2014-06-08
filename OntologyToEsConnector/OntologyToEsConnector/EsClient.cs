using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyToEsConnector
{
    public class EsClient
    {
        private string index;
        private string server;
        private int port;
        private int searchRange;

        public ElasticClient EsConnector { get; private set; }
        
        public IndexExistsDescriptor GetIndexExistsDescriptor()
        {
            return new IndexExistsDescriptor();
        }

        public IndexSettings GetIndexSettings()
        {
            return new IndexSettings();
        }

        public DeleteIndexDescriptor GetDeleteIndexDescriptor()
        {
            return new DeleteIndexDescriptor();
        }

        public string Server 
        {
            get { return server; }
            set
            {
                server = value;
                Initialize_Client();
            }
        }
        public int Port 
        {
            get { return port; }
            set
            {
                port = value;
                Initialize_Client();
            }
        }

        public string Index
        {
            get { return index; }
            set
            {
                index = value;
                Initialize_Client();
            }
        }

        public int SearchRange
        {
            get { return searchRange; }
            set
            {
                searchRange = value;
                Initialize_Client();
            }
        }

        private void Initialize_Client()
        {
            if (!string.IsNullOrEmpty(Index) &&
                !string.IsNullOrEmpty(Server) &&
                Port != 0 &&
                searchRange != 0)
            {
                try
                {
                    var uri = new Uri("http://" + Server + ":" + Port.ToString());

                    var settings = new ConnectionSettings(uri).SetDefaultIndex(Index);
                    EsConnector = new ElasticClient(settings);

                }
                catch (Exception ex)
                {
                    throw new Exception("Setting-Error!");
                }
            }
            
            
        }
    }
}
