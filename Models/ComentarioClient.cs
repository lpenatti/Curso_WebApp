using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto02.AppWebForum.Models
{
    public class ComentarioClient
    {
        public int Id { get; set; }

        [DisplayName("Escolher o fórum:")]
        [Required]
        public int ForumId { get; set; }

        [DisplayName("Escolher o usuário:")]
        public int UsuarioId { get; set; }

        [DisplayName("Comentário:")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "O Comentário é obrigatório")]
        [StringLength(500, MinimumLength = 5, 
            ErrorMessage = "O comentário deve ter entre 5 e 500 caracteres.")]
        public string? ComentarioInfo { get; set; }
        public DateTime Data { get; set; }

        public ForumClient? Forum { get; set; }
        public UsuarioClient? Usuario { get; set; }
    }
}
