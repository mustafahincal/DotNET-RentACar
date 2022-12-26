using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
      public class UserManager : IUserService
      {
            IUserDal _userDal;
            public UserManager(IUserDal userDal)
            {
                  _userDal = userDal;
            }
            public IResult Add(User user)
            {
                  _userDal.Add(user);
                  return new SuccessResult("Kullanıcı eklendi");
            }

            public IResult Delete(DeleteUserDto deleteUserDto)
            {
                  var userToDelete = _userDal.Get(u => u.Id == deleteUserDto.UserId);
                  _userDal.Delete(userToDelete);
                  return new SuccessResult("Kullanıcı başarıyla silindi");
            }

            public IDataResult<List<User>> GetAll()
            {
                  return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }

            public IDataResult<User> GetById(int userId)
            {
                  return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
            }

            public IDataResult<User> GetByMail(string email)
            {
                  return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            }

            public IDataResult<List<OperationClaim>> GetClaims(User user)
            {
                  return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
            }

            public IResult Update(UpdateUserDto updateUserDto)
            {
                  User userToUpdate = _userDal.Get(u => u.Id == updateUserDto.UserId);
                  userToUpdate.Email = updateUserDto.Email;
                  userToUpdate.FirstName = updateUserDto.FirstName;
                  userToUpdate.LastName = updateUserDto.LastName;
                  _userDal.Update(userToUpdate);
                  return new SuccessResult("Kullanıcı başarıyla güncellendi");
            }

            public IResult UpdateHelper(User user)
            {
                  _userDal.Update(user);
                  return new SuccessResult(Messages.Updated);
            }
      }
}
