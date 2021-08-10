using DataLayer.Entites.Account;
using ServicesLayer.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesLayer.Servicse.Interface
{
  public interface IUserService : IDisposable
  {
    Task<List<User>> GetAllUsers();
    Task<RegisterUserResult> RegisterUser(RegisterUserDTO registerUser);
    bool IsUserExistByEmail(string email);

    #region Login

    Task<LoginUserResult> LoginUser(LoginUserDTO loginUser);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserById(long userid);


    #endregion
  }
}
