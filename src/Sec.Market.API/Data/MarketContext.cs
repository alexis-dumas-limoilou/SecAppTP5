using Microsoft.EntityFrameworkCore;
using Sec.Market.API.Entites;
using System;

namespace Sec.Market.API.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CustomerReview> CustomerReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nom = "John Doe",
                    Email = "jd@test.com",
                    Password = "123456",
                    Role = "Admin",
                    Token = "123456789",
                    DateCreation = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Nom = "Anne Doe",
                    Email = "ad@test.com",
                    Password = "123456",
                    Role = "User",
                    Token = "123456789",
                    DateCreation = DateTime.Now
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Chandail femme",
                    Description = "Chandail pour femme, taille M",
                    Price = 10,
                    DateCreation = DateTime.Now,
                    Image= "image1.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Polo Homme noir",
                    Description = "Polo noir homme, taille L",
                    Price = 20,
                    DateCreation = DateTime.Now,
                    Image = "image2.png"
                },
                new Product
                {
                    Id = 3,
                    Name = "T-shirt imprimé noir",
                    Description = "T-shirt noir imprimé homme",
                    Price = 30,
                    DateCreation = DateTime.Now,
                    Image = "image3.png"
                },
                new Product
                {
                    Id = 4,
                    Name = "T-shirt gris femme",
                    Description = "T-shirt gris femme taille M",
                    Price = 15,
                    DateCreation = DateTime.Now,
                    Image = "image4.png"
                },
                new Product
                {
                    Id = 5,
                    Name = "T-shirt multicolore femme",
                    Description = "T-shirt multicolore femme taille M",
                    Price = 25,
                    DateCreation = DateTime.Now,
                    Image = "image5.png"
                },
                new Product
                {
                    Id = 6,
                    Name = "T-shirt Homme Treillis Bloc",
                    Description = "T-shirt Tee Chemise Homme Treillis Bloc",
                    Price = 35,
                    DateCreation = DateTime.Now,
                    Image = "image6.png"
                },
                new Product
                {
                    Id = 7,
                    Name = "T-shirt imprimé blanc",
                    Description = "T-shirt blanc imprimé homme",
                    Price = 5,
                    DateCreation = DateTime.Now,
                    Image = "image7.png"
                },
                new Product
                {
                    Id = 8,
                    Name = "T-shirt Tee Femme Graphic Papillon",
                    Description = "T-shirt Tee Femme Graphic Papillon",
                    Price = 10,
                    DateCreation = DateTime.Now,
                    Image = "image8.png"
                },
                new Product
                {
                    Id = 9,
                    Name = "T-shirt Tee Femme Chat Graphic 3D du quotidien",
                    Description = "T-shirt Tee Femme Chat Graphic 3D du quotidien",
                    Price = 20,
                    DateCreation = DateTime.Now,
                    Image = "image9.png"
                },
                new Product
                {
                    Id = 10,
                    Name = "T-shirt Tee Homme Estampage à chaud Graphic",
                    Description = "T-shirt Tee Homme Estampage à chaud Graphic",
                    Price = 30,
                    DateCreation = DateTime.Now,
                    Image = "image10.png"
                },

                 new Product
                 {
                     Id = 11,
                     Name = "T-shirt Tee Homme Unisexe Estampage",
                     Description = "T-shirt Tee Homme Unisexe Estampage",
                     Price = 25,
                     DateCreation = DateTime.Now,
                     Image = "image11.png"
                 },

                  new Product
                  {
                      Id = 12,
                      Name = "T-shirt en tricot côtelé",
                      Description = "T-shirt en tricot côtelé",
                      Price = 15,
                      DateCreation = DateTime.Now,
                      Image = "image12.png"
                  }


            );

            modelBuilder.Entity<Card>().HasData(
                new Card
                {
                    Id = 1,
                    Number = "6466675889085456",
                    ExpirationDate = "12/25",
                    SecurityCode = "123",
                    Owner = "John Doe",
                    Type = "Visa",
                    UserId = 1        
                }   
            );

            modelBuilder.Entity<Order>().HasData(
                  new Order
                  {
                      Id = 1,
                      UserId = 1,
                      ProductId = 1,
                      Quantity = 1,
                      Price = 10,
                      ShippingAdress = "23r Rue Paul, Quebec, QC, G2H537",
                      Date = DateTime.Now
                  }
              );

            modelBuilder.Entity<CustomerReview>().HasData(
                new CustomerReview
                {
                    Id = 1,
                    ProductId = 1,
                    CustomerEmail = "jd@test.com",
                    CustomerName = "John Doe",
                    Comment = "Produit de très bonne qualitée"
                },
                new CustomerReview
                {
                    Id = 2,
                    ProductId = 2,
                    CustomerEmail = "ad@test.com",
                    CustomerName = "Anne Doe",
                    Comment = "Je recommande ce produit"
                }
                );

        }

    }
                
}
