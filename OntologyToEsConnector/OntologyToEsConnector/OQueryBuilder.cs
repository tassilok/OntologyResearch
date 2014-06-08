using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyToEsConnector
{
    class OQueryBuilder
    {
        private BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();
        private EsFields esFields = new EsFields();

        public List<string> SpecialCharacters_Write { get; set; }
        public List<string> SpecialCharacters_Read { get; set; }

        public string Create_Query_Simple(List<OntologyNode> items, string IdOntology, bool boolExact = false)
        {
            var strQuery = "";
            var strField_IDParent = "";

            var properties = typeof(OntologyNode).GetProperties();

            if (items != null)
            {
                if (items.Any())
                {
                    var boolID = false;
                    var oL_ID = (from obj in items
                                 where obj.Id != null && obj.Id != ""
                                 group obj by obj.Id
                                     into g
                                     select g.Key).ToList();

                    if (oL_ID.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID.Count; i++)
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += esFields.Field_Id + ":" + oL_ID[i];
                        }
                        strQuery += ")";
                    }



                    if (strQuery != "")
                    {
                        boolID = true;
                    }

                    if (!boolID)
                    {
                        strQuery = "";
                        var oL_Name = (from obj in items
                                       where obj.Name != null && obj.Name != ""
                                       group obj by obj.Name
                                           into g
                                           select g.Key).ToList();


                        if (oL_Name.Any())
                        {
                            if (strQuery != "") strQuery += "  AND  ";
                            strQuery += "(";
                            for (var i = 0; i < oL_Name.Count; i++)
                            {
                                if (i > 0) strQuery += " OR ";
                                var nameQuery = oL_Name[i];
                                foreach (var specialCharacter in SpecialCharacters_Read)
                                {
                                    nameQuery = nameQuery.Replace(specialCharacter, "\\" + specialCharacter);
                                }

                                if (!boolExact)
                                {
                                    if (nameQuery == oL_Name[i])
                                    {
                                        strQuery += esFields.Field_Name + ":*" + nameQuery + "*";
                                    }
                                    else
                                    {
                                        strQuery += esFields.Field_Name + ":\"" + nameQuery + "\"";
                                    }


                                }
                                else
                                {
                                    strQuery += esFields.Field_Name + ":" + nameQuery;
                                }

                            }
                            strQuery += ")";
                        }



                        if (IdOntology == baseOntologyItemTypes.AttributeTypeNode.Id ||
                            IdOntology == baseOntologyItemTypes.ClassNode.Id ||
                            IdOntology == baseOntologyItemTypes.ObjectNode.Id)
                        {
                            var oL_IDParent = (from obj in items
                                               where obj.ParentId != null & obj.ParentId != ""
                                               group obj by obj.ParentId
                                                   into g
                                                   select g.Key).ToList();


                            if (oL_IDParent.Any())
                            {
                                if (strQuery != "") strQuery += "  AND  ";
                                strQuery += "(";
                                for (var i = 0; i < oL_IDParent.Count; i++)
                                {
                                    if (i > 0) strQuery += " OR ";

                                    strQuery += strField_IDParent + ":" + oL_IDParent[i];
                                }
                                strQuery += ")";
                            }



                        }
                    }
                }
            }

            if (strQuery == "")
            {
                strQuery = "*";
            }

            return strQuery;
        }

        public OQueryBuilder()
        {
            SpecialCharacters_Read = new List<string> { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":", "@", "/" };
        }
    }
}
