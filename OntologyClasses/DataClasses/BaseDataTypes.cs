using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseDataTypes
    {
        public OntologyNode BoolDType { get; private set; }
        public OntologyEdge BoolIsDataType { get; private set; }
        
        public OntologyNode DateTimeDType { get; private set; }
        public OntologyEdge DateTimeIsDataType { get; private set; }

        public OntologyNode LongDType { get; private set; }
        public OntologyEdge LongIsDataType { get; private set; }
        
        public OntologyNode RealDType { get; private set; }
        public OntologyEdge RealIsDataType { get; private set; }
        
        public OntologyNode StringDType { get; private set; }
        public OntologyEdge StringIsDataType { get; private set; }
        

        public List<OntologyNode> DataTypes;
        public List<OntologyEdge> NodeTypes { get; private set; }

        private BaseRelationTypes relationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();

        public BaseDataTypes()
        {
            BoolDType = new OntologyNode ( "dd858f27d5e14363a5c33e561e432333", "Bool" );
            BoolDType.TypeId = baseOntologyItemTypes.DataTypeNode.Id;
            DateTimeDType = new OntologyNode("905fda81788f4e3d83293e55ae984b9e", "DateTime");
            DateTimeDType.TypeId = baseOntologyItemTypes.DataTypeNode.Id;
            LongDType = new OntologyNode("3a4f5b7bda754980933efbc33cc51439", "Long");
            LongDType.TypeId = baseOntologyItemTypes.DataTypeNode.Id;
            RealDType = new OntologyNode("a1244d0e187f46ee85742fc334077b7d", "Long");
            RealDType.TypeId = baseOntologyItemTypes.DataTypeNode.Id;
            StringDType = new OntologyNode("64530b52d96c4df186fe183f44513450", "Long");
            StringDType.TypeId = baseOntologyItemTypes.DataTypeNode.Id;

            BoolIsDataType = new OntologyEdge ( BoolDType, relationTypes.IsOfType, baseOntologyItemTypes.DataTypeNode);
            DateTimeIsDataType = new OntologyEdge ( DateTimeDType, relationTypes.IsOfType, baseOntologyItemTypes.DataTypeNode);
            LongIsDataType = new OntologyEdge ( LongDType, relationTypes.IsOfType, baseOntologyItemTypes.DataTypeNode);
            RealIsDataType = new OntologyEdge ( RealDType, relationTypes.IsOfType, baseOntologyItemTypes.DataTypeNode);
            StringIsDataType = new OntologyEdge ( BoolDType, relationTypes.IsOfType, baseOntologyItemTypes.DataTypeNode);

            DataTypes = new List<OntologyNode>
            {
                BoolDType,
                DateTimeDType,
                LongDType,
                RealDType,
                StringDType
            };

            NodeTypes = new List<OntologyEdge>
            {
                BoolIsDataType,
                DateTimeIsDataType,
                LongIsDataType,
                RealIsDataType,
                StringIsDataType
            };
        }


    }
}
