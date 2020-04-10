using BusinessLayer.Infrastructure;
using BusinessLayer.Interface;
using DataAccessLayer.DTO;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;
using System.Threading.Tasks;


namespace StartCourse.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> AuthenticationManager;
        public AccountController(IUserService userService, SignInManager<User> authenticationManager)
        {
            _userService = userService;
            AuthenticationManager = authenticationManager;
        }

      
        public IActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                bool auth = await _userService.Authenticate(userDto);
                if (!auth)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    return RedirectToAction("Index", "Profile");
                }

            }
            return View(model);
        }

     
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    Email = model.Email,
                    UserName = model.Username,
                    Birthday = model.Birthday,
                    Phone = model.Phone,
                    Role = "user",
                    Gender = model.Gender,
                    Password = model.Password
                };
                OperationDetails operationDetails = await _userService.Create(userDTO);

                if (operationDetails.Succedeed)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await AuthenticationManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
