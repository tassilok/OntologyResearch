using Nest;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyToEsConnector
{
    public class EsSelector
    {
        private EsClient esClient;

        //private ISearchResponse<clsObjectRel> resultObjectRel;
        //private ISearchResponse<clsObjectAtt> resultObjectAddOrder;
        private ISearchResponse<OntologyNode> resultAttributeType;
        private ISearchResponse<OntologyNode> resultAttributeTypeCount;
        //private ISearchResponse<clsClassAtt> resultClassAtt;
        //private ISearchResponse<clsClassAtt> resultClassAttCount;
        //private ISearchResponse<clsOntologyItem> resultClasses;
        //private ISearchResponse<clsOntologyItem> resultClassesCount;
        //private ISearchResponse<clsClassRel> resultClassRel;
        //private ISearchResponse<clsClassRel> resultClassRelCount;
        //private ISearchResponse<clsOntologyItem> resultDataTypes;
        //private ISearchResponse<clsOntologyItem> resultDataTypesCount;
        //private ISearchResponse<clsObjectAtt> resultObjectAtt;
        //private ISearchResponse<clsObjectAtt> resultObjectAttCount;
        //private ISearchResponse<clsObjectRel> resultObjectRelCount;
        //private ISearchResponse<clsOntologyItem> resultObjects;
        //private ISearchResponse<clsObjectRel> resultObjectRelTree;
        //private ISearchResponse<clsObjectRel> resultObjectRelTreeCount;
        //private ISearchResponse<clsOntologyItem> resultObjectCount;
        //private ISearchResponse<clsObjectRel> resultObjectRelOrder;
        //private ISearchResponse<clsOntologyItem> resultRelationTypes;
        //private ISearchResponse<clsOntologyItem> resultRelationTypesCount;

        public List<AttributeType> AttributeTypes1;
        public List<AttributeType> AttributeTypes2;

        private OQueryBuilder queryBuilder = new OQueryBuilder();
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();

        public List<AttributeType> get_Data_AttributeType(List<OntologyNode> attributeTypes = null, bool List2 = false)
        {
            resultAttributeType = null;
            if (AttributeTypes1 == null)
            {
                AttributeTypes1 = new List<AttributeType>();
            }

            if (AttributeTypes2 == null)
            {
                AttributeTypes2 = new List<AttributeType>();
            }

            if (!List2)
            {
                AttributeTypes1.Clear();
            }
            else
            {
                AttributeTypes2.Clear();
            }


            var strQuery = queryBuilder.Create_Query_Simple(attributeTypes, baseOntologyItemTypes.AttributeTypeNode.Id);

            var intCount = esClient.SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;


                resultAttributeType = esClient.EsConnector.Search<OntologyNode>(s => s.Index(esClient.Index).Type(baseOntologyItemTypes.AttributeTypeNode.Name).QueryString(strQuery).From(intPos).Size(esClient.SearchRange));
                //ElConnector.Search(Index, objTypes.AttributeType, objBoolQuery.ToString(), intPos,
                //SearchRange);


                if (!List2)
                {
                    AttributeTypes1.AddRange(resultAttributeType.Documents.Select(d => new AttributeType
                    {
                        IdAttributeType = d.Id,
                        NameAttributeType = d.Name,
                        IdDataType = d.ParentId,
                        IdNodeType = baseOntologyItemTypes.AttributeTypeNode.Id
                    }));
                }
                else
                {
                    AttributeTypes2.AddRange(resultAttributeType.Documents.Select(d => new AttributeType
                    {
                        IdAttributeType = d.Id,
                        NameAttributeType = d.Name,
                        IdDataType = d.ParentId,
                        IdNodeType = baseOntologyItemTypes.AttributeTypeNode.Id
                    }));
                }


                if (resultAttributeType.Documents.Count() < esClient.SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultAttributeType.Documents.Count();
                    intPos += esClient.SearchRange;
                }



            }

            if (!List2)
            {
                return AttributeTypes1;
            }
            else
            {
                return AttributeTypes2;
            }

        }

        public EsSelector(EsClient esClient)
        {
            this.esClient = esClient;
        }

    }
}
