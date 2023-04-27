using Microsoft.EntityFrameworkCore;
using PracticaEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDAL.cs
{
    public class UsuarioDAL
    {
        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Add(pUsuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var usuario = await bdContexto.usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                usuario.Nombre = pUsuario.Nombre;
                usuario.Apellido = pUsuario.Apellido;
                usuario.RolId = pUsuario.RolId;
                usuario.Correo = pUsuario.Correo;
                usuario.Password = pUsuario.Password;
                bdContexto.Update(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var usuario = await bdContexto.usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                bdContexto.usuarios.Remove(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContexto = new ContextoBD())
            {
                usuario = await bdContexto.usuarios.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
            }
            return usuario;
        }

        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new ContextoBD())
            {
                usuarios = await bdContexto.usuarios.ToListAsync();
            }
            return usuarios;
        }
        internal static IQueryable<Usuario> QuerySelect(IQueryable<Usuario> pQuery, Usuario pUsuario)
        {
            if (pUsuario.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pUsuario.Id);

            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));

            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));
            if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pUsuario.Apellido));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pUsuario.top_aux > 0)
                pQuery = pQuery.Take(pUsuario.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.usuarios.AsQueryable();
                select = QuerySelect(select, pUsuario);
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        public static async Task<List<Usuario>> BuscarIncluirRolesAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.usuarios.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
    }
}
