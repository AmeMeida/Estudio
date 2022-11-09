using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.model.dao
{
    public interface IDAO<T> where T : class
    {
        bool Save();
        bool Delete();
        bool Update(T e);
        bool Check();
        string Nome { get; }
        object ID { get; }
    }
}
