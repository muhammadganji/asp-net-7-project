using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IUserRoleService
    {
        List<IdentityUserRole<string>> GetAll();
    }
}
