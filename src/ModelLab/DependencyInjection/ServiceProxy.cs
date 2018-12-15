using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ModelLab.DependencyInjection
{
    public partial class ServiceRegistryBuilder
    {
        public class ServiceProxy : DispatchProxy
        {
            private static readonly MethodInfo MethodInfo;
            private object _o;

            static ServiceProxy()
            {
                Expression<Action> expression = () => Create<object, ServiceProxy>();
                var methodInfo = ((MethodCallExpression) expression.Body).Method;
                MethodInfo = methodInfo.GetGenericMethodDefinition();
            }

            public override string ToString()
            {
                return $"{_o}";
            }

            protected override object Invoke(MethodInfo methodInfo, object[] parameters)
            {
                return methodInfo.Invoke(_o, parameters);
            }

            public void Set(object o)
            {
                _o = o;
            }

            public static ServiceProxy Create(Type type)
            {
                var methodInfo = MethodInfo.MakeGenericMethod(type, typeof(ServiceProxy));
                return (ServiceProxy) methodInfo.Invoke(null, new object[] { });
            }
        }
    }
}