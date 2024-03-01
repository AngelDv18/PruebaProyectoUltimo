using Microsoft.EntityFrameworkCore;
using ProyectoFinal23cv.Context;
using ProyectoFinal23cv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;


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
                        chuleta.FkCarreras = requst.FkCarreras;
                        chuleta.FkGrupos = requst.FkGrupos;

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

        public List<Carreras> GetCarreraas()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Carreras> ca = _context.Carreras.ToList();
                    return ca;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error " + ex.Message);
            }
        }

        public List<Grupos> GetGroups()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Grupos> gu = _context.Grupos.ToList();
                    return gu;
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

        public List<Maestros> BuscarMaestros(string filtro)
        {
            using (var _context = new ApplicationDbContext())
            {
                return _context.Maestros
                    //.Include(m => m.FkCarreras) // Incluye la relación con Carrera
                    //                    .Include(m => m.FkGrupos)   // Incluye la relación con Grupo
                                        .Where(m => m.PkMaestros.Equals(filtro) ||
                                       m.NombreMaestros.Contains(filtro) ||
                                       m.Especialidad.Contains(filtro))
                                        .ToList();

                //return _context.Maestros.Where(m => m.PkMaestros.Equals(filtro) ||
                //m.NombreMaestros.Contains(filtro) || m.Especialidad.Contains(filtro)).ToList();
            }
        }
        public async void Examen ()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://batboiko-exam-simulator-v1.p.rapidapi.com/store"),
                Headers =
    {
        { "X-RapidAPI-Key", "3a1ec54606mshccec2b330a113dap136c02jsn966f27504bdb" },
        { "X-RapidAPI-Host", "batboiko-exam-simulator-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}