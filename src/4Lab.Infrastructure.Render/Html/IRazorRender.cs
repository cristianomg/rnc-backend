using System.Threading.Tasks;

namespace _4Lab.Infrastructure.Render.Html
{
    public interface IRazorRender
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}