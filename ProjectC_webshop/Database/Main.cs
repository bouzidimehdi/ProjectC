using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model {
    public class WebshopContext : DbContext {

        // Hieronder staan de echte entity's die in de database staan.
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User_wishlist> User_wishlist { get; set; }
        public DbSet<Shopping_card> Shopping_card { get; set; }
        public DbSet<Shopping_card_Product> Shopping_Card_Products { get; set; }
        public DbSet<Builder_Product> Builder_Product { get; set; }
        public DbSet<Builder> Builder { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Factuur> Factuur { get; set; }
        public DbSet<Orderd_Product> Orderd_Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //here we define the name of our database
            optionsBuilder.UseNpgsql("User ID=postgres;Password=Rotterdam1997;Host=localhost;Port=5432;Database=WebshopDB;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Make Define Primari key for Role
            modelBuilder.Entity<Role>().HasKey(pk => new { pk.UserId } );
            // Define Primary key for Wishlist
            modelBuilder.Entity<User_wishlist>().HasKey(pk => new {pk.User_ID, pk.Product_ID});
            // Define Primary key for Builder_Product
            modelBuilder.Entity<Builder_Product>().HasKey(pk => new {pk.Builder_ID, pk.Product_ID});
            // Defin Primary key for Shopping_card_Produc
            modelBuilder.Entity<Shopping_card_Product>().HasKey(pk => new {pk.Shopping_card_ID, pk.Product_ID});


            // Make relation between Users and Role
            modelBuilder.Entity<Role>()
                .HasOne(R => R.User)
                .WithOne(U => U.Roles);

            // Make relation between Key and Product
            modelBuilder.Entity<Key>()
                .HasOne(Key => Key.Products)
                .WithMany(P => P.Keys)
                .HasForeignKey(Key => Key.ProductID);

            // Make relation between User_wishlist and Product
            modelBuilder.Entity<User_wishlist>()
                .HasOne(User_wishlist => User_wishlist.Product)
                .WithMany(Product => Product.Wishlists)
                .HasForeignKey(User_wishlist => User_wishlist.Product_ID);

            // Make relation between User and User_wishlist
            modelBuilder.Entity<User_wishlist>()
                .HasOne(User_wishlist => User_wishlist.User)
                .WithMany(Users => Users.Wishlists)
                .HasForeignKey(User_wishlist => User_wishlist.User_ID);

            // Make relation between Product and Builder_Product
            modelBuilder.Entity<Builder_Product>()
                .HasOne(Builder_Product => Builder_Product.Product)
                .WithMany(Product => Product.BuilderProducts)
                .HasForeignKey(Builder_Product => Builder_Product.Product_ID);

            // Make relation between Builder_Product and Builder
            modelBuilder.Entity<Builder_Product>()
                .HasOne(Builder_Product => Builder_Product.Builder)
                .WithMany(Builders => Builders.BuilderProducts)
                .HasForeignKey(Builder_Product => Builder_Product.Builder_ID);

            // Make relation between User and Shopping_card
            modelBuilder.Entity<Shopping_card>()
                .HasOne(Shopping_card => Shopping_card.User)
                .WithOne(User => User.ShoppingCard)
                .HasForeignKey<Shopping_card>(Shopping_cards => Shopping_cards.User_ID);

            // Make relation between Shopping_card and Shopping_card_Product
            modelBuilder.Entity<Shopping_card_Product>()
                .HasOne(Shopping_card_Product => Shopping_card_Product.ShoppingCard)
                .WithMany(Shopping_card => Shopping_card.ShoppingCardProducts)
                .HasForeignKey(Shopping_card_Product => Shopping_card_Product.Shopping_card_ID);

            // Make relation between User and Order
            modelBuilder.Entity<Order>()
                .HasOne(Order => Order.User)
                .WithMany(User => User.Orders)
                .HasForeignKey(Order => Order.User_ID);

            // Make relation between Order and Factuur
            modelBuilder.Entity<Order>()
                .HasOne(Order => Order.Factuur)
                .WithOne(Factuur => Factuur.Order)
                .HasForeignKey<Order>(Order => Order.Factuur_ID);

            // Make relation between Order and Orderd_Product
            modelBuilder.Entity<Orderd_Product>()
                .HasOne(Orderd_Product => Orderd_Product.Order)
                .WithMany(Order => Order.OrderdProducts)
                .HasForeignKey(Orderd_Product => Orderd_Product.Order_ID);

            // Make relation between Orderd_Product and Key
            modelBuilder.Entity<Orderd_Product>()
                .HasOne(Orderd_Product => Orderd_Product.Key)
                .WithMany(Key => Key.OrderdProducts)
                .HasForeignKey(Orderd_Product => Orderd_Product.Key_ID);

            // Make relation between Factuur and Factuur_Producten
            modelBuilder.Entity<Factuur_Producten>()
                .HasOne(Factuur_Producten => Factuur_Producten.Factuur)
                .WithMany(Factuur => Factuur.FactuurProductens)
                .HasForeignKey(Factuur_Producten => Factuur_Producten.Factuur_ID);

            // Make relation between Factuur_Producten and key
            modelBuilder.Entity<Factuur_Producten>()
                .HasOne(Factuur_Producten => Factuur_Producten.Key)
                .WithOne(Key => Key.FactuurProducten)
                .HasForeignKey<Factuur_Producten>(Factuur_Producten => Factuur_Producten.Key_ID);
        }
    }
}