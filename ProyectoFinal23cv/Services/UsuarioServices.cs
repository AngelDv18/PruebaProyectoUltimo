using Microsoft.EntityFrameworkCore;
using ProyectoFinal23cv.Context;
using ProyectoFinal23cv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Services
{
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario pollo = new Usuario();
                        pollo.Nombre = request.Nombre;
                        pollo.UserName = request.UserName;
                        pollo.Password = request.Password;
                        pollo.FechaRegistro = DateTime.Now;
                        /*pollo.pkrol = request.fkrol*/
                        pollo.FkPapel = request.FkPapel;
                        _context.Usuarios.Add(pollo);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public void EditUser(Usuario usuario)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(usuario).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
            public void DeleteUser(Usuario clear)
            {
                 try
                 {
                      using (var _context = new ApplicationDbContext())
                      {
                        Usuario userToDelete = _context.Usuarios.Find(clear.PkUsuario);
                           if (userToDelete != null)
                           {
                              _context.Usuarios.Remove(userToDelete);
                               _context.SaveChanges();
                           }
                      }
                 }
                    catch (Exception ex)
                 {
                    throw new Exception("Error al eliminar el usuario: " + ex.Message);
                 }
            }
        public List<Usuario> GetUsers()
        {
                try
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        List<Usuario> usuarios = new List<Usuario>();
                        usuarios = _context.Usuarios.Include(x => x.Papel).ToList();
                        return usuarios;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
        public List<Papel> GetPapels()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Papel> papel = _context.Papel.ToList();
                    return papel;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
        public Usuario Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Papel).FirstOrDefault(x => x.UserName == UserName && x.Password == Password);

                    return usuario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Usuario GetUserById(int userId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.PkUsuario == userId);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
    }
}