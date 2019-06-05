using CodingChallengeGreenSlate.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Test
{
    public class TestContextEF : DbContext
    {
        public TestContextEF()
            : base("Name=ConnectionStringEF")
        {

        }
        public TestContextEF(bool enableLazyLoading, bool enableProxyCreation)
            : base("Name=ConnectionStringEF")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public TestContextEF(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<TestContextEF>(new AlwaysCreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(TestContextEF Context)
        {
            var listUser = new List<User>() {
             new User() { Id = 1, FirstName = "User 1", LastName = "LastName 1"},
             new User() { Id = 2, FirstName = "User 2", LastName = "LastName 2"},
             new User() { Id = 3, FirstName = "User 3", LastName = "LastName 3"}
            };
            Context.Users.AddRange(listUser);
            Context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<TestContextEF>
        {
            protected override void Seed(TestContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<TestContextEF>
        {
            protected override void Seed(TestContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TestContextEF>
        {
            protected override void Seed(TestContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}
