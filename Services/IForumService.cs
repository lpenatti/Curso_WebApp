using Projeto02.AppWebForum.Models;

namespace Projeto02.AppWebForum.Services
{
    public interface IForumService
    {
        Task<IEnumerable<ForumClient>> ListarForuns();
    }
}
