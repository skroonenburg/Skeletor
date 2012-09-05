using System;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public interface IJsonCommandGenerator<T> where T : class, IHandleCommands
    {
        JsonCommandGenerator<T> For(Action<T> action) ;
        string ToJson();
    }
}