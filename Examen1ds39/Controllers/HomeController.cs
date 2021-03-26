using Examen1ds39.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1ds39.Controllers
{
    public class HomeController : Controller
    {
        DAOCliente daoCli = new DAOCliente();
        DAOUsuario daoU = new DAOUsuario();

        public ActionResult Index()
        {
            putVariables();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A cerca del sitio...";
            putVariables();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Di Hola!";
            putVariables();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Identificate";

            return View();
        }
        [HttpPost]
        public ActionResult Login(DTOLogin l)
        {
            System.Web.HttpContext.Current.Session["isAuth"] = "false";
            if (ModelState.IsValid)
            {
                Usuario u = daoU.findOne(l.nombre, l.contra);
                if (u == null)
                {
                    putVariables();
                    return View();
                }
                else
                {
                    System.Web.HttpContext.Current.Session["nivel"] = u.nivel_usuario.ToLower().Trim();
                    System.Web.HttpContext.Current.Session["isAuth"] = "true";
                    putVariables();
                    return RedirectToAction("Cliente");
                }
            }

            putVariables();
            return View();
        }
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Clear();
            ViewData.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Cliente()
        {
            List<Cliente> lista = new List<Cliente>();
            if (System.Web.HttpContext.Current.Session["nivel"] == null || string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["nivel"].ToString()))
            {
                return RedirectToAction("Login");
            }
            if (TempData["filter"] == null || string.IsNullOrEmpty(TempData["filter"].ToString()))
            {
                lista = daoCli.findAll();
            }
            else
            {
                lista = (List<Cliente>)TempData["lista"];
            }

            ViewBag.lista = lista;
            putVariables();
            return View();
        }
        [HttpPost]
        public ActionResult Cliente(Cliente cli)
        {
            ViewBag.save = "false";
            if (ModelState.IsValid)
            {
                if (daoCli.save(cli)) ViewBag.save = "true";
            }

            List<Cliente> lista = daoCli.findAll();
            ViewBag.lista = lista;
            putVariables();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCliente(Cliente cli)
        {
            TempData["update"] = "false";
            if (ModelState.IsValid && cli.cod_cliente > 0)
            {
                if (daoCli.update(cli)) TempData["update"] = "true";
            }
            return RedirectToAction("Cliente");
        }


        public ActionResult UpdateInit(int cod_cliente)
        {
            return RedirectToAction("Cliente");
        }

        public ActionResult Search(string opciones, string valor)
        {
            try
            {

                List<Cliente> lista = new List<Cliente>();
                switch (opciones)
                {
                    case "cod_cliente":
                        int param = int.Parse(valor);
                        Cliente cli = daoCli.findByCod_cliente(param);
                        lista.Add(cli);
                        break;
                    case "nombres":
                        lista = daoCli.findByNombresLike(valor);

                        break;
                    case "apellidos":
                        lista = daoCli.findByApellidosLike(valor);
                        break;
                    case "dui":
                        lista = daoCli.findByDUI(valor);
                        break;
                    case "direccion":
                        lista = daoCli.findByDireccionLike(valor);
                        break;
                    case "nit":
                        lista = daoCli.findByNIT(valor);
                        break;
                    default:
                        throw new Exception();
                }
                TempData["lista"] = lista;
                TempData["filter"] = "true";
            }
            catch (Exception e)
            {
                //nothing...
            }

            return RedirectToAction("Cliente");
        }


        public ActionResult DeleteCliente(int cod_cliente)
        {
            TempData["delete"] = "false";
            String nivel = System.Web.HttpContext.Current.Session["nivel"].ToString();
            if (nivel.Equals("administrador"))
            {
                if (daoCli.delete(cod_cliente)) TempData["delete"] = "true";
            }


            return RedirectToAction("Cliente");
        }

        public ActionResult DeleteInit(int cod_cliente)
        {
            ViewBag.deleting = cod_cliente;
            return View();
        }
        private void putVariables()
        {
            ViewBag.nivel = System.Web.HttpContext.Current.Session["nivel"];
            ViewBag.isAuth = System.Web.HttpContext.Current.Session["isAuth"];
        }
    }
}