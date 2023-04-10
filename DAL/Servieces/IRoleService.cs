using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IRoleService
    {
        public AppRole GetRole(string roleName);
        public List<AppRole> GetAll();
    }
}
