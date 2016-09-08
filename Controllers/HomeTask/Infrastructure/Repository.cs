using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HomeTask.Infrastructure
{
    public static class Repository
    {
        private static readonly List<UserModel> users = new List<UserModel>
        {
            new UserModel { Name = "Tinki-Vinki", Age = 10, Id = 1},
            new UserModel { Name = "Dipsi", Age = 10, Id = 2},
            new UserModel { Name = "LjaLja", Age = 45, Id = 3},
            new UserModel { Name = "Po", Age = 9, Id = 4}
        };

        public static IEnumerable<UserModel> Get()
        {
            return users;
        }

        public static async Task<IEnumerable<UserModel>> AddUser(UserModel user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.Id = users.Count + 1;
            users.Add(user);
            return await Task<IEnumerable<UserModel>>.Factory.StartNew(()=>
            {
                Thread.Sleep(1000);
                return users;
            });
        }

        public static void DeleteUser(int id)
        {
            users.Remove(users.Find(u => u.Id == id));
        }
    }
}