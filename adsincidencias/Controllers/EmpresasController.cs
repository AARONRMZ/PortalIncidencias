using adsincidencias.Common;
using adsincidencias.entities;
using adsincidencias.entities.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adsincidencias.Controllers
{
    public class EmpresasController : Controller
    {


        #region Contexto
        adsincidencias.entities.adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();
        #endregion



        public ActionResult Empresas()
        {
            return View();
        }

        public JsonResult DataTableEmpresas(jQueryDataTableParamModel param)
        {

            EmpresasRepository ER = new EmpresasRepository();

            var todasEmpresas = ER.GetAllEmpresas();

            IEnumerable<Empresa> filterEmpresa;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filterEmpresa = ER.GetAllEmpresas()
                    .Where(e => e.empNombre.Contains(param.sSearch));
            }
            else
            {
                filterEmpresa = todasEmpresas;
            }

            var displayedEmpresas = filterEmpresa.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from e in displayedEmpresas
                         select new[] { e.empID.ToString(), e.empNombre };


            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = todasEmpresas.Count(),
                iTotalDisplayRecords = filterEmpresa.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }


        #region Crear
        //Crear Usuario
        public ActionResult Crear()
        {
            ViewBag.userSession = Session["VarSess"];
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empresa empresa)
        {
            Usuario usuario = new Usuario();
            try
            {
                db.Empresas.AddObject(empresa);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Msg = "La empresa se ha creado correctamente.";
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

            return View();
        }




        #endregion

        public ActionResult Editar(int IdEmpresa)
        {
            Empresa empresa;
            try
            {
                empresa = db.Empresas.Single(e => e.empID == IdEmpresa);
            }  
             catch(Exception e)
            {

                return View(e.Message);
            }
            return View(empresa);
            
        }

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {

            try
            {
                db.Empresas.Attach(empresa);
                db.ObjectStateManager.ChangeObjectState(empresa, EntityState.Modified);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Msg = "La empresa se ha modificado correctamente.";
            }catch(Exception e)
            {
                return View(e.Message);
            }

            return View();
        }
    }

}