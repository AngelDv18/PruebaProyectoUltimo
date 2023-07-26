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
    class AlumnosServices
    {
        public void AddAlumn(Alumnos requet)
        {
            try
            {
                if (requet != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Alumnos alum = new Alumnos();
                        
                        alum.NombreAlumno = requet.NombreAlumno;
                        alum.ApellidoP = requet.ApellidoP;
                        alum.ApellidoM = requet.ApellidoM;
                        alum.Fechaqueregistro = requet.Fechaqueregistro;
                        alum.FkPapel = requet.FkPapel;

                        _context.Alumnos.Add(alum);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public void EditAlumn(Alumnos alum)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(alum).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar Alumno: " + ex.Message);
            }
        }
        public void DeletAlus(Alumnos cleam)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Alumnos AluToDelete = _context.Alumnos.Find(cleam.PkAlumno);
                    if (AluToDelete != null)
                    {
                        _context.Alumnos.Remove(AluToDelete);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Alumno: " + ex.Message);
            }
        }
        public List<Alumnos> GetAlumn()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Alumnos> Alu = new List<Alumnos>();
                    Alu = _context.Alumnos.Include(x => x.Papel).ToList();
                    return Alu;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
        public List<Papel> GetPapeles()
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
        public Alumnos GetUserByIdAlu(int alutId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Alumnos alu = _context.Alumnos.FirstOrDefault(u => u.PkAlumno == alutId);
                    return alu;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
    }
}