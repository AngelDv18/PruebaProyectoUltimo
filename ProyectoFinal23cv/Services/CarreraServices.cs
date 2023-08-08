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
    public class CarreraServices
    {
        public void AddCarrera(Carreras requste)
        {
            try
            {
                if (requste != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Carreras carer = new Carreras();
                        carer.NombreCarreras = requste.NombreCarreras;

                        _context.Carreras.Add(carer);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error : " + ex.Message);
            }
        }
        public void EditCarrera(Carreras caer)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(caer).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar La Carrera: " + ex.Message);
            }
        }
        public void DeleteCarrera(Carreras cleams)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Carreras CarerToDelete = _context.Carreras.Find(cleams.PKCarreras);
                    if (CarerToDelete != null)
                    {
                        _context.Carreras.Remove(CarerToDelete);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Carrera: " + ex.Message);
            }
        }
        public List<Carreras> GetCarreras()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {/*.Select(c => c.PKCarreras)*/
                    List<Carreras> careIds = _context.Carreras.ToList();
                    return careIds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sucedio un error: " + ex.Message);
            }
        }
        public Carreras GetCarreraById(int caId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Carreras caere = _context.Carreras.FirstOrDefault(s => s.PKCarreras == caId);
                    return caere;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public List<Carreras> BuscarCarreras(string filtro)
        {
            using (var _context = new ApplicationDbContext())
            {
                return _context.Carreras.Where(c => c.PKCarreras.Equals(filtro) || c.NombreCarreras.Contains(filtro) ||
                                              c.NombreCarreras.Contains(filtro)).ToList();
            }
        }

    }
}