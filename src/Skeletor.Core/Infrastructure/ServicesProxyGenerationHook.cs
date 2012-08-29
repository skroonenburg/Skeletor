using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace Skeletor.Core.Infrastructure
{
    public class ServicesProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return (methodInfo.MemberType == MemberTypes.Method) && !methodInfo.IsSpecialName;
        }
    }
}