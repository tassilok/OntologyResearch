using OntologyToEsConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OntologyClasses.DataClasses;
using OntologyClasses.DataClasses.DataClasses;
using OntologyClasses;
using OntologyModule.Classes;
using OntologyClasses.BaseClasses;
using System.Windows.Forms;

namespace OntologyModule
{
    public class GlobalConfiguration
    {
        private BaseObjectAttributes objectAttributes = new BaseObjectAttributes();
        private BaseLogStates baseLogStates = new BaseLogStates();

        public BaseObjectAttributes ObjectAttributes { get { return objectAttributes; } }
        public BaseLogStates LogStates { get { return baseLogStates; } }
        public string Session { get; private set; }
        public bool ModuleLoad { get; private set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Index { get; set; }
        public int SearchRange { get; set; }
        public string ConfigPath { get; set; }

        private DbLevel dbLevel1;
        private DbLevel dbLevel2;

        public string RegexId
        {
            get { return objectAttributes.RegEx_Id.Val_String; }
        }

        private EsClient esClient;

        //public bool TestIndexExistance()
        //{

        //}

        public GlobalConfiguration(string configPath, bool moduleLoad = true)
        {
            ConfigPath = configPath;
            ModuleLoad = moduleLoad;

            Initialize();

        }

        public GlobalConfiguration(bool moduleLoad = true)
        {
            ConfigPath = "";
            ModuleLoad = ModuleLoad;

            Initialize();
        }

        private void Initialize()
        {
            SetSession();
            GetConfigData();

            try
            {
                dbLevel1 = new DbLevel(Server, Port, Index, SearchRange, Session);
                dbLevel2 = new DbLevel(Server, Port, Index, SearchRange, Session);

                var result = LogStates.Success;
                try
                {
                    result = TestExistanceIOntology();
                }
                catch (Exception ex)
                {
                    result = LogStates.Nothing;
                }

                if (result.Id == LogStates.Nothing.Id)
                {
                    if (MessageBox.Show("The Database " + Index + "@" + Server + " does not exist. Should the Database be created?", "Create?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CreateIndex().Id == LogStates.Error.Id)
                        {
                            MessageBox.Show("The Database cannot be created!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            result = LogStates.Success;
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                if (result.Id == LogStates.Success.Id)
                {
                    
                }
            }
            catch (Exception ex)
            {
                // Config-Form
            }
            
        }

        private OntologyNode TestExistanceIOntology()
        {
            if (dbLevel1.TestIndex())
            {
                return LogStates.Success;
            }
            else
            {
                return LogStates.Nothing;
            }
        
        }

        private OntologyNode CreateIndex()
        {
            if (dbLevel1.CreateIndex())
            {
                return LogStates.Success;
            }
            else
            {
                return LogStates.Error;
            }
        }


        private void SetSession()
        {
            Session = GlobalOntologyConfiguration.CreateNewId();
        }

        private void GetConfigData()
        {
            var configFile = ConfigPath;
            configFile += (!ConfigPath.EndsWith("\\") ? "\\" : "");
            configFile += "Config\\Config_ont.xml";

            

            var objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + configFile);

            var configurationNodes = objXML.GetElementsByTagName("ConfigurationItem");
            var configurationList = configurationNodes.Cast<XmlNode>().Select(n => new { name = n.Attributes[0].Value, value = n.Attributes[1].Value }).ToList();

            var servers = configurationList.Where(ci => ci.name.ToLower() == "server").ToList();
            if (servers.Any())
            {
                Server = servers.First().value;
                var ports = configurationList.Where(ci => ci.name.ToLower() == "port").ToList();

                if (ports.Any())
                {
                    int port;
                    if (int.TryParse(ports.First().value, out port))
                    {
                        Port = port;
                        var indexes = configurationList.Where(ci => ci.name.ToLower() == "index").ToList();
                        if (indexes.Any())
                        {
                            Index = indexes.First().value;
                            var searchRanges = configurationList.Where(ci => ci.name.ToLower() == "searchrange").ToList();

                            if (searchRanges.Any())
                            {
                                int searchRange;

                                if (int.TryParse(searchRanges.First().value, out searchRange))
                                {
                                    SearchRange = searchRange;
                                }
                                else
                                {
                                    throw new Exception("Config-Error (Search Range)");
                                }
                            }
                            else
                            {
                                throw new Exception("Config-Error (Search Range)");
                            }
                        }
                        else
                        {
                            throw new Exception("Config-Error (Index)");
                        }
                    }
                    else
                    {
                        throw new Exception("Config-Error (Port)");
                    }
                }
                else
                {
                    throw new Exception("Config-Error (Port)");
                }
            }
            else
            {
                throw new Exception("Config-Error (Server)");
            }
            
            

        }
    }
}
