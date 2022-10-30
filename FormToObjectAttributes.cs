using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    public class ObjectAttribute : Attribute
    {
        public Type RelatedType { get; set; }

        public ObjectAttribute(Type type)
        {
            RelatedType = type;
        }
    }
}
