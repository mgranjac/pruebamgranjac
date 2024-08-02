using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prueba.backend.Controllers
{
    [RoutePrefix("api/prueba/Autenticar")]
    public class AutenticarController : ApiController
    {
        const string USUARIO = "prueba";
        const string CONTRASENA = "Prueba123";
        [HttpPost]
        [Route("ValidarUsuario")]
        public IHttpActionResult ValidarInicioSesion(string usuario, string contrasena) 
        {
            try
            {
                if (usuario.Equals(USUARIO) && contrasena.Equals(CONTRASENA))
                    return Json(new { Usuario = usuario });
                else
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "Usuario/Contraseña incorrecto"));
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}