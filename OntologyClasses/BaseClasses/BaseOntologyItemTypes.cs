using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.BaseClasses
{
    public class BaseOntologyItemTypes
    {
        public OntologyNode ClassNode { get; private set; }
        public OntologyNode ObjectNode { get; private set; }
        public OntologyNode AttributeTypeNode { get; private set; }
        public OntologyNode RelationTypeNode { get; private set; }
        public OntologyNode DataTypeNode { get; private set; }
        public OntologyNode Attribute { get; private set; }

        public List<OntologyNode> OntologyTypes { get; private set; }

        public BaseOntologyItemTypes()
        {
            ClassNode = new OntologyNode("cc6054d58f1741f2b546dd0f6185183a", "Class");
            ObjectNode = new OntologyNode("1498cf175a21443ca2e49d089facc736", "Object");
            AttributeTypeNode = new OntologyNode("397f21b710d54a099ac35a7d2b65508f", "AttributeType");
            RelationTypeNode = new OntologyNode("397f21b710d54a099ac35a7d2b65508f", "RelationType");
            DataTypeNode = new OntologyNode("ec5e1ecf15744857b2bac856a5232712", "DataType");
            Attribute = new OntologyNode("07535eef4d7f4d8181998d00625ab1c6", "Ontology-Attribute");

            OntologyTypes = new List<OntologyNode> { ClassNode, ObjectNode, AttributeTypeNode, RelationTypeNode, DataTypeNode, Attribute };
        }
    }
}
