using Projeto02.AppWebForum.Models;

namespace Projeto02.AppWebForum.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioClient>> ListarUsuarios();
    }
}
