using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class RoleService : IRoleService
    {
        private readonly DatabaseContext _context;
        public RoleService(DatabaseContext context)
        {
            _context = context;
        }

        public List<AppRole> GetAll()
        {
            List<AppRole> result = _context.Roles.ToList();
            return result;
        }

        public AppRole GetRole(string roleName)
        {
            var result = _context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            return result;
        }
    }
}
