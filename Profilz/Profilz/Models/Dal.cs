using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Profilz.Models
{
    public class Dal : DbContext
    {
        //accesseur public
        #region Tables 

       public DbSet<User> Users { get; set; }

        #endregion
        private static Dal _db;
        public static Dal Db { get {
                                if (_db==null)
                                {
                                _db = new Dal();
                                 }
                                 return _db;
                            }
                       } 
       
        public Dal() : base("mainContext"){ }

        public Dal(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DropCreateDatabaseAlways<Dal>());
        }


    }
}