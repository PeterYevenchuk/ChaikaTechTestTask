using Microsoft.EntityFrameworkCore;
using ChaikaTechTestTask.Core.LatestTransactions;
using ChaikaTechTestTask.Core.Points;
using ChaikaTechTestTask.Core.Users;

namespace ChaikaTechTestTask.Core.Context.Seeds;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Rick" },
            new User { UserId = 2, Name = "Morty" }
        );

        modelBuilder.Entity<Point>().HasData(
            new Point { PointId = 1, BeforeYesterdayPoints = 1000, YesterdayPoints = 3060, TotalPoints = 150, TodayPoints = 5005, UserId = 1, TodayDate = new DateOnly(2023, 10, 26) },
            new Point { PointId = 2, BeforeYesterdayPoints = 200, YesterdayPoints = 100, TotalPoints = 200, TodayPoints = 360, UserId = 2, TodayDate = new DateOnly(2023, 10, 25) }
        );

        modelBuilder.Entity<LatestTransaction>().HasData(
            new LatestTransaction
            {
                TransactionId = 1,
                Transaction = TransactionType.Credit,
                Amount = 10,
                Balance = 90,
                TransactionName = "Apple",
                Description = "Payment phone",
                TransactionDate = new DateOnly(2023, 10, 26),
                TransactionTime = new TimeOnly(8, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 2,
                Transaction = TransactionType.Credit,
                Amount = 20,
                Balance = 70,
                TransactionName = "Sumsung",
                Description = "New phone",
                TransactionDate = new DateOnly(2023, 10, 25),
                TransactionTime = new TimeOnly(9, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 3,
                Transaction = TransactionType.Payment,
                Amount = 500,
                Balance = 570,
                TransactionName = "Payment",
                Description = "Good job",
                TransactionDate = new DateOnly(2023, 10, 27),
                TransactionTime = new TimeOnly(10, 30),
                IsPending = true,
                AuthorizedUser = "Boss",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 4,
                Transaction = TransactionType.Credit,
                Amount = 30,
                Balance = 540,
                TransactionName = "Headphones",
                Description = "New headphones",
                TransactionDate = new DateOnly(2023, 10, 24),
                TransactionTime = new TimeOnly(11, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 5,
                Transaction = TransactionType.Credit,
                Amount = 50,
                Balance = 50,
                TransactionName = "Laptop",
                Description = "Laptop purchase",
                TransactionDate = new DateOnly(2023, 10, 18),
                TransactionTime = new TimeOnly(12, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 6,
                Transaction = TransactionType.Payment,
                Amount = 500,
                Balance = 570,
                TransactionName = "Rent",
                Description = "Monthly rent payment",
                TransactionDate = new DateOnly(2023, 10, 5),
                TransactionTime = new TimeOnly(13, 30),
                IsPending = true,
                AuthorizedUser = "Landlord",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 7,
                Transaction = TransactionType.Credit,
                Amount = 15,
                Balance = 35,
                TransactionName = "Groceries",
                Description = "Grocery shopping",
                TransactionDate = new DateOnly(2023, 10, 1),
                TransactionTime = new TimeOnly(14, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 8,
                Transaction = TransactionType.Credit,
                Amount = 25,
                Balance = 10,
                TransactionName = "Restaurant",
                Description = "Dinner at a restaurant",
                TransactionDate = new DateOnly(2023, 10, 22),
                TransactionTime = new TimeOnly(15, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 9,
                Transaction = TransactionType.Payment,
                Amount = 200,
                Balance = 225,
                TransactionName = "Internet",
                Description = "Monthly internet bill",
                TransactionDate = new DateOnly(2023, 10, 21),
                TransactionTime = new TimeOnly(16, 30),
                IsPending = true,
                AuthorizedUser = "Internet Provider",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 10,
                Transaction = TransactionType.Payment,
                Amount = 150,
                Balance = 75,
                TransactionName = "Electricity Bill",
                Description = "Monthly electricity bill payment",
                TransactionDate = new DateOnly(2023, 10, 21),
                TransactionTime = new TimeOnly(17, 30),
                IsPending = true,
                AuthorizedUser = "Electricity Company",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 11,
                Transaction = TransactionType.Credit,
                Amount = 40,
                Balance = 35,
                TransactionName = "Books",
                Description = "Purchase of books",
                TransactionDate = new DateOnly(2023, 10, 24),
                TransactionTime = new TimeOnly(18, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 12,
                Transaction = TransactionType.Credit,
                Amount = 60,
                Balance = 20,
                TransactionName = "Gaming Console",
                Description = "Purchase of a gaming console",
                TransactionDate = new DateOnly(2023, 10, 26),
                TransactionTime = new TimeOnly(19, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 13,
                Transaction = TransactionType.Payment,
                Amount = 75,
                Balance = 150,
                TransactionName = "Medical Bill",
                Description = "Payment of medical bills",
                TransactionDate = new DateOnly(2023, 10, 26),
                TransactionTime = new TimeOnly(20, 30),
                IsPending = true,
                AuthorizedUser = "Hospital",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 2
            },
           new LatestTransaction
           {
               TransactionId = 14,
               Transaction = TransactionType.Payment,
               Amount = 50,
               Balance = 50,
               TransactionName = "Rent",
               Description = "Monthly rent payment",
               TransactionDate = new DateOnly(2023, 10, 5),
               TransactionTime = new TimeOnly(13, 30),
               IsPending = true,
               AuthorizedUser = "Landlord",
               IconURL = "image/aa75349fa565c0e2792a888478408204.png",
               UserId = 1
           },
            new LatestTransaction
            {
                TransactionId = 15,
                Transaction = TransactionType.Credit,
                Amount = 15,
                Balance = 35,
                TransactionName = "Groceries",
                Description = "Grocery shopping",
                TransactionDate = new DateOnly(2023, 10, 1),
                TransactionTime = new TimeOnly(14, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 16,
                Transaction = TransactionType.Credit,
                Amount = 25,
                Balance = 10,
                TransactionName = "Restaurant",
                Description = "Dinner at a restaurant",
                TransactionDate = new DateOnly(2023, 10, 22),
                TransactionTime = new TimeOnly(15, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 17,
                Transaction = TransactionType.Payment,
                Amount = 200,
                Balance = 225,
                TransactionName = "Internet",
                Description = "Monthly internet bill",
                TransactionDate = new DateOnly(2023, 10, 21),
                TransactionTime = new TimeOnly(16, 30),
                IsPending = true,
                AuthorizedUser = "Internet Provider",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 18,
                Transaction = TransactionType.Payment,
                Amount = 150,
                Balance = 75,
                TransactionName = "Electricity Bill",
                Description = "Monthly electricity bill payment",
                TransactionDate = new DateOnly(2023, 10, 21),
                TransactionTime = new TimeOnly(17, 30),
                IsPending = true,
                AuthorizedUser = "Electricity Company",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 2
            },
            new LatestTransaction
            {
                TransactionId = 19,
                Transaction = TransactionType.Credit,
                Amount = 40,
                Balance = 35,
                TransactionName = "Books",
                Description = "Purchase of books",
                TransactionDate = new DateOnly(2023, 10, 24),
                TransactionTime = new TimeOnly(18, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 20,
                Transaction = TransactionType.Credit,
                Amount = 60,
                Balance = 20,
                TransactionName = "Gaming Console",
                Description = "Purchase of a gaming console",
                TransactionDate = new DateOnly(2023, 10, 26),
                TransactionTime = new TimeOnly(19, 30),
                IsPending = false,
                IconURL = "image/paymentsuccessful.png",
                UserId = 1
            },
            new LatestTransaction
            {
                TransactionId = 21,
                Transaction = TransactionType.Payment,
                Amount = 75,
                Balance = 150,
                TransactionName = "Medical Bill",
                Description = "Payment of medical bills",
                TransactionDate = new DateOnly(2023, 10, 26),
                TransactionTime = new TimeOnly(20, 30),
                IsPending = true,
                AuthorizedUser = "Hospital",
                IconURL = "image/aa75349fa565c0e2792a888478408204.png",
                UserId = 2
            }
        );
    }
}
