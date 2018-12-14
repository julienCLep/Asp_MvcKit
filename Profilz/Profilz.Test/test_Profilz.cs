using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Profilz.Models;

namespace Profilz.Test
{
    [TestClass]
    public class test_Profilz
    {
        [TestMethod]
        public void Test_Create_User()
        {
            //Dal db = new Dal();
            
            User user = new User()
            {
                Username = "toto",
                Email = "aaaa@gmail.com",
                Password = "123456789"

            };
            Dal db = Dal.Db;

            Dal.Db.Users.Add(user);

            Dal.Db.SaveChanges();
        }
    }
}
