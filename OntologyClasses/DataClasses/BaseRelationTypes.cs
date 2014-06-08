using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseRelationTypes
    {
        public OntologyNode BaseClassOf { get; private set; }
        public OntologyNode ParentClassOf { get; private set; }
        public OntologyNode IsOfType { get; private set; }
        public OntologyNode IsOfDataType { get; private set; }
        public OntologyNode Describes { get; private set; }
        public OntologyNode Defines { get; private set; }

        public List<OntologyNode> RelationTypes;

        public BaseRelationTypes()
        {
            BaseClassOf = new OntologyNode("44dbcfa923bc4b3a923e654d043133f6", "Baseclass of");
            ParentClassOf = new OntologyNode("ca8c9443b1ec49eb91d6d7e895aae4c1", "Parentclass of");
            IsOfType = new OntologyNode("9996494aef6a4357a6ef71a92b5ff596", "Is of Type");
            IsOfDataType = new OntologyNode("8ccda4a5970549018f503fd1f8b3c562", "Is of DataType");
            Describes = new OntologyNode("5e99a4bb3266453092fb00d557706f5b", "Describes");
            Defines = new OntologyNode("21691b2960a541ee92717b529166e0ac", "Defines");

            RelationTypes = new List<OntologyNode> { BaseClassOf,
                ParentClassOf,
                IsOfType,
                IsOfDataType,
                Describes,
                Defines};

        }
    }
}
