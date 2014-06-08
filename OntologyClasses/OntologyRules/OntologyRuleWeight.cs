using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace OntologyClasses.OntologyRules
{
    public class OntologyRuleWeight
    {
        public OntologyEdge EdgeOfRule { get; private set; }
        public long Weight { get; private set; }
        public OntologyNode WeightAttributeType { get; private set; }

        public OntologyNode WeightNode { get; private set; }
        public OntologyEdge WeightEdge { get; private set; }

        private BaseRelationTypes baseRelationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();

        public OntologyRuleWeight(OntologyEdge edgeOfRule, OntologyNode weightAttributeType, long weight)
        {
            EdgeOfRule = EdgeOfRule;
            WeightAttributeType = weightAttributeType;
            Weight = weight;

            WeightNode = new OntologyNode(GlobalOntologyConfiguration.CreateNewId(), Weight.ToString());
            WeightNode.Val_Long = Weight;
            WeightNode.TypeId = baseOntologyItemTypes.Attribute.Id;
            WeightNode.ParentId = WeightAttributeType.Id;

            WeightEdge = new OntologyEdge(edgeOfRule, baseRelationTypes.Defines, WeightNode);

        }
    }
}
