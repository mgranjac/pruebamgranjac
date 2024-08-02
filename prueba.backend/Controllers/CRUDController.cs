using prueba.backend.Models;
using prueba.dominio.aplicacion;
using prueba.dominio.entidades;
using prueba.ioc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace prueba.backend.Controllers
{
    [RoutePrefix("api/prueba/CRUD")]
    public class CRUDController : ApiController
    {
        private ITareaAplicacion _tareaAplicacion;
        public CRUDController() 
        { 
            _tareaAplicacion = IoC.GetInstance<ITareaAplicacion>();
        }

        [HttpPost]
        [Route("CrearTarea")]
        public IHttpActionResult Crear([FromBody] TareaDto tarea)
        {
            try
            {
                var tareaResult = new Tarea
                {
                    Titulo = tarea.Titulo,
                    Descripcion = tarea.Descripcion,
                    FechaCreacion = tarea.FechaCreacion,
                    FechaVencimiento = tarea.FechaVencimiento,
                    Completada = tarea.Completada
                };

                _tareaAplicacion.Add(tareaResult);
                _tareaAplicacion.Commit();

                return Json(new { TareaId = tareaResult.Id });
            }
            catch(Exception ex) 
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("ObtenerTarea")]
        public IHttpActionResult Obtener(int id)
        {
            try
            {
                var tarea = _tareaAplicacion.Get(id);

                if (tarea == null)
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "No existe tarea con el Id: " + id));

                var tareaResult = new TareaDto
                {
                    Id = tarea.Id,
                    Titulo = tarea.Titulo,
                    Descripcion = tarea.Descripcion,
                    FechaCreacion = tarea.FechaCreacion,
                    FechaVencimiento = tarea.FechaVencimiento,
                    Completada = tarea.Completada
                };

                return Json(tareaResult);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("ModificarTarea")]
        public IHttpActionResult Modificar([FromBody] TareaDto tarea)
        {
            try
            {
                var tareaResult = _tareaAplicacion.Get(tarea.Id);
                
                if(tareaResult == null)
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "No existe tarea con el Id: " + tarea.Id));

                tareaResult.Titulo = tarea.Titulo;
                    tareaResult.Descripcion = tarea.Descripcion;
                tareaResult.FechaCreacion = tarea.FechaCreacion;
                tareaResult.FechaVencimiento = tarea.FechaVencimiento;
                tareaResult.Completada = tarea.Completada;

                _tareaAplicacion.Update(tareaResult);
                _tareaAplicacion.Commit();

                return Json(new { TareaId = tareaResult.Id });
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("EliminarTarea")]
        public IHttpActionResult Eliminar(int id)
        {
            try
            {
                var tareaResult = _tareaAplicacion.Get(id);

                if (tareaResult == null)
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "No existe tarea con el Id: " + id));

                _tareaAplicacion.Delete(tareaResult);
                _tareaAplicacion.Commit();

                return Json(new { TareaId = tareaResult.Id });
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}