using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.BaseClass
{
    public class AttributeContainer
    {
        private bool? valBool;
        private DateTime? valDateTime;
        private long? valLong;
        private double? valDouble;
        private string valString;

        public string Val_Named { get; set; }
        public bool? Val_Bool 
        {
            get { return valBool; }
            set 
            { 
                valBool = value;
                Val_Named = valBool != null ? valBool.ToString() : null;
            }
        }
        public DateTime? Val_DateTime 
        {
            get { return valDateTime; }
            set
            {
                valDateTime = value;
                Val_Named = valDateTime != null ? valDateTime.ToString() : null;
            }
        }
        public long? Val_Long 
        {
            get { return valLong; }
            set
            {
                valLong = value;
                Val_Named = valLong != null ? valLong.ToString() : null;
            }
        }
        public double? Val_Double 
        {
            get { return valDouble; }
            set
            {
                valDouble = value;
                Val_Named = valDouble != null ? valDouble.ToString() : null;

            }
        }
        public string Val_String 
        {
            get { return valString; }
            set
            {
                valString = value;
                Val_Named = valString != null ? valString.Length > 255 ? valString.Substring(0, 254) : valString : null;
            }
        }
    }
}
