using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.OntologyRules;
using OntologyClasses.DataClasses;

namespace OntologyClasses
{
    public class ClassAttribute
    {

        public string IdClass
        {
            get { return ClassNode.Id; }
        }

        public string NameClass
        {
            get { return ClassNode.Name; }
        }

        public string IdAttributeType
        {
            get { return AttributeType.Id; }
        }

        public string NameAttributeType
        {
            get { return AttributeType.Name; }
        }

        public long MinForw
        {
            get { return Min_Forw.Cardinality; }
        }

        public long MaxForw
        {
            get { return Max_Forw.Cardinality; }
        }

        public long MaxBack
        {
            get { return Max_Backw.Cardinality; }
        }

        public OntologyNode ClassNode { get; set; }
        public OntologyNode AttributeType { get; set; }
        public OntologyEdge ClassNodeToAttributeType { get; set; }
        public OntologyRuleCardinality Min_Forw { get; set; }
        public OntologyRuleCardinality Max_Forw { get; set; }
        public OntologyRuleCardinality Max_Backw { get; set; }

        private BaseRelationTypes baseRelationTypes = new BaseRelationTypes();
        private BaseAttributeTypes baseAttributeTypes = new BaseAttributeTypes();

        public ClassAttribute(OntologyNode classNode, OntologyNode attributeType, long minForw, long maxForw, long maxBackw)
        {
            ClassNode = classNode;
            attributeType = AttributeType;

            ClassNodeToAttributeType = new OntologyEdge(AttributeType, baseRelationTypes.Describes, ClassNode);

            Min_Forw = new OntologyRuleCardinality(ClassNodeToAttributeType, baseAttributeTypes.MinForw, minForw);
            Max_Forw = new OntologyRuleCardinality(ClassNodeToAttributeType, baseAttributeTypes.MaxForw, maxForw);
            Max_Backw = new OntologyRuleCardinality(ClassNodeToAttributeType, baseAttributeTypes.MaxBackw, maxBackw);
        }
    }
}
