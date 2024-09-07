using Microsoft.EntityFrameworkCore;
using NewsWeb.Entittes;
using System;

namespace NewsWeb.EF
{
    public class MainContext:DbContext
    {
        public MainContext(DbContextOptions<MainContext> options):base(options)
        {

        }
        public DbSet <News> News { get; set; }
        public DbSet <Category>Categories { get; set; }
        public DbSet <Ads> Advertisments { get; set; }
        public DbSet <Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsTag> NewsTag { get; set; }
    }
}
