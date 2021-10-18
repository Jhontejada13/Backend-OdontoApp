using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Helpers;
using BackendOdontoApp.API.Models;
using BackendOdontoApp.API.Models.Data;
using BackendOdontoApp.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Controllers
{
    [Authorize(Roles = "Odontologo")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;

        public UsersController(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper, ICombosHelper combosHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(x => x.DocumentType)
                .Include(x => x.DentalClinic)
                .Where(x => x.UserType == UserType.Paciente)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel
            {
                DocumentTypes = _combosHelper.GetComboDocumentsTypes(),
                Specialities = _combosHelper.GetComboSpecialities(),
                DentalClinics = _combosHelper.GetComboDentalClinics()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                User user = await _converterHelper.ToUserAsync(model, imageId, true);
                user.UserType = UserType.Paciente;
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());

                //string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                //string tokenLink = Url.Action("ConfirmEmail", "Account", new
                //{
                //    userid = user.Id,
                //    token = myToken
                //}, protocol: HttpContext.Request.Scheme);

                //Response response = _mailHelper.SendEmail(model.Email, "Vehicles - Confirmación de cuenta", $"<h1>Vehicles - Confirmación de cuenta</h1>" +
                //    $"Para habilitar el usuario, " +
                //    $"por favor hacer clic en el siguiente enlace: </br></br><a href = \"{tokenLink}\">Confirmar Email</a>");

                return RedirectToAction(nameof(Index));
            }

            model.DocumentTypes = _combosHelper.GetComboDocumentsTypes();
            return View(model);
        }

        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return NotFound();
        //    }

        //    User user = await _userHelper.GetUserAsync(Guid.Parse(id));
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    UserViewModel model = _convertHelper.ToUserViewModel(user);

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(UserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        Guid imageId = model.ImageId;

        //        if (model.ImageFile != null)
        //        {
        //            imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
        //        }

        //        User user = await _convertHelper.ToUserAsync(model, imageId, false);

        //        await _userHelper.UpdateUserAsync(user);
        //        return RedirectToAction(nameof(Index));

        //    }

        //    model.DocumentTypes = _combosHerlper.GetCombosDocumentsType();
        //    return View(model);
        //}

        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return NotFound();
        //    }

        //    User user = await _userHelper.GetUserAsync(Guid.Parse(id));

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    await _blobHelper.DeleteBlobAsync(user.ImageId, "users");
        //    await _userHelper.DeleteUserAsync(user);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
