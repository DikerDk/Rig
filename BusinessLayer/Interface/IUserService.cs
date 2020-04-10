using BusinessLayer.Infrastructure;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserService: IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<bool> Authenticate(UserDTO userDto);

    }
}
