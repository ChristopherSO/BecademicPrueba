using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace BLL
{
    public class GestorAuth
    {
        private Usuario _usuarioActual;
        private IList<PermisoRol> _permisosDeUsuario;

        public GestorAuth() { _usuarioActual = new Usuario(); _permisosDeUsuario = new List<PermisoRol>(); }

        public bool validarIngreso(string correo, string clave)
        {
            _usuarioActual = new Usuario(); _permisosDeUsuario = new List<PermisoRol>();

            Usuario usuario = UsuarioRepository.Instance.GetByCorreoYContrasena(correo, clave);

            if (usuario.Id > 0)
            {
                _usuarioActual = usuario;

                IEnumerable<RolUsuario> roles = RolUsuarioRepository.Instance.GetRolesUsuario(usuario.Id);

                if (roles.ToArray().Length > 0)
                {
                    foreach (RolUsuario rol in roles)
                    {
                        IEnumerable<PermisoRol> listaDePermisos = PermisoRepositorio.Instance.GetPermisosRoles(rol.Id);
                        foreach (PermisoRol permiso in listaDePermisos)
                        {
                            _permisosDeUsuario.Add(permiso);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public Usuario UsuarioActual
        {
            get
            {
                return _usuarioActual;
            }
        }

        public IList<PermisoRol> PermisosDeUsuario
        {
            get
            {
                return _permisosDeUsuario;
            }
        }

        public bool tieneElPermiso(int idPermiso)
        {
            foreach (PermisoRol permiso in _permisosDeUsuario)
            {
                if (permiso.Id == idPermiso)
                {
                    return true;
                }
            }
            return false;
        }

        public void limpiar()
        {
            _usuarioActual = null;
            _permisosDeUsuario = null;
        }

    }
}
