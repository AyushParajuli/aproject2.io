using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public class ShopContext : DbContext
    {
        //Implement the Constructor
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        //On model creating  -> runs once the model is created.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //HERE basically i have to tell the system how the products and category are related to eachother
            modelBuilder.Entity<Category>()
                //one product has many products
                .HasMany(c => c.Products)
                .WithOne(c => c.Category) // each product has one category
                .HasForeignKey(c => c.CategoryId); // categoryid is the foreign id

            //Basically in the model builder we told them how they are related to each other'

            // this seed() contains our list of product it is basically came from the modelbuilderExtenson
            //which is made by the autor
            modelBuilder.Seed();

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
