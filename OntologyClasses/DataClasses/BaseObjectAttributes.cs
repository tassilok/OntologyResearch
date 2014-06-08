using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.DataClasses.DataClasses
{
    public class BaseObjectAttributes
    {
        public ObjectAttribute RegEx_Id { get; private set; }

        private BaseRegEx baseRegEx = new BaseRegEx();

        public List<ObjectAttribute> RegEx;

        private BaseAttributeTypes attributeTypes = new BaseAttributeTypes();

        public BaseObjectAttributes()
        {
            RegEx_Id = new ObjectAttribute(baseRegEx.RegEx_Id, baseRegEx.RegEx_IdClass.NodeLeft, attributeTypes.RegEx, 1)
            {
                Val_String = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}"
            };

            RegEx = new List<ObjectAttribute>
            {
                RegEx_Id
            };
        }

    }
}
