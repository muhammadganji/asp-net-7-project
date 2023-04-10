using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class UserRoleService : IUserRoleService
    {
        private readonly DatabaseContext _context;
        public UserRoleService(DatabaseContext db)
        {
            _context = db;
        }

        public List<IdentityUserRole<string>> GetAll()
        {
            List<IdentityUserRole<string>> result = _context.UserRoles.ToList();
            return result;
        }
    }
}
