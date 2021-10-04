using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAAPI.Data;

namespace WAAPI.Models
{
    public static class InitializeDB
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Orders.Any())
            {
                return;
            }
            var products = new Product[] {
                    new Product {Id = System.Guid.NewGuid(), Description = "Chocolate", Name = "Sorteve", Value = 2.00m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Morango", Name = "Sorteve", Value = 2.50m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Flocos", Name = "Sorteve", Value = 3.50m }
            };
            var products2 = new Product[] {
                    new Product {Id = System.Guid.NewGuid(), Description = "Baunilha", Name = "Sorteve", Value = 2.00m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Limão", Name = "Sorteve", Value = 2.50m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Coco", Name = "Sorteve", Value = 3.50m }
            };
            var products3 = new Product[] {
                    new Product {Id = System.Guid.NewGuid(), Description = "Napolitano", Name = "Sorteve", Value = 2.00m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Manga", Name = "Sorteve", Value = 2.50m },
                    new Product {Id = System.Guid.NewGuid(), Description = "Abacaxi", Name = "Sorteve", Value = 3.50m }
            };

            var order = new Order()
            {
                Id = System.Guid.NewGuid(),
                Address = "Rua Nova Jersey, 96",
                CreateAt = DateTime.Now,
                DeliveredAt = new DateTime(2021, 10, 20),
                Team = new Team
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Caminhoneiros 2",
                    Vehicle = "EJI-5964",
                    Description = "Motorista Marcio e auxiliar Jhonatan"
                },
                Products = products.ToList()
            };

            var order2 = new Order()
            {
                Id = System.Guid.NewGuid(),
                Address = "Rua Columbia, 1589",
                CreateAt = new DateTime(2021, 09, 30),
                DeliveredAt = new DateTime(2021, 10, 02),
                Team = new Team
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Caminhoneiros 1",
                    Vehicle = "EEU-1234",
                    Description = "Motorista João e auxiliar Antonio"
                },
                Products = products2.ToList()
            };
            var order3 = new Order()
            {
                Id = System.Guid.NewGuid(),
                Address = "Av Valentim Magalhães, 539",
                CreateAt = new DateTime(2021, 09, 10),
                DeliveredAt = new DateTime(2021, 09, 14),
                Team = new Team
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Caminhoneiros 3",
                    Vehicle = "BOX-5422",
                    Description = "Motorista Caio e auxiliar Rodrigo"
                },
                Products = products3.ToList()
            };

            context.Add(order);
            context.Add(order2);
            context.Add(order3);

            context.SaveChanges();
        }
    }
}