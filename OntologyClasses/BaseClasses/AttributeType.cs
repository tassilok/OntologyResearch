using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.DataClasses.BaseClasses
{
    public class AttributeType
    {
        

        public string IdAttributeType
        {
            get
            {
                return AttributeTypeNode != null ? AttributeTypeNode.Id : null;
            }
            set
            {
                if (AttributeTypeNode == null)
                {
                    AttributeTypeNode = new OntologyNode(null, null);
                }
                AttributeTypeNode.Id = value;
            }
        }

        public string NameAttributeType
        {
            get
            {
                return AttributeTypeNode != null ? AttributeTypeNode.Name : null;
            }
            set
            {
                if (AttributeTypeNode == null)
                {
                    AttributeTypeNode = new OntologyNode(null, null);
                }
                AttributeTypeNode.Name = value;
            }
        }

        public string IdDataType
        {
            get
            {
                return DataTypeNode != null ? DataTypeNode.Id : null;
            }
            set
            {
                if (DataTypeNode == null)
                {
                    DataTypeNode = new OntologyNode(null, null);
                }
                DataTypeNode.Id = value;
            }
        }

        public string NameDataType
        {
            get
            {
                return DataTypeNode != null ? DataTypeNode.Name : null;
            }
            set
            {
                if (DataTypeNode == null)
                {
                    DataTypeNode = new OntologyNode(null, null);
                }
                DataTypeNode.Name = value;
            }
        }

        public string IdNodeType
        {
            get
            {
                return AttributeTypeNode != null ? AttributeTypeNode.TypeId : null;
            }
            set
            {
                if (AttributeTypeNode == null)
                {
                    AttributeTypeNode = new OntologyNode(null, null);
                }
                AttributeTypeNode.TypeId = value;
            }
        }

        public OntologyNode AttributeTypeNode { get; private set; }
        public OntologyNode DataTypeNode { get; private set; }

        public AttributeType()
        {

        }
    }
}
