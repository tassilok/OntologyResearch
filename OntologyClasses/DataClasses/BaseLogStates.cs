using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseLogStates
    {
        public OntologyNode Success { get; private set; }
        public OntologyEdge SuccessIsObject { get; private set; }
        public OntologyEdge SuccessOfClass { get; private set; }
        public OntologyNode Error { get; private set; }
        public OntologyEdge ErrorIsObject { get; private set; }
        public OntologyEdge ErrorOfClass { get; private set; }
        public OntologyNode Nothing { get; private set; }
        public OntologyEdge NothingIsObject { get; private set; }
        public OntologyEdge NothingOfClass { get; private set; }
        public OntologyNode Insert { get; private set; }
        public OntologyEdge InsertIsObject { get; private set; }
        public OntologyEdge InsertOfClass { get; private set; }
        public OntologyNode Update { get; private set; }
        public OntologyEdge UpdateIsObject { get; private set; }
        public OntologyEdge UpdateOfClass { get; private set; }
        public OntologyNode Delete { get; private set; }
        public OntologyEdge DeleteIsObject { get; private set; }
        public OntologyEdge DeleteOfClass { get; private set; }
        public OntologyNode Relation { get; private set; }
        public OntologyEdge RelationIsObject { get; private set; }
        public OntologyEdge RelationOfClass { get; private set; }
        public OntologyNode Exists { get; private set; }
        public OntologyEdge ExistsIsObject { get; private set; }
        public OntologyEdge ExistsOfClass { get; private set; }

        public List<OntologyNode> LogStates { get; private set; }
        public List<OntologyEdge> NodeTypes { get; private set; }
        public List<OntologyEdge> ClassInstances { get; private set; }

        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();
        private ClassItems baseClasses = new ClassItems();
        private BaseRelationTypes baseRelationTypes = new BaseRelationTypes();

        public BaseLogStates()
        {
            Delete = new OntologyNode("bb6a95553af640fc9fb0489d2678dff2", "Delete");
            Delete.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Delete.ParentId = baseClasses.Logstate.Id;
            Error = new OntologyNode ("cc71434176314b78b8f4385db073635f", "Error");
            Error.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Error.ParentId = baseClasses.Logstate.Id;
            Exists = new OntologyNode("0b285306f64d4444bffe627a21687eff", "Exist");
            Exists.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Exists.ParentId = baseClasses.Logstate.Id;
            Insert = new OntologyNode("a6df6ab2359045b1b32535334a2f574a", "Insert");
            Insert.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Insert.ParentId = baseClasses.Logstate.Id;

            ErrorIsObject = new OntologyEdge(Error, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            ErrorOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Error);
            DeleteIsObject = new OntologyEdge(Delete, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            DeleteOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Delete);
            ExistsIsObject = new OntologyEdge(Exists, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            ExistsOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Error);
            InsertIsObject = new OntologyEdge(Insert, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            InsertOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Insert);

            

            
                
            Nothing = new OntologyNode ("95666887fb2a416e9624a48d48dc5446", "Nothing");
            NothingIsObject = new OntologyEdge(Nothing, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            NothingOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Nothing);
            Nothing.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Nothing.ParentId = baseClasses.Logstate.Id;

            Relation = new OntologyNode("a46b74723c8e44a8b7853913b760db", "Relation");
            RelationIsObject = new OntologyEdge(Relation, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            RelationOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Relation);
            Relation.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Relation.ParentId = baseClasses.Logstate.Id;
                
            Success = new OntologyNode ("84251164265e4e0294b2ed7c40a02e56", "Success");
            SuccessIsObject = new OntologyEdge(Success, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            SuccessOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Success);
            Success.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Success.ParentId = baseClasses.Logstate.Id;

            Update = new OntologyNode ("2bf7e9d6fb9c40929b16ecc4fef7c072", "Update");
            UpdateIsObject = new OntologyEdge(Update, baseRelationTypes.IsOfType, baseOntologyItemTypes.ObjectNode);
            UpdateOfClass = new OntologyEdge(baseClasses.Logstate, baseRelationTypes.ParentClassOf, Update);
            Update.TypeId = baseOntologyItemTypes.ObjectNode.Id;
            Update.ParentId = baseClasses.Logstate.Id;

            LogStates = new List<OntologyNode>
                {
                    Delete,
                    Error,
                    Exists,
                    Insert,
                    Nothing,
                    Relation,
                    Success,
                    Update
                };

            NodeTypes = new List<OntologyEdge>
            {
                DeleteIsObject,
                ErrorIsObject,
                ExistsIsObject,
                NothingIsObject,
                RelationIsObject,
                SuccessIsObject,
                UpdateIsObject
            };

            ClassInstances = new List<OntologyEdge>
            {
                DeleteOfClass,
                ErrorOfClass,
                ExistsOfClass,
                NothingOfClass,
                RelationOfClass,
                SuccessOfClass,
                UpdateOfClass
            };
        }
    }
}
