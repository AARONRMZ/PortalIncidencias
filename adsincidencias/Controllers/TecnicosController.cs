using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adsincidencias.entities.Repositories;
using adsincidencias.entities;
using adsincidencias.Common;
using adsincidencias.ViewModels;
using System.Data;
namespace adsincidencias.Controllers
{
    public class TecnicosController : Controller
    {
        adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();

        // GET: Tecnicos
        public ActionResult Tecnicos()
        {
            return View();
        }


        public JsonResult DataTableTecnicos(jQueryDataTableParamModel param)
        {
            TecnicosRepository TR = new TecnicosRepository();
            ProductosRepository PR = new ProductosRepository();

            var todosTecnicos = TR.GetAllTecnicos();
            var todosTiposProductos = PR.GetAllTiposProductos();


            IEnumerable<Tecnico> filterTecnicos;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filterTecnicos = TR.GetAllTecnicos()
                    .Where(t => t.tecNombre.Contains(param.sSearch));
            }
            else
            {
                filterTecnicos = todosTecnicos;
            }

            var displayedTecnicos = filterTecnicos.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from t in displayedTecnicos
                         join tp in todosTiposProductos on t.tecProducto equals tp.tipoProdID
                         select new[] {t.tecID.ToString(),t.tecNombre,t.tecNombreUsusario,t.tecCorreo,tp.tipoProdDescripcion};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = todosTecnicos.Count(),
                iTotalDisplayRecords = filterTecnicos.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }

        public ActionResult Crear()
        {
            TecnicoViewModel tecnicoVM = new TecnicoViewModel();
            tecnicoVM.TiposProductos = new SelectList(db.TiposProductos, "tipoProdID", "tipoProdDescripcion");
            return View(tecnicoVM);
        }

        [HttpPost]
        public ActionResult Crear(TecnicoViewModel tecnicoVM)
        {
            tecnicoVM.TiposProductos = new SelectList(db.TiposProductos, "tipoProdID", "tipoProdDescripcion");
            if (tecnicoVM.Contrasena1==tecnicoVM.Contrasena2)
            {
                Tecnico tecnico = new Tecnico();
                tecnico.tecProducto = tecnicoVM.TipoProd;
                tecnico.tecApPaterno = tecnicoVM.Paterno;
                tecnico.tecApMaterno = tecnicoVM.Materno;
                tecnico.tecNombre = tecnicoVM.Nombre;
                tecnico.tecNombreUsusario = "tecProvisional";
                tecnico.tecContrasena = tecnicoVM.Contrasena1;
                tecnico.tecRol = 3;
                tecnico.tecCorreo = tecnicoVM.Correo;
                try
                {
                    db.Tecnicos.AddObject(tecnico);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Msg = "Técnico creado correctamente";
                    return View(tecnicoVM);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View(tecnicoVM);
                }
            }else
            {
                ViewBag.Error = "Las contraseñas no coinciden, verifique por favor";
                return View(tecnicoVM);
            }
             
        }

        public ActionResult Editar(int idTecnico)
        {
            TecnicoViewModel tecnicoVM = new TecnicoViewModel();
            tecnicoVM.TiposProductos = new SelectList(db.TiposProductos, "tipoProdID", "tipoProdDescripcion");

            Tecnico tecnico = db.Tecnicos.Single(t => t.tecID == idTecnico);
            tecnicoVM.Id = tecnico.tecID;
            tecnicoVM.TipoProd = tecnico.tecProducto;
            tecnicoVM.Paterno = tecnico.tecApPaterno;
            tecnicoVM.Materno = tecnico.tecApMaterno;
            tecnicoVM.Nombre = tecnico.tecNombre;
            tecnicoVM.Contrasena1 = tecnico.tecContrasena;
            tecnicoVM.Contrasena2 = tecnico.tecContrasena;
            tecnicoVM.Correo = tecnico.tecCorreo;

            return View(tecnicoVM);
        }

        [HttpPost]
        public ActionResult Editar(TecnicoViewModel tecnicoVM)
        {
            tecnicoVM.TiposProductos = new SelectList(db.TiposProductos, "tipoProdID", "tipoProdDescripcion");
            if (tecnicoVM.Contrasena1 == tecnicoVM.Contrasena2)
            {
                Tecnico tecnico = new Tecnico();
                tecnico.tecID = tecnicoVM.Id;
                tecnico.tecProducto = tecnicoVM.TipoProd;
                tecnico.tecApPaterno = tecnicoVM.Paterno;
                tecnico.tecApMaterno = tecnicoVM.Materno;
                tecnico.tecNombre = tecnicoVM.Nombre;
                tecnico.tecNombreUsusario = "tecProvisional";
                tecnico.tecContrasena = tecnicoVM.Contrasena1;
                tecnico.tecRol = 3;
                tecnico.tecCorreo = tecnicoVM.Correo;
                try
                {
                    db.Tecnicos.Attach(tecnico);
                    db.ObjectStateManager.ChangeObjectState(tecnico, EntityState.Modified);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Msg = "Técnico editado correctamente";
                    return View(tecnicoVM);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View(tecnicoVM);
                }
            }
            else
            {
                ViewBag.Error = "Las contraseñas no coinciden, verifique por favor";
                return View(tecnicoVM);
            }

        }

    }
}