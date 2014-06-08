using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseDirections
    {
        public OntologyNode Direction_LeftRight { get; private set; }
        public OntologyEdge Direction_LeftRightIsObject { get; private set; }
        public OntologyEdge Direction_LeftRightOfClass { get; private set; }
        public OntologyNode Direction_RightLeft { get; private set; }
        public OntologyEdge Direction_RightLeftIsObject { get; private set; }
        public OntologyEdge Direction_RightLeftOfClass { get; private set; }

        public List<OntologyNode> Directions;
        public List<OntologyEdge> NodeTypes;
        public List<OntologyEdge> NodeClasses;

        private ClassItems classes = new ClassItems();
        private BaseRelationTypes relationTypes = new BaseRelationTypes();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();

        public BaseDirections()
        {
            Direction_LeftRight = new OntologyNode("cc99d5365d564fd29d4f45b48af33029", "Left-Right");
            Direction_LeftRight.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Direction_LeftRight.ParentId = classes.Directions.Id;
            Direction_RightLeft = new OntologyNode("061243fc4c134bd5800c2c33b70e99b2", "Right-Left");
            Direction_RightLeft.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Direction_RightLeft.ParentId = classes.Directions.Id;

            Direction_LeftRightIsObject = new OntologyEdge(Direction_LeftRight, relationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            Direction_LeftRightOfClass = new OntologyEdge(classes.Directions, relationTypes.BaseClassOf, Direction_LeftRight);
            Direction_RightLeftIsObject = new OntologyEdge(Direction_RightLeft, relationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            Direction_RightLeftOfClass = new OntologyEdge(classes.Directions, relationTypes.BaseClassOf, Direction_RightLeft);

            Directions = new List<OntologyNode>
            {
                Direction_LeftRight,
                Direction_RightLeft
            };

            NodeTypes = new List<OntologyEdge>
            {
                Direction_LeftRightIsObject,
                Direction_RightLeftIsObject
            };

            NodeClasses = new List<OntologyEdge>
            {
                Direction_LeftRightOfClass,
                Direction_RightLeftOfClass
            };
        }
    }
}
