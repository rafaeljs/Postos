using Contexto;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Postos.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostosBusiness _postosBusiness;
        public HomeController()
        {
            _postosBusiness = new PostosBusiness();
        }
        public ActionResult Index()
        {
            var retorno = _postosBusiness.BuscarPostosMaisBaratos();
            return View(retorno);
        }

        public ActionResult Postos()
        {
            return View();
        }
        public ActionResult EditarPosto()
        {
            var retorno = _postosBusiness.BuscarTodosPostos();
            return View(retorno);
        }
        public ActionResult Mapa()
        {
            var retorno = _postosBusiness.BuscarTodosPostos();
            return View(retorno);
        }
        public ActionResult BuscarPosto(int PostoId)
        {
            try
            {
                var posto = _postosBusiness.BuscarPostoPorId(PostoId);
                return Json(new
                {
                    Status = "Ok",
                    posto.Nome,
                    posto.Latitude,
                    posto.Longitude,
                    gc = posto.PostoCombustivel.ElementAt(0).Preco.ToString().Replace('.',','),
                    ga = posto.PostoCombustivel.ElementAt(1).Preco.ToString().Replace('.',','),
                    ec = posto.PostoCombustivel.ElementAt(2).Preco.ToString().Replace('.',','),
                    ea = posto.PostoCombustivel.ElementAt(3).Preco.ToString().Replace('.', ','),
                });
            }
            catch (Exception e)
            {
                return Json(new { Status = "Erro", Mensagem = e.Message });
            }
           
        }
        public ActionResult SalvarEditarPosto(int PostoId, string Nome, decimal gasComum, decimal gasAdit, decimal etanolComum, decimal etanolAdit, string latitude, string longitude)
        {
            try
            {
                var Latitude = Convert.ToDecimal(latitude.Replace('.', ','));
                var Longitude = Convert.ToDecimal(longitude.Replace('.', ','));
                _postosBusiness.EditarPosto(PostoId,Nome, gasComum, gasAdit, etanolComum, etanolAdit, Latitude, Longitude);
                return Json(new { Status = "Ok" });
            }
            catch (Exception e)
            {
                return Json(new { Status = "Erro", Mensagem = e.Message });
            }
        }
        public ActionResult ExcluirPosto(int PostoId)
        {
            try
            {
                _postosBusiness.ExcluirPosto(PostoId);
                return Json(new { Status = "Ok" });
            }
            catch (Exception e)
            {
                return Json(new { Status = "Erro", Mensagem = e.Message });
            }
        }
        public ActionResult CadastrarPosto(string Nome, decimal gasComum,decimal gasAdit, decimal etanolComum, decimal etanolAdit, string latitude, string longitude)
        {
            try
            {
                var Latitude = Convert.ToDecimal(latitude.Replace('.', ','));
                var Longitude = Convert.ToDecimal(longitude.Replace('.', ','));
                _postosBusiness.CriarPosto(Nome, gasComum, gasAdit, etanolComum, etanolAdit, Latitude, Longitude);
                return Json(new {Status = "Ok"  });
            }
            catch(Exception e)
            {
                return Json(new { Status = "Erro", Mensagem = e.Message });
            }
        }
    }
}