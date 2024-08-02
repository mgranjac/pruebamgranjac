using prueba.dominio;
using prueba.dominio.aplicacion;
using prueba.dominio.entidades;
using prueba.dominio.repositorio;
using prueba.dominio.servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.aplicacion
{
    public class TareaAplicacion : BaseAplicacion<Tarea>, ITareaAplicacion
    {
        private readonly ITareaServicio _tareaServicio;
        private readonly ITareaRepositorio _tareaRepositorio;

        public TareaAplicacion(ITareaServicio tareaServicio,
            ITareaRepositorio tareaRepositorio,
            IUnitOfWork unitOfWork)
            : base(tareaServicio, tareaRepositorio, unitOfWork)
        {
            _tareaServicio = tareaServicio;
            _tareaRepositorio = tareaRepositorio;
        }
    }
}
