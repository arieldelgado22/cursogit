using WebApiUsuario.Models;

namespace WebApiUsuario.Data
{
    public class UsuarioRepository
    {
        private static List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Juan Perez", CorreoElectronico = "juan@gmail.com", Contraseña = "1234", FechaRegistro = DateTime.Now }
        };

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void CrearUsuario(Usuario usuario)
        {
            usuario.Id = _usuarios.Max(u => u.Id) + 1; // Asigna un Id Unico
            _usuarios.Add(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)

        {
            // Le paso un usuario que supuestamente existe para actualizar datos
            // Primero busco en que posicion de la lista esta ese usuario para modificar los datos
            // Entonces creo una variable donde lo voy a buscar por usuario.id
            // pregunto si la variable esta vacia es que no encontro el usuario
            // si encontro el usuario a esa variable que tengo la modifico con los datos
            //ingresados por parametros con usuario

            var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);

            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.CorreoElectronico = usuario.CorreoElectronico;
                usuarioExistente.Contraseña = usuario.Contraseña;
            }


        }

        public void EliminarUsuario(int id)
        // creo una var llamada usuaria recorro buscando el id en la lista con el metodo first o dfault

        // pregunto si el usuario es distinto de null, si es le paso la variable usuario que cree para q elimine de la lista

        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }

        }

    }
}
