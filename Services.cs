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

    public class Customer { }

    public class InvoiceService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">eg. Repository of type Employee or Customer</param>
        /// <param name="logger"></param>
        /// <remarks>The concrete constructor could ask for any IRepository<></remarks>
        public InvoiceService(IRepository<Customer> repository, ILogger logger)
        {
            
        }
    }

}
