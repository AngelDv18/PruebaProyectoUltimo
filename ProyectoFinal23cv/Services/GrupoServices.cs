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
    public class GrupoServices
    {
        public void AddGrupos(Grupos requs)
        {
            try
            {
                if (requs != null)
                {
                        using (var _context = new ApplicationDbContext())
                        {
                            Grupos queso = new Grupos();
                            queso.NombreGrupos = requs.NombreGrupos;

                            _context.Grupos.Add(queso);
                            _context.SaveChanges();
                        }
                    }
                }
            catch (Exception ex)
            {
                throw new Exception("error : " + ex.Message);
            }
        }
        public void EditGrupo(Grupos grupose)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(grupose).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar El Grupo: " + ex.Message);
            }
        }
        public void DeleteGrupo(Grupos clea)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Grupos GrupToDelete = _context.Grupos.Find(clea.PKGrupos);
                    if (GrupToDelete != null)
                    {
                        _context.Grupos.Remove(GrupToDelete);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Grupo: " + ex.Message);
            }
        }
        public List<Grupos> GetGrupos()
        {/*Include(g => g.PKGrupos).*/
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Grupos> grupoIds = _context.Grupos.ToList();
                    return grupoIds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sucedio un error: " + ex.Message);
            }
        }
        public Grupos GetGroupById(int gruId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Grupos grupt = _context.Grupos.FirstOrDefault(f => f.PKGrupos == gruId);
                    return grupt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
    }
}

