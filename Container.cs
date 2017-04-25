using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    /// <summary>
    /// Map from one type to another type
    /// </summary>
    /// <remarks>Ultimately a container is a map.  </remarks>
    public class Container
    {
        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        /// <remarks>Good practice to have both a generic and one that takes generic as parameter</remarks>
        public ContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }

        public ContainerBuilder For(Type sourceType)
        {
            return new ContainerBuilder(this, sourceType);
        }

        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }
        public object Resolve(Type sourceType)
        {
            if (_map.ContainsKey(sourceType))
            {
                var destinationType = _map[sourceType];
                return Activator.CreateInstance(destinationType);
            }
            throw new InvalidOperationException("Could not resolve " + sourceType.FullName);
        }

        public class ContainerBuilder
        {
            private readonly Container _container;
            private readonly Type _sourceType;

            public ContainerBuilder(Container container, Type sourceType)
            {
                _container = container;
                _sourceType = sourceType;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="TDestination"></typeparam>
            /// <returns></returns>
            /// <remarks>Good practice to have both a generic and one that takes generic as parameter</remarks>
            public ContainerBuilder Use<TDestination>()
            {
                return Use(typeof(TDestination));
            }
            public ContainerBuilder Use(Type destinationType)
            {
                // write into the map
                _container._map.Add(_sourceType, destinationType);
                return this;
            }
        }
    }
}
