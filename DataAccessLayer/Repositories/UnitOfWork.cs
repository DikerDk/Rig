using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext Database;
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }
        public UnitOfWork(AppDbContext db, SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public async Task SaveAsync()
        {
            await Database.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();

                }
                this.disposed = true;
            }
        }
    }
}
