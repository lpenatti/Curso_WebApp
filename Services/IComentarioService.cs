using Projeto02.AppWebForum.Models;

namespace Projeto02.AppWebForum.Services
{
    public interface IComentarioService
    {
        Task Incluir(ComentarioClient comentario);
        Task<IEnumerable<ForumUsuarioComentariosDTO>> ListarComentariosLinq(int idForum);
    }
}
