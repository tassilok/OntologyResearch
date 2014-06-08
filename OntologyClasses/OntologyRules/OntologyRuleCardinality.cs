using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace OntologyClasses.OntologyRules
{
    public class OntologyRuleCardinality
    {
        public OntologyEdge EdgeOfRule { get; private set; }
        public long Cardinality { get; private set; }
        public OntologyNode CardinalityAttributeType { get; private set; }

        public OntologyNode CardinalityNode { get; private set; }
        public OntologyEdge CardinalityEdge { get; private set; }

        private BaseRelationTypes baseRelationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();

        public OntologyRuleCardinality(OntologyEdge edgeOfRule, OntologyNode cardinalityAttributeType, long cardinality)
        {
            EdgeOfRule = EdgeOfRule;
            CardinalityAttributeType = cardinalityAttributeType;
            Cardinality = cardinality;

            CardinalityNode = new OntologyNode(GlobalOntologyConfiguration.CreateNewId(), cardinality.ToString());
            CardinalityNode.Val_Long = cardinality;
            CardinalityNode.TypeId = baseOntologyItemTypes.Attribute.Id;
            CardinalityNode.ParentId = cardinalityAttributeType.Id;

            CardinalityEdge = new OntologyEdge(edgeOfRule, baseRelationTypes.Defines, CardinalityNode);

        }

        
    }
}
