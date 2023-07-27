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
    class MaestrosServices
    {
        public void AddMaster(Maestros requst)
        {
            try
            {
                if (requst != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Maestros chuleta = new Maestros();
                        chuleta.NombreMaestros = requst.NombreMaestros;
                        chuleta.Especialidad = requst.Especialidad;
                        chuleta.FechasRegistrada = DateTime.Now;
                        chuleta.FkPapel = requst.FkPapel;

                        _context.Maestros.Add(chuleta);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public List<Maestros> GetMaster()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Maestros> master = new List<Maestros>();
                    master = _context.Maestros.Include(x => x.Papel).ToList();
                    return master;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
        public void EditMaster(Maestros mast)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(mast).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void DeleteMaster(Maestros cleams)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Maestros masterToDelete = _context.Maestros.Find(cleams.PkMaestros);
                    if (masterToDelete != null)
                    {
                        _context.Maestros.Remove(masterToDelete);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
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

        public Maestros GetMastersById(int mateId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Maestros maste = _context.Maestros.FirstOrDefault(u => u.PkMaestros == mateId);
                    return maste;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
    }
}