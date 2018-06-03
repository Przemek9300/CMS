using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.CMSContext
{
    public class Context:DbContext
    {
            public Context() : base("DefaultConnection")
            {

            }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<SubPage> SubPages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
                        .HasMany<Tag>(s => s.Tags)
                        .WithMany(c => c.Posts)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("PostId");
                            cs.MapRightKey("TagId");
                            cs.ToTable("PostsTags");
                        });

        }


    }
}