using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeTask.Infrastructure
{
    public static class Repository
    {
        public static List<UserModel> Users { get; } = new List<UserModel>
        {
            new UserModel { Name = "Tinki-Vinki", Age = 10 },
            new UserModel { Name = "Dipsi", Age = 10 },
            new UserModel { Name = "LjaLja", Age = 45 },
            new UserModel { Name = "Po", Age = 9 }
        };
    }
}