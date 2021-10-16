using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Models.Data;
using BackendOdontoApp.API.Models.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckDentalClinicsAsync();
            await CheckCancellationReasonsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckSpecialitiesAsync();
        }

        private async Task CheckSpecialitiesAsync()
        {
            if (!_context.Specialities.Any())
            {
                _context.Specialities.Add(new Speciality { Name = "Odontopediatria" });
                _context.Specialities.Add(new Speciality { Name = "Cirugia" });
                _context.Specialities.Add(new Speciality { Name = "Endondoncia" });
                _context.Specialities.Add(new Speciality { Name = "Ortodoncia" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Name = "Limpieza Profunda", Price = 150000 });
                _context.Procedures.Add(new Procedure { Name = "Valoración", Price = 10000 });
                _context.Procedures.Add(new Procedure { Name = "Remoción de caries", Price = 70000 });
                _context.Procedures.Add(new Procedure { Name = "Elaboración de carillas", Price = 80000 });
                _context.Procedures.Add(new Procedure { Name = "Toma de impresión", Price = 54000 });
                _context.Procedures.Add(new Procedure { Name = "Blanqueamiento laser", Price = 160000 });
                _context.Procedures.Add(new Procedure { Name = "Blanqueamiento en cubetas", Price = 100000 });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula Ciudadnia", Abreviature = "c.c" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula Extranjeria", Abreviature = "c.e" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte", Abreviature = "pas" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Indentidad", Abreviature = "t.i" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCancellationReasonsAsync()
        {
            if (!_context.CancellationReasons.Any())
            {
                _context.CancellationReasons.Add(new CancellationReason { Description = "Sin permiso laboral" });
                _context.CancellationReasons.Add(new CancellationReason { Description = "Imprevisto personal" });
                _context.CancellationReasons.Add(new CancellationReason { Description = "Cambio de precio en procedimiento" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDentalClinicsAsync()
        {
            if (!_context.DentalClinics.Any())
            {
                _context.DentalClinics.Add(new DentalClinic { Name = "San Vicente" });
                _context.DentalClinics.Add(new DentalClinic { Name = "San Javier" });
                _context.DentalClinics.Add(new DentalClinic { Name = "Azul" });
                _context.DentalClinics.Add(new DentalClinic { Name = "La playa" });
                _context.DentalClinics.Add(new DentalClinic { Name = "San Fernando" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
