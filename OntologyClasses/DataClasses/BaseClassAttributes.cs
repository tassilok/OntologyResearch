using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class BaseClassAttributes
    {
        public ClassAttribute Server__ProcessorID { get; private set; }
        public ClassAttribute Server__BaseBoardSerial { get; private set; }

        public List<ClassAttribute> ClassAttributes { get; private set; }

        public BaseOntologyItemTypes baseOntologyItemTypes = new BaseOntologyItemTypes();
        public ClassItems classes = new ClassItems();
        public BaseAttributeTypes attributeTypes = new BaseAttributeTypes();

        public BaseClassAttributes()
        {
            Server__BaseBoardSerial = new ClassAttribute(classes.Server, attributeTypes.WMI_BaseBoardSerial, 0, 1, 1);
            Server__ProcessorID = new ClassAttribute(classes.Server, attributeTypes.WMI_ProcessorID, 0, 1, 1);
            
            ClassAttributes = new List<ClassAttribute>
            {
                Server__BaseBoardSerial,
                Server__ProcessorID
            };

        }

    }
}
