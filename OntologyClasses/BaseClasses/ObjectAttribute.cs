using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using OntologyClasses.OntologyRules;
using OntologyClasses.BaseClass;

namespace OntologyClasses.BaseClasses
{
    public class ObjectAttribute
    {
        public string IdAttribute
        {
            get { return Weight.WeightNode.Id; }
        }

        public string IdAttributeType
        {
            get { return Weight.WeightAttributeType.Id; }
        }

        public string NameAttributeType
        {
            get { return Weight.WeightAttributeType.Name; }
        }

        public string IdObject
        {
            get { return ObjectNode.Id; }
        }

        public string NameObject
        {
            get { return ObjectNode.Name; }
        }

        public string IdClass
        {
            get { return ObjectNode.ParentId; }
        }

        public string NameClass
        {
            get { return ClassNode.Name; }
        }

        public string Val_Named
        {
            get { return AttributeValue != null ? AttributeValue.Val_String : null; }
            
        }

        public bool? Val_Bool
        {
            get { return AttributeValue != null ? AttributeValue.Val_Bool : null; }
            set
            {
                AttributeValue = new AttributeContainer
                {
                    Val_Bool = value
                };
            }
        }

        public DateTime? Val_DateTime
        {
            get { return AttributeValue != null ? AttributeValue.Val_DateTime : null; }
            set
            {
                AttributeValue = new AttributeContainer
                {
                    Val_DateTime = value
                };
            }
        }

        public long? Val_Long
        {
            get { return AttributeValue != null ? AttributeValue.Val_Long : null; }
            set
            {
                AttributeValue = new AttributeContainer
                {
                    Val_Long = value
                };
            }
        }

        public double? Val_Real
        {
            get { return AttributeValue != null ? AttributeValue.Val_Double : null; }
            set
            {
                AttributeValue = new AttributeContainer
                {
                    Val_Double = value
                };
            }
        }

        public string Val_String
        {
            get { return AttributeValue != null ? AttributeValue.Val_String : null; }
            set
            {
                AttributeValue = new AttributeContainer
                {
                    Val_String = value
                };
            }
        }


        public OntologyNode ObjectNode { get; private set; }
        public OntologyNode ClassNode { get; private set; }
        public OntologyNode AttributeNode { get; private set; }
        public OntologyNode AttributeTypeNode { get; private set; }
        public OntologyEdge AttributeEdge { get; private set; }
        public AttributeContainer AttributeValue { get; private set; }

        public OntologyRuleWeight Weight { get; private set; }

        private BaseRelationTypes relationTypes = new BaseRelationTypes();
        private BaseAttributeTypes attributeTypes = new BaseAttributeTypes();

        public ObjectAttribute(OntologyNode objectNode, OntologyNode classNode,  OntologyNode attributeTypeNode, long weight)
        {
            ObjectNode = objectNode;
            ClassNode = classNode;
            AttributeTypeNode = attributeTypeNode;
            AttributeEdge = new OntologyEdge(AttributeTypeNode, relationTypes.Describes, objectNode);
            Weight = new OntologyRuleWeight(AttributeEdge, attributeTypes.Weight, weight);
        }
    }
}
