using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeeList = new List<Employee>();
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.WriteLine(employeeList.GetType().Name);

            var genericArguments = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericArguments)
            {
                Console.Write("[{0}]", arg.Name);
            }
        }

        /// <summary>
        /// Create instance of requested type
        /// </summary>
        /// <param name="type">The Type of which to create an instance</param>
        /// <returns></returns>
        /// <remarks>Assumes a default constructor for the type exists</remarks>
        private static object CreateCollection(Type collectionType, Type itemType)
        {
            // Pass in any arguments needed to make the generic unbound type into a closed bound type
            // ie.  Convert List<> to List<T>
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }

    }

}
