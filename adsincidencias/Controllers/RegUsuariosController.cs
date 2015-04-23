using adsincidencias.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using adsincidencias.Common;
using adsincidencias.ViewModels;
using adsincidencias.entities.Repositories;
namespace adsincidencias.Controllers
{
    public class RegUsuariosController : Controller
    {

        
        #region Contexto
        adsincidencias.entities.adsincidenciasDBModelContainer db = new adsincidenciasDBModelContainer();
        #endregion

        #region Usuarios
        public ActionResult Usuarios()
        {
            return View();
        }


        public JsonResult DataTableUsuarios(jQueryDataTableParamModel param)
        {
            UsuariosRepository UR = new UsuariosRepository();
            RolesRepository RR = new RolesRepository();
            EmpresasRepository ER = new EmpresasRepository();

            var todosUsuarios = UR.GetAllUsuarios();
            var todosRoles = RR.GetAllRoles();
            var todasEmpresas = ER.GetAllEmpresas();

            IEnumerable<Usuario> filterUsuarios;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filterUsuarios = UR.GetAllUsuarios()
                    .Where(u => u.usrNombre.Contains(param.sSearch)
                        || u.usrNombreUsusario.Contains(param.sSearch));
            }
            else
            {
                filterUsuarios = todosUsuarios;
            }

            var displayedUsuarios = filterUsuarios.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from u in displayedUsuarios
                         join r in todosRoles on u.usrRol equals r.rolID
                         join e in todasEmpresas on u.usrEmpresaID equals e.empID
                         select new[] {u.Id.ToString(),u.usrNombre,u.usrNombreUsusario,
                         u.usrCorreo,r.rolDescripcion,e.empNombre};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = todosUsuarios.Count(),
                iTotalDisplayRecords = filterUsuarios.Count(),
                aaData = result
            },
             JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Crear
        //Crear Usuario
        public ActionResult RegistrarUsuarios()
        {
            UsuarioViewModel ViewModelUsuario;
            ViewBag.userSession = Session["VarSess"];
            ViewModelUsuario = new UsuarioViewModel();
            ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
            ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
            
            return View(ViewModelUsuario);
        }

        [HttpPost]
        public ActionResult RegistrarUsuarios(UsuarioViewModel ViewModelUsuario)
        {
            Usuario usuario = new Usuario();
            ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
            ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
            
            if (ViewModelUsuario.Nombre == null || ViewModelUsuario.Paterno == null || ViewModelUsuario.Materno == null || ViewModelUsuario.Correo == null || ViewModelUsuario.Contrasena1 == null)
            {
                
                return View(ViewModelUsuario);
            }
            else if (ViewModelUsuario.Contrasena1 != ViewModelUsuario.Contrasena2)
            {
                ViewBag.ErrorPass = "Las contraseñas no coinciden, verifique por favor.";
                return View(ViewModelUsuario);
            }else
            {
                try
                {
           
                    usuario.usrNombreUsusario = "Carlos001";
                    usuario.usrNombre = ViewModelUsuario.Nombre;
                    usuario.usrApPaterno = ViewModelUsuario.Paterno;
                    usuario.usrApMaterno = ViewModelUsuario.Materno;
                    usuario.usrCorreo = ViewModelUsuario.Correo;
                    usuario.usrEmpresaID = ViewModelUsuario.Empresa;
                    usuario.usrContrasena = ViewModelUsuario.Contrasena1;
                    usuario.usrRol = ViewModelUsuario.Rol;
                    db.Usuarios.AddObject(usuario);
                    db.SaveChanges();
                    
                    ViewModelUsuario = new UsuarioViewModel();
                    ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
                    ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
                    
                   ModelState.Clear();
                   ViewBag.Msg = "El usuario se ha registrado correctamente.";
                }catch(Exception e)
                {
                    
                    return View(e.Message);
                }

            }

            return View(ViewModelUsuario);

        }
        #endregion  

        public ActionResult EditarUsuarios(int IdUsuario)
        {
            UsuarioViewModel ViewModelUsuario;
            ViewBag.userSession = Session["VarSess"];
            //ViewBag.Empresas = new SelectList(db.Empresas.ToList(), "empID", "empNombre");
            ViewModelUsuario = new UsuarioViewModel();
            ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
            ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
            
            Usuario usuario = db.Usuarios.Single(u =>u.Id==IdUsuario);
            ViewModelUsuario.Id = usuario.Id;
            ViewModelUsuario.Nombre = usuario.usrNombre;
            ViewModelUsuario.Paterno = usuario.usrApPaterno;
            ViewModelUsuario.Materno = usuario.usrApMaterno;
            ViewModelUsuario.Correo = usuario.usrCorreo;
            ViewModelUsuario.Empresa = usuario.usrEmpresaID;
            ViewModelUsuario.Rol = usuario.usrRol;
            ViewModelUsuario.Contrasena1 = usuario.usrContrasena;
            ViewModelUsuario.Contrasena2 = usuario.usrContrasena;
            
            return View(ViewModelUsuario);
        }

        [HttpPost]
        public ActionResult EditarUsuarios(UsuarioViewModel ViewModelUsuario)
        {
            Usuario usuario = new Usuario();
            ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
            ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
            
            if (ViewModelUsuario.Nombre == null || ViewModelUsuario.Paterno == null || ViewModelUsuario.Materno == null || ViewModelUsuario.Correo == null || ViewModelUsuario.Contrasena1 == null)
            {

                return View(ViewModelUsuario);
            }
            else if (ViewModelUsuario.Contrasena1 != ViewModelUsuario.Contrasena2)
            {
                ViewBag.ErrorPass = "Las contraseñas no coinciden, verifique por favor.";
                return View(ViewModelUsuario);
            }
            else
            {
                try
                {

                    usuario.Id = ViewModelUsuario.Id;
                    usuario.usrNombreUsusario = "Carlos001";
                    usuario.usrNombre = ViewModelUsuario.Nombre;
                    usuario.usrApPaterno = ViewModelUsuario.Paterno;
                    usuario.usrApMaterno = ViewModelUsuario.Materno;
                    usuario.usrCorreo = ViewModelUsuario.Correo;
                    usuario.usrEmpresaID = ViewModelUsuario.Empresa;
                    usuario.usrContrasena = ViewModelUsuario.Contrasena1;
                    usuario.usrRol = ViewModelUsuario.Rol;
                    db.Usuarios.Attach(usuario);
                    db.ObjectStateManager.ChangeObjectState(usuario,EntityState.Modified);
                    db.SaveChanges();
                    
                    ViewModelUsuario = new UsuarioViewModel();
                    ViewModelUsuario.Empresas = new SelectList(db.Empresas, "empID", "empNombre");
                    ViewModelUsuario.Roles = new SelectList(db.RolesUsuarios, "rolID", "rolDescripcion");
                    
                    
                    ModelState.Clear();
                    ViewBag.Msg = "El usuario se ha modificado correctamente.";
                }
                catch (Exception e)
                {

                    return View(e.Message);
                }

            }

            return View(ViewModelUsuario);

        }
    }


    }

