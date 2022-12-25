using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;


namespace Business.Concrete
{
      public class AuthManager : IAuthService
      {
            private IUserService _userService;
            private ITokenHelper _tokenHelper;
            private IUserOperationClaimDal _userOperationClaimDal;

            public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimDal userOperationClaimDal)
            {
                  _userService = userService;
                  _tokenHelper = tokenHelper;
                  _userOperationClaimDal = userOperationClaimDal;
            }

            public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
            {
                  byte[] passwordHash, passwordSalt;
                  HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                  var user = new User
                  {
                        Email = userForRegisterDto.Email,
                        FirstName = userForRegisterDto.FirstName,
                        LastName = userForRegisterDto.LastName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Status = userForRegisterDto.Status
                  };
                  _userService.Add(user);

                  // 1 - Admin
                  // 2 - Editör
                  // 3 - Kullanıcı
                  int operationClaimIdControl = user.Status ? 2 : 3;
                  UserOperationClaim userOperationClaimToAdd = new UserOperationClaim
                  {
                        UserId = user.Id,
                        OperationClaimId = operationClaimIdControl
                  };
                  _userOperationClaimDal.Add(userOperationClaimToAdd);

                  return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }

            public IDataResult<User> Login(UserForLoginDto userForLoginDto)
            {
                  var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
                  if (userToCheck == null)
                  {
                        return new ErrorDataResult<User>(Messages.UserNotFound);
                  }

                  if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                  {
                        return new ErrorDataResult<User>(Messages.PasswordError);
                  }

                  return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
            }

            public IResult ChangePassword(ChangePasswordDto changePasswordDto)
            {
                  byte[] passwordHash, passwordSalt;
                  var userToCheck = _userService.GetByMail(changePasswordDto.UserEmail).Data;
                  if (userToCheck == null)
                  {
                        return new ErrorDataResult<User>("Email geçersiz");
                  }
                  if (!HashingHelper.VerifyPasswordHash(changePasswordDto.OldPass, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                  {
                        return new ErrorDataResult<User>("Eski şifre geçersiz");
                  }
                  HashingHelper.CreatePasswordHash(changePasswordDto.NewPass, out passwordHash, out passwordSalt);
                  userToCheck.PasswordHash = passwordHash;
                  userToCheck.PasswordSalt = passwordSalt;
                  _userService.UpdateHelper(userToCheck);

                  return new SuccessResult("Şifre başarıyla değiştirildi");

            }

            public IResult UserExists(string email)
            {
                  if (_userService.GetByMail(email).Data != null)
                  {
                        return new ErrorResult(Messages.UserAlreadyExists);
                  }
                  return new SuccessResult();
            }

            public IDataResult<AccessToken> CreateAccessToken(User user)
            {
                  var claims = _userService.GetClaims(user).Data;
                  var accessToken = _tokenHelper.CreateToken(user, claims);
                  return new SuccessDataResult<AccessToken>(accessToken, Messages.SuccessfulLogin);
            }


      }
}
