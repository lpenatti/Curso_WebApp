namespace Projeto02.AppWebForum.Models
{
    public class UsuarioClient
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public ICollection<ComentarioClient>? Comentarios { get; set; }
    }
}
