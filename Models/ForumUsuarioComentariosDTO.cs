namespace Projeto02.AppWebForum.Models
{
    public class ForumUsuarioComentariosDTO
    {
        public int IdComentario { get; set; }
        public int IdForum { get; set; }
        public int idUsuario { get; set; }
        public string? DescricaoForum { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataComentario { get; set; }
    }
}
