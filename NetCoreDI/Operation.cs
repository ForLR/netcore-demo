using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI
{
    public class Operation :IOperationSingleton,IOperationScoped,IOperationTransient
    {
        private Guid _guid;
        public Operation()
        {
            this._guid = Guid.NewGuid();
        }
        public Operation(Guid guid)
        {
            this._guid = guid;
        }


        public Guid OperationId => _guid;

      
    }
}
