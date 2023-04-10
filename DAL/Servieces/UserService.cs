using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _Context;
        public readonly IConfiguration _configuration;
        public readonly string connectionString;
        public UserService(DatabaseContext context, IConfiguration configuration)
        {
            _Context = context;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefualtConnection");
        }
        public void Add(AppUser user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }

        public bool changePassword(AppUser user)
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(string Id)
        {
            AppUser user = new AppUser();
            user = _Context.Users.Where(u => u.Id == Id).FirstOrDefault();
            return user;
        }

        public void Remove(string Id)
        {
            AppUser u = _Context.Users.Where(p => p.Id == Id).FirstOrDefault();
            if (u != null)
            {
                _Context.Users.Remove(u);
                _Context.SaveChanges();
            }
        }

        public void Update(AppUser? user)
        {
            if (user != null)
            {
                _Context.Update(user);
                _Context.SaveChanges();
            }
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            var result = _Context.Users.Where(p => p.PhoneNumber == phoneNumber).FirstOrDefault();
            return true ? result != null : false;
        }

        public AppUser GetByUserName(string userName)
        {
            var result = _Context.Users.Where(p => p.UserName == userName).FirstOrDefault();
            return result;
        }

        public string GetUserNameByPhoneNumber(string phoneNumber)
        {

            AppUser user = _Context.Users.Where(p => p.PhoneNumber == phoneNumber).FirstOrDefault();
            if (user != null)
            {
                return user.UserName;
            }
            else { return string.Empty; }



        }

        public List<AppUser> GetAll()
        {
            List<AppUser> result = _Context.Users.ToList();
            return result;
        }
    }
}
