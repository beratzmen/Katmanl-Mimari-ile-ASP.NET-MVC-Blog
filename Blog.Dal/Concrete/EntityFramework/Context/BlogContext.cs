using Blog.Entity.Models;
using System.Data.Entity;

namespace Blog.Dal.Concrete.EntityFramework.Context
{  

    public partial class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
        }

        public virtual DbSet<Etiket> Etiket { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makale)
                .WithMany(e => e.Etiket)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorum)
                .WithOptional(e => e.Makale)
                .WillCascadeOnDelete();
        }
    }
}
