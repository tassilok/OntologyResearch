using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class ClassItems
    {
        public OntologyNode Root { get; private set; }
        public OntologyEdge RootIsClass { get; private set; }
        public OntologyEdge Root_System { get; private set; }
        public OntologyNode System { get; private set; }
        public OntologyEdge SystemIsClass { get; private set; }
        public OntologyEdge System_Logstate { get; private set; }
        public OntologyNode Logstate { get; private set; }
        public OntologyEdge LogStateIsClass { get; private set; }
        public OntologyEdge System_Directions { get; private set; }
        public OntologyNode Directions { get; private set; }
        public OntologyEdge DirectionsIsClass { get; private set; }
        public OntologyEdge System_Server { get; private set; }
        public OntologyNode Server { get; private set; }
        public OntologyEdge ServerIsClass { get; private set; }
        public OntologyEdge System_Ontology { get; private set; }
        public OntologyNode Ontology { get; private set; }
        public OntologyEdge OntologyIsClass { get; private set; }
        public OntologyEdge Ontology_OntologyRule { get; private set; }
        public OntologyNode OntologyRule { get; private set; }
        public OntologyEdge OntologyRuleIsClass { get; private set; }
        public OntologyEdge System_RegEx { get; private set; }
        public OntologyNode RegEx { get; private set; }
        public OntologyEdge RegExIsCalss { get; private set; }

      
        private BaseRelationTypes relationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes ontologyItemTypes = new BaseOntologyItemTypes();

        public List<OntologyNode> Classes { get; private set; }
        public List<OntologyEdge> ClassInheritances { get; private set; }
        public List<OntologyEdge> ClassTypes { get; private set; }

        public ClassItems()
        {
            Root = new OntologyNode ( "49fdcd27e1054770941d7485dcad08c1", "Root" );
            RootIsClass = new OntologyEdge(Root, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            System = new OntologyNode("665dd88b792e4256a27a68ee1e10ece6", "System");
            SystemIsClass = new OntologyEdge(System, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            Logstate = new OntologyNode("1d9568afb6da49908f4d907dfdd30749", "Logstate");
            LogStateIsClass = new OntologyEdge(Logstate, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            Directions = new OntologyNode("3d1dc6cfb96449869808f39b7c5c3907", "Direction");
            DirectionsIsClass = new OntologyEdge(Directions, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            Server = new OntologyNode("d7a03a35875142b48e0519fc7a77ee91", "Server");
            ServerIsClass = new OntologyEdge(Server, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            Ontology = new OntologyNode("eb411e2ff93d4a5ebbbac0b5d7ec0197", "Ontology");
            OntologyIsClass = new OntologyEdge(Ontology, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            OntologyRule = new OntologyNode("8f54e8867a97479ca667e18c1ad74b5b", "Ontology Rule");
            OntologyRuleIsClass = new OntologyEdge(OntologyRule, relationTypes.IsOfType, ontologyItemTypes.ClassNode);
            RegEx = new OntologyNode("7e84dc67a1234993b0ea62dffc2b895d", "Regular Expressions");
            RegExIsCalss = new OntologyEdge(RegEx, relationTypes.IsOfType, ontologyItemTypes.ClassNode);

            Root_System = new OntologyEdge(Root, relationTypes.BaseClassOf, System);
            System.TypeId = ontologyItemTypes.ClassNode.Id;
            System.ParentId = Root.Id;
            System_Logstate = new OntologyEdge(System, relationTypes.BaseClassOf, Logstate);
            Logstate.TypeId = ontologyItemTypes.ClassNode.Id;
            Logstate.ParentId = System.Id;
            System_Directions = new OntologyEdge(System, relationTypes.BaseClassOf, Directions);
            Directions.TypeId = ontologyItemTypes.ClassNode.Id;
            Directions.ParentId = System.Id;
            System_Server = new OntologyEdge(System, relationTypes.BaseClassOf, Server);
            Server.TypeId = ontologyItemTypes.ClassNode.Id;
            Server.ParentId = System.Id;
            System_Ontology = new OntologyEdge(System, relationTypes.BaseClassOf, Ontology);
            Ontology.TypeId = ontologyItemTypes.ClassNode.Id;
            Ontology.ParentId = System.Id;
            Ontology_OntologyRule = new OntologyEdge(Ontology, relationTypes.BaseClassOf, OntologyRule);
            OntologyRule.TypeId = ontologyItemTypes.ClassNode.Id;
            OntologyRule.ParentId = Ontology.Id;
            System_RegEx = new OntologyEdge(System, relationTypes.BaseClassOf, RegEx);
            RegEx.TypeId = ontologyItemTypes.ClassNode.Id;
            RegEx.ParentId = System.Id;

            Classes = new List<OntologyNode>
            {
                Root,
                System,
                Logstate,
                Directions,
                Server,
                Ontology,
                OntologyRule,
                RegEx
            };

            ClassTypes = new List<OntologyEdge>
            {
                RootIsClass,
                SystemIsClass,
                LogStateIsClass,
                DirectionsIsClass,
                ServerIsClass,
                OntologyIsClass,
                OntologyRuleIsClass,
                RegExIsCalss
            };

            ClassInheritances = new List<OntologyEdge>
            {
                Root_System,
                System_Logstate,
                System_Directions,
                System_Server,
                System_Ontology,
                Ontology_OntologyRule,
                System_RegEx
            };

        }
    }
}
