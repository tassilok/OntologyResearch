using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.DataClasses.DataClasses
{
    public class BaseRegEx
    {
        public OntologyNode RegEx_Id { get; private set; }
        public OntologyEdge RegEx_IdIsObject { get; private set; }
        public OntologyEdge RegEx_IdClass { get; private set; }

        public List<OntologyNode> RegEx;
        public List<OntologyEdge> NodeTypes;
        public List<OntologyEdge> NodeClasses;

        private ClassItems classes = new ClassItems();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();
        private BaseRelationTypes relationTypes = new BaseRelationTypes();

        public BaseRegEx()
        {
            RegEx_Id = new OntologyNode("7e84dc67a1234993b0ea62dffc2b895d", "Id");
            RegEx_Id.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            RegEx_Id.ParentId = classes.RegEx.Id;

            RegEx_IdIsObject = new OntologyEdge(RegEx_Id, relationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            RegEx_IdClass = new OntologyEdge(classes.RegEx, relationTypes.BaseClassOf, RegEx_Id);


            RegEx = new List<OntologyNode>
            {
                RegEx_Id
            };

            NodeTypes = new List<OntologyEdge>
            {
                RegEx_IdIsObject
            };

            NodeClasses = new List<OntologyEdge>
            {
                RegEx_IdClass
            };
        }
    }
}
