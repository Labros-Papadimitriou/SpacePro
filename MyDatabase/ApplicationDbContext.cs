using Entities.Bodies;
using Entities.BroadClasses;
using Entities.IdentityUsers;
using Microsoft.AspNet.Identity.EntityFramework;
//using MyDatabase.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Sindesmos", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //Database.Initialize(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ZeroOne To One Relationship
            modelBuilder.Entity<ArticleImage>()
            .HasRequired(x => x.Article);

            modelBuilder.Entity<UserImage>()
            .HasRequired(x => x.ApplicationUser);

            //ZeroOne To One Relationship
            modelBuilder.Entity<UserPost>()
            .HasRequired(x => x.ApplicationUser);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Comet> Comets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Asteroid> Asteroids { get; set; }
        public DbSet<Moon> Moons  { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<BodyImage> BodyImages { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}
