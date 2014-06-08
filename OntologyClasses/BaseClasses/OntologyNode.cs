using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.BaseClasses
{
    public class OntologyNode
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string TypeId { get; set; }
        public string ParentId { get; set; }
        public string FilterCriteria1 { get; set; }
        public string FilterCriteria2 { get; set; }

        public bool? Val_Bool { get; set; }
        public DateTime? Val_DateTime { get; set; }
        public long? Val_Long { get; set; }
        public double? Val_Double { get; set; }
        public string Val_String { get; set; }

        public OntologyNode(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
