using BusinessLayer.Infrastructure;
using BusinessLayer.Interface;
using DataAccessLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
       

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.UserName, Birthday = userDto.Birthday, Gender = userDto.Gender,  PhoneNumber = userDto.Phone};
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");

                await Database.UserManager.AddToRoleAsync(user, userDto.Role);



                await Database.SaveAsync();
                return new OperationDetails(true, "Registration successfully completed!", "");
            }
            else
            {
                return new OperationDetails(false, "User with this login already exists", "Email");
            }
        }
        public async Task<bool> Authenticate(UserDTO userDto)
        {

            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                return false;
            }
            //var username = user.UserName;
            var email = user.Email;

            var auth = await Database.SignInManager.PasswordSignInAsync(email, userDto.Password, false, lockoutOnFailure: false);

            return auth.Succeeded;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
