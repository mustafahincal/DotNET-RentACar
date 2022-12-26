using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class AuthController : Controller
      {
            private IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                  _authService = authService;
            }

            [HttpPost("login")]
            public ActionResult Login(UserForLoginDto userForLoginDto)
            {
                  var userToLogin = _authService.Login(userForLoginDto);
                  if (!userToLogin.Success)
                  {
                        return BadRequest(userToLogin);
                  }

                  var result = _authService.CreateAccessToken(userToLogin.Data);
                  if (result.Success)
                  {

                        return Ok(result);
                  }

                  return BadRequest(result);
            }

            [HttpPost("register")]
            public ActionResult Register(UserForRegisterDto userForRegisterDto)
            {
                  var userExists = _authService.UserExists(userForRegisterDto.Email);
                  if (!userExists.Success)
                  {
                        return BadRequest(userExists);
                  }

                  var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

                  var result = _authService.CreateAccessToken(registerResult.Data);
                  if (result.Success)
                  {
                        return Ok(result);
                  }

                  return BadRequest(result);
            }

            [HttpPost("changepassword")]
            public ActionResult ChangeUserPassword(ChangePasswordDto changePasswordDto)
            {
                  var changePasswordResult = _authService.ChangePassword(changePasswordDto);

                  if (changePasswordResult.Success)
                  {
                        return Ok(changePasswordResult);
                  }

                  return BadRequest(changePasswordResult);
            }

            [HttpPost("createresetpasscode")]
            public ActionResult CreateResetPassCode(ResetPassDto resetPassDto)
            {
                  var createResetPassResult = _authService.CreateResetCode(resetPassDto);

                  if (createResetPassResult.Success)
                  {
                        return Ok(createResetPassResult);
                  }

                  return BadRequest(createResetPassResult);
            }

            [HttpPost("forgotpasswordlogin")]
            public ActionResult ForgotPasswordLogin(LoginForgotPasswordDto loginForgotPasswordDto)
            {
                  var isCodeValid = _authService.ControlResetCode(loginForgotPasswordDto);
                  if (!isCodeValid.Success)
                  {
                        return BadRequest(isCodeValid);
                  }
                  var hasChangedPassword = _authService.ForgotChangePassword(loginForgotPasswordDto);
                  if (!hasChangedPassword.Success)
                  {
                        return BadRequest(hasChangedPassword);
                  }
                  return Ok(hasChangedPassword);
            }

      }
}
