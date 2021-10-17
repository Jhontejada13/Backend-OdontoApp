using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Helpers;
using BackendOdontoApp.API.Models.Data;
using BackendOdontoApp.API.Models.Data.Entities;
using BackendOdontoApp.Common.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckDentalClinicsAsync();
            await CheckCancellationReasonsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckSpecialitiesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Maria", "Camila", "Quintana", "Jaramillo", "camilaquintana@yopmail.com", "3105318279", "Avenida siempre viva", UserType.Odontologo);
            await CheckUserAsync("1010", "Leidy", "Andrea", "Tabares", "Nea", "laidytabares@yopmail.com", "3105318279", "Avenida siempre viva", UserType.Odontologo);
            await CheckUserAsync("2020", "Jhon", "William", "Tejada", "Durango", "jhontejada@yopmail.com", "3105318279", "Avenida siempre viva", UserType.Paciente);
            await CheckUserAsync("2020", "Manuel", "Andres", "Medrano", "Cacao", "manuelmedrano@yopmail.com", "3105318279", "Avenida siempre viva", UserType.Paciente);
            await CheckUserAsync("2020", "Luisa", "Fernanda", "Capaz", "DeTodo", "lusacapaz@yopmail.com", "3105318279", "Avenida siempre viva", UserType.Paciente);


        }

        private async Task CheckUserAsync(string document, string firstName, string secondName, string firstLastName, string secondLastName, string email, string phoneNumber, 
            string addrees, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = addrees,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula de ciudadanía"),
                    Email = email,
                    FirstName = firstName,
                    SecondName = secondName,
                    FirstLastName = firstLastName,
                    SecondLastName = secondLastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                //string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                //await _userHelper.ConfirmEmailAsync(user, token);

            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Odontologo.ToString());
            await _userHelper.CheckRoleAsync(UserType.Paciente.ToString());
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
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula de ciudadanía", Abreviature = "c.c" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula Extranjería", Abreviature = "c.e" });
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
