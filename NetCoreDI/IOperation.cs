﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }
    public interface IOperationSingleton : IOperation { }
    public interface IOperationTransient: IOperation { }
    public interface IOperationScoped: IOperation { }
}
