using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using App01.Model.Domain.Entities;
using App01.Model.Infra.Data.Mappings.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace App01.Model.Infra.Data.Context.EF
{
	public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext()
        {
            return CreateDbContext(null);
        }
        
        public MyContext CreateDbContext(string[] args)
        {
           /* var builderConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builderConfiguration.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");*/

            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseMySql("Server=localhost;Port=3306;Database=app01;Uid=root;Pwd=");

            return new MyContext(builder.Options);
        }
    }


    public class MyContext : IdentityDbContext
	{
		public DbSet<User> User { get; set; }

        public MyContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=app01;Uid=root;Pwd=")
				//optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
				;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().Ignore(b => b.Valid).Ignore(b => b.ValidationResult).Ignore(b => b.Invalid);
					
			modelBuilder.Entity<User>(new UserMap().Configure);
		}
	}
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update

//################################GITHUB################################
//git add *
//git commit -m "First commit"
//git remote add origin https://github.com/marcorsouza/App01.git
//git push -u origin master
//git pull
//######################################################################