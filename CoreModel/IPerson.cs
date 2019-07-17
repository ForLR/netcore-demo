using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel
{
    public interface IPerson
    {
        Task<List<long>> GetIds();
    }
}
