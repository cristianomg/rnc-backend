using System.Threading.Tasks;

namespace _4Lab.Infrastructure.Charts
{
    public interface IRazorRender
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}