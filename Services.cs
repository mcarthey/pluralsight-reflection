using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    public interface ILogger
    {

    }

    public interface IRepository<T>
    {

    }

    public class SqlServerLogger : ILogger
    {

    }

    public class SqlRepository<T> : IRepository<T>
    {
        public SqlRepository(ILogger iLogger)
        {
            
        }
    }

    public class InvoiceService
    {
        public InvoiceService(IRepository<Employee> repository, ILogger logger)
        {
            
        }
    }

}
