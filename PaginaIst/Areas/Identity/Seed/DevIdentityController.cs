using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PaginaIst.Controllers
    {
    [Route ( "dev/identity" )]
    public class DevIdentityController : Controller
        {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public DevIdentityController ( UserManager<IdentityUser> userManager , IWebHostEnvironment env )
            {
            _userManager = userManager;
            _env = env;
            }

        [HttpGet ( "reset-webmaster" )]
        public async Task<IActionResult> ResetWebmaster ()
            {
            // ✅ Seguridad: solo permitir en Development
            if ( !_env.IsDevelopment ( ) )
                return NotFound ( );

            var email = "webmaster@ist-internacional.com.co";
            var newPassword = "I$t12345";

            var user = await _userManager.FindByEmailAsync(email);
            if ( user == null )
                return Content ( "No existe el usuario webmaster." );

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if ( !result.Succeeded )
                return Content ( string.Join ( "\n" , result.Errors.Select ( e => $"{e.Code}: {e.Description}" ) ) );

            return Content ( $"OK. Contraseña reseteada. Nueva clave: {newPassword}" );
            }
        }
    }
