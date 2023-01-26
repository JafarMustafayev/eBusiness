using eBusiness.Areas.Admin.ViewModel;
using eBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<IActionResult> CreateUserRole()
        {

            AppUser user1 = new AppUser
            {
                UserName= "SuperAdmin",
                FullName = "Jafar Mustafayev"
            };

            var res= await _userManager.CreateAsync(user1,"Test-123");

            return Ok(res);
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("Created");

        }

        public async Task<IActionResult> AddRole()
        {
            AppUser user = await _userManager.FindByNameAsync("SuperAdmin");
            AppUser user2 = await _userManager.FindByNameAsync("Admin");

            await _userManager.AddToRoleAsync(user, "SuperAdmin");
            await _userManager.AddToRoleAsync(user2, "Admin");

            return Ok("Added");

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        
        {
            if(!ModelState.IsValid) { return View(); }

            AppUser user = await _userManager.FindByNameAsync(model.UserName);

            if(user is null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }

            var res = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if(!res.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }


            return RedirectToAction("index", "dashboard");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        } 

    }
}
