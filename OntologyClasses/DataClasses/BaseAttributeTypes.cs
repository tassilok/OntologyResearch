using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseAttributeTypes
    {
        public OntologyNode WMI_ProcessorID { get; private set; }
        public OntologyEdge WMI_ProcessorIDIsAttributeType { get; private set; }
        public OntologyEdge WMI_ProcessorIDIsString { get; private set; }
        
        public OntologyNode WMI_BaseBoardSerial { get; private set; }
        public OntologyEdge WMI_BaseBoardSerialIsString { get; private set; }
        public OntologyEdge WMI_BaseBoardSerialIsAttributeType { get; private set; }

        public OntologyNode MinForw { get; private set; }
        public OntologyEdge MinForwIsLong { get; private set; }
        public OntologyEdge MinForwIsAttributeType { get; private set; }

        public OntologyNode MaxForw { get; private set; }
        public OntologyEdge MaxForwIsLong { get; private set; }
        public OntologyEdge MaxForwIsAttributeType { get; private set; }

        public OntologyNode MaxBackw { get; private set; }
        public OntologyEdge MaxBackwIsLong { get; private set; }
        public OntologyEdge MaxBackwIsAttributeType { get; private set; }
        
        public OntologyNode Weight { get; private set; }
        public OntologyEdge WeightIsLong { get; private set; }
        public OntologyEdge WeightIsAttributeType { get; private set; }

        public OntologyNode RegEx { get; private set; }
        public OntologyEdge RegExIsString { get; private set; }
        public OntologyEdge RegExIsAttributeType { get; private set; }
        
        public List<OntologyNode> AttributeTypes { get; private set; }
        public List<OntologyEdge> NodeTypes { get; private set; }
        public List<OntologyEdge> NodeDataTypes { get; private set; }

        private BaseRelationTypes relationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();
        private BaseDataTypes dataTypes = new BaseDataTypes();

        public BaseAttributeTypes()
        {
            WMI_ProcessorID = new OntologyNode("a1b4945219dc4eaea000ef3802de35a9", "ProcessorID");
            WMI_ProcessorID.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            WMI_ProcessorID.ParentId = dataTypes.StringDType.Id;
            
            WMI_BaseBoardSerial = new OntologyNode("30b76a621b224f17b9a5ff665e08f35a", "BaseboardSerial");
            WMI_BaseBoardSerial.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            WMI_BaseBoardSerial.ParentId = dataTypes.StringDType.Id;
            
            MinForw = new OntologyNode("c60e083dc2944d5b8b0d5aadbc5587ac", "Min Forward");
            MinForw.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            MinForw.ParentId = dataTypes.LongDType.Id;

            MaxForw = new OntologyNode("8ca526856fe34e1d85c106f9e1aff2b8", "Max Forward");
            MaxForw.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            MaxForw.ParentId = dataTypes.LongDType.Id;

            MaxBackw = new OntologyNode("b5aabf43c36441a68964ac9406bd9c7e", "Max Backward");
            MaxBackw.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            MaxBackw.ParentId = dataTypes.LongDType.Id;
            
            Weight = new OntologyNode("f209eb0da51749a9bb6bc7cb5884f8f2", "Weight");
            Weight.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            Weight.ParentId = dataTypes.LongDType.Id;

            RegEx = new OntologyNode("22e93da2894a45d497d15e1711aa5657", "RegEx");
            RegEx.TypeId = baseOntologyItemTypes.AttributeTypeNode.Id;
            RegEx.ParentId = dataTypes.StringDType.Id;

            WMI_BaseBoardSerialIsAttributeType = new OntologyEdge(WMI_BaseBoardSerial, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            WMI_ProcessorIDIsAttributeType = new OntologyEdge(WMI_ProcessorID, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            MinForwIsAttributeType = new OntologyEdge(MinForw, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            MaxForwIsAttributeType = new OntologyEdge(MaxForw, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            MaxBackwIsAttributeType = new OntologyEdge(MaxBackw, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            WeightIsAttributeType = new OntologyEdge(Weight, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);
            RegExIsAttributeType = new OntologyEdge(RegEx, relationTypes.IsOfType, baseOntologyItemTypes.AttributeTypeNode);

            WMI_ProcessorIDIsString = new OntologyEdge(WMI_ProcessorID, relationTypes.IsOfDataType, dataTypes.StringDType);
            WMI_BaseBoardSerialIsString = new OntologyEdge(WMI_BaseBoardSerial, relationTypes.IsOfDataType, dataTypes.StringDType);
            MinForwIsLong = new OntologyEdge(MinForw, relationTypes.IsOfDataType, dataTypes.LongDType);
            MaxForwIsLong = new OntologyEdge(MaxForw, relationTypes.IsOfDataType, dataTypes.LongDType);
            MaxBackwIsLong = new OntologyEdge(MaxBackw, relationTypes.IsOfDataType, dataTypes.LongDType);
            WeightIsLong = new OntologyEdge(Weight, relationTypes.IsOfDataType, dataTypes.LongDType);
            RegExIsString = new OntologyEdge(RegEx, relationTypes.IsOfDataType, dataTypes.StringDType);
            

            AttributeTypes = new List<OntologyNode>
            {
                WMI_BaseBoardSerial,
                WMI_ProcessorID,
                MinForw,
                MaxForw,
                MaxBackw,
                Weight,
                RegEx
            };

            NodeTypes = new List<OntologyEdge>
            {
                WMI_BaseBoardSerialIsAttributeType,
                WMI_ProcessorIDIsAttributeType,
                MinForwIsAttributeType,
                MaxForwIsAttributeType,
                MaxBackwIsAttributeType,
                WeightIsAttributeType,
                RegExIsAttributeType
            };

            NodeDataTypes = new List<OntologyEdge>
            {
                WMI_BaseBoardSerialIsString,
                WMI_ProcessorIDIsString,
                MinForwIsLong,
                MaxForwIsLong,
                MaxBackwIsLong,
                WeightIsLong,
                RegExIsString
            };
        }

    }
}

