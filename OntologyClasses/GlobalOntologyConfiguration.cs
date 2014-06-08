using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses
{
    public static class GlobalOntologyConfiguration
    {
        public static string CreateNewId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
