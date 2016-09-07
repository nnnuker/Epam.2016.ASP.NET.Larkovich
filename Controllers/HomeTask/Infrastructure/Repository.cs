using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HomeTask.Infrastructure
{
    public class Repository
    {
        private List<UserModel> users = new List<UserModel>
        {
            new UserModel { Name = "Tinki-Vinki", Age = 10 },
            new UserModel { Name = "Dipsi", Age = 10 },
            new UserModel { Name = "LjaLja", Age = 45 },
            new UserModel { Name = "Po", Age = 9 }
        };

        public IEnumerable<UserModel> Get()
        {
            return users;
        }

        public async Task<IEnumerable<UserModel>> AddUser(UserModel user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            users.Add(user);
            return await Task<IEnumerable<UserModel>>.Factory.StartNew(()=>
            {
                Thread.Sleep(1000);
                return users;
            });
        }
    }
}