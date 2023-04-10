using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IUserService
    {
        void Add(AppUser user);
        void Update(AppUser? user);
        void Remove(string Id);
        AppUser GetById(string Id);
        List<AppUser> GetAll();
        bool changePassword(AppUser user);

        /// <summary>
        /// True: if exist user then return false
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true|false</returns>
        bool CheckPhoneNumber(string phoneNumber);
        string GetUserNameByPhoneNumber(string phoneNumber);
        AppUser GetByUserName(string userName);



    }
}
