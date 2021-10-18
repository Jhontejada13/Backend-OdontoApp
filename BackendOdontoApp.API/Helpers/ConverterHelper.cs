using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Models;
using BackendOdontoApp.API.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
        {
            return new User
            {
                Address = model.Address,
                Document = model.Document,
                DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                ImageId = imageId,
                FirstLastName = model.FirstLastName,
                SecondLastName = model.SecondLastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                UserType = model.UserType,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                DocumentTypeId = user.DocumentType.Id,
                DocumentTypes = _combosHelper.GetComboDocumentsTypes(),
                SpecialityId = user.Speciality.Id,
                Specialities = _combosHelper.GetComboSpecialities(),
                DentalClinicId = user.DentalClinic.Id,
                DentalClinics = _combosHelper.GetComboDentalClinics(),
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Id = user.Id,
                ImageId = user.ImageId,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }
    }
}
