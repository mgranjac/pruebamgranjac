using prueba.dominio.repositorio;

namespace prueba.dominio.servicio
{
    public class TareaServicio : ITareaServicio
    {
        private readonly ITareaRepositorio _tareaRepositorio;
        public TareaServicio(ITareaRepositorio tareaRepositorio)
        {
            _tareaRepositorio = tareaRepositorio;
        }
    }
}
