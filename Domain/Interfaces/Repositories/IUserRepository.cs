using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEnrollment(string enrollment);
        IQueryable<User> ObterTodos();
        Task<User> AtivarCadastro(User userAut);
    }
}
