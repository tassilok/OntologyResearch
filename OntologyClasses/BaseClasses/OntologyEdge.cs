using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.BaseClasses
{
    
    public class OntologyEdge
    {
        public String Id_NodeLeft 
        {
            get
            {
                return NodeLeft.Id;
            }
            set
            {
                if (NodeLeft != null)
                {
                    NodeLeft.Id = value;
                }
                else
                {
                    throw new Exception("No Left Node!");
                }
            }
        }

        public String Name_NodeLeft
        {
            get
            {
                return NodeLeft.Name;
            }
            set
            {
                if (NodeLeft != null)
                {
                    NodeLeft.Name = value;
                }
                else
                {
                    throw new Exception("No Left Node!");
                }
            }
        }

        public String Id_NodeRight
        {
            get
            {
                return NodeRight.Id;
            }
            set
            {
                if (NodeRight != null)
                {
                    NodeRight.Id = value;
                }
                else
                {
                    throw new Exception("No Right Node!");
                }
            }
        }

        public String Name_NodeRight
        {
            get
            {
                return NodeRight.Name;
            }
            set
            {
                if (NodeRight != null)
                {
                    NodeRight.Name = value;
                }
                else
                {
                    throw new Exception("No Right Node!");
                }
            }
        }

        public string Id_RelationType { get; set; }
        public string Name_RelationType { get; set; }

        public OntologyNode NodeLeft { get; private set; }
        public OntologyNode NodeRight { get; private set; }
        public OntologyEdge EdgeLeft { get; private set; }
        public OntologyEdge EdgeRight { get; private set; }
        public OntologyNode RelationType { get; private set; }

        public string TypeId_Left 
        {
            get { return NodeLeft.TypeId; }
        }
        public string ParentId_Left 
        {
            get { return NodeLeft.ParentId; }
        }
        public string FilterCriteriaLeft1 { get; set; }
        public string FilterCriteriaLeft2 { get; set; }

        public string TypeId_Right 
        {
            get { return NodeRight.TypeId; }
        }
        public string ParentId_Right 
        {
            get { return NodeRight.ParentId; }
        }
        public string FilterCriteriaRight1 { get; set; }
        public string FilterCriteriaRight2 { get; set; }

        public string TypeId_RelationType 
        {
            get { return RelationType.TypeId; }
        }

        public string ParentId_RelationType
        {
            get { return RelationType.ParentId; }
        }
        public string FilterCriteriaRelationType1 { get; set; }
        public string FilterCriteriaRelationType2 { get; set; }

        public long RelationWeight1 { get; set; }
        public long RelationWeight2 { get; set; }
        public long RelationWeight3 { get; set; }
        

        public OntologyEdge(OntologyNode NodeLeft, OntologyNode RelationType, OntologyNode NodeRight )
        {
            this.NodeLeft = NodeLeft;
            this.NodeRight = NodeRight;
            this.RelationType = RelationType;

        }

        public OntologyEdge(OntologyNode NodeLeft, OntologyNode RelationType, OntologyEdge EdgeRight )
        {
            this.NodeLeft = NodeLeft;
            this.EdgeRight = EdgeRight;
            this.RelationType = RelationType;
        }

        public OntologyEdge(OntologyEdge EdgeLeft, OntologyNode RelationType, OntologyNode NodeRight)
        {
            this.EdgeLeft = EdgeLeft;
            this.NodeRight = NodeRight;
            this.RelationType = RelationType;
        }

        public OntologyEdge(OntologyEdge EdgeLeft, OntologyNode RelationType, OntologyEdge EdgeRight )
        {
            this.EdgeLeft = EdgeLeft;
            this.EdgeRight = EdgeRight;
            this.RelationType = RelationType;
        }

        public OntologyEdge(OntologyNode NodeLeft, OntologyNode RelationType)
        {
            this.NodeLeft = NodeLeft;
            this.RelationType = RelationType;
        }


    }
}
