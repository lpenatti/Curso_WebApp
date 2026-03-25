using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Projeto02.AppWebForum.Models;
using Projeto02.AppWebForum.Services;

namespace Projeto02.AppWebForum.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IUsuarioService _usuarioService;
        private readonly IComentarioService _comentarioService;

        public ComentariosController(
            IForumService forumService, 
            IUsuarioService usuarioService, 
            IComentarioService comentarioService)
        {
            _forumService = forumService;
            _usuarioService = usuarioService;
            _comentarioService = comentarioService;
        }

        


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cadastro()
        {
            ViewBag.Foruns = new SelectList(await _forumService.ListarForuns(), "Id", "Titulo");
            ViewBag.Usuarios = new SelectList(await _usuarioService.ListarUsuarios(), "Id", "Nome");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ComentarioClient comentario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await Cadastro();
                }
                comentario.Data = DateTime.Now;

                // incluir o comentário
                await _comentarioService.Incluir(comentario);

                return RedirectToAction("Cadastro");
                //return View("_Sucesso", "Comentário incluído com sucesso!");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarComentarios(int idForum)
        {
            try
            {
                ViewBag.Foruns = new SelectList(await _forumService.ListarForuns(), "Id", "Titulo");
                return View(await _comentarioService.ListarComentariosLinq(idForum));
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        public async Task<IActionResult> ListarPorForumLinqAjax(int idForum)
        {
            try
            {
                ViewBag.Foruns = new SelectList(await _forumService.ListarForuns(), "Id", "Descricao");

                if (idForum == 0)
                {
                    return View();
                }
                else
                {
                    var lista = await _comentarioService.ListarComentariosLinq(idForum);
                    return PartialView("_ListaComentarios", lista);
                }
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
    }
}
