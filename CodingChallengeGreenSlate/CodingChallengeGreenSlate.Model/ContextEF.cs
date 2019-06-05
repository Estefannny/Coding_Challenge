using CodingChallengeGreenSlate.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.Web;

namespace CodingChallengeGreenSlate.Model
{
    public class ContextEF : DbContext
    {
        public ContextEF() : base("name=ConnectionStringEF") { }

        public ContextEF(bool enableLazyLoading, bool enableProxyCreation)
            : base("name=ConnectionStringEF")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public ContextEF(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ContextEF>(new DropCreateIfChangeInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User", schemaName: "dbo");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }

        public void Seed(ContextEF Context)
        {
            var listUser = new List<User>() {
             new User() { Id = 1, FirstName = "User 1", LastName = "LastName 1"},
             new User() { Id = 2, FirstName = "User 2", LastName = "LastName 2"},
             new User() { Id = 3, FirstName = "User 3", LastName = "LastName 3"}
            };
            Context.Users.AddRange(listUser);
            Context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<ContextEF>
        {
            protected override void Seed(ContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<ContextEF>
        {
            protected override void Seed(ContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<ContextEF>
        {
            protected override void Seed(ContextEF context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        //Setting audit column values
        //    public override int SaveChanges()
        //    {
        //        var modifiedEntries = ChangeTracker.Entries()
        //            .Where(x => x.Entity is IAuditableEntity
        //                && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

        //        foreach (var entry in modifiedEntries)
        //        {
        //            IAuditableEntity entity = entry.Entity as IAuditableEntity;
        //            if (entity != null)
        //            {
        //                string identityName = Thread.CurrentPrincipal.Identity.Name;
        //                DateTime now = DateTime.UtcNow;

        //                if (entry.State == System.Data.Entity.EntityState.Added)
        //                {
        //                    entity.CreatedBy = identityName;
        //                    entity.CreatedDate = now;
        //                }
        //                else
        //                {
        //                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //                }

        //                entity.UpdatedBy = identityName;
        //                entity.UpdatedDate = now;
        //            }
        //        }
        //        return base.SaveChanges();
        //    }
    }
}