using BusinessLayer.Infrastructure;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICategoryService : IDisposable
    {
        List<Category> GetAllCategories();
        Task<OperationDetails> AddCategory(string Name);
        Task<OperationDetails> Delete(int id);
    }
}
