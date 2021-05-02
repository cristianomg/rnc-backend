using System.Threading.Tasks;

namespace Domain.Interfaces.Util
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
