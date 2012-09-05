namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public interface IJQueryCommands : IHandleCommands
    {
        void Html(string element, string html);
        void Text(string element, string text);
    }
}