using HPSchedule.Infrastructure;
using HPSchedule.Domain;
using Microsoft.EntityFrameworkCore;

namespace HPSchedule.Api.Tests;

public class DbCrudTests
{
    [Fact]
    public async Task Can_Create_And_Read_Patient_InMemory()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var db = new AppDbContext(options);
        db.Patients.Add(new Patient { FirstName = "Max", LastName = "Mustermann", Email = "max@example.com" });
        await db.SaveChangesAsync();

        var count = await db.Patients.CountAsync();
        count.Should().Be(1);
        var p = await db.Patients.FirstAsync();
        p.FirstName.Should().Be("Max");
    }
}
