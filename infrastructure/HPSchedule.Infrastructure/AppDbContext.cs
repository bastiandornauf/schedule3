using HPSchedule.Domain;
using Microsoft.EntityFrameworkCore;

namespace HPSchedule.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceLine> InvoiceLines => Set<InvoiceLine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(b =>
        {
            b.ToTable("patient");
            b.HasKey(x => x.Id);
            b.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            b.Property(x => x.LastName).HasMaxLength(200).IsRequired();
            b.Property(x => x.Email).HasMaxLength(512);
        });

        modelBuilder.Entity<Appointment>(b =>
        {
            b.ToTable("appointment");
            b.HasKey(x => x.Id);
            b.Property(x => x.StartUtc).IsRequired();
            b.Property(x => x.EndUtc).IsRequired();
            b.Property(x => x.Notes).HasMaxLength(2000);
            b.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId);
        });

        modelBuilder.Entity<Invoice>(b =>
        {
            b.ToTable("invoice");
            b.HasKey(x => x.Id);
            b.Property(x => x.InvoiceDate).IsRequired();
            b.Property(x => x.Number).HasMaxLength(64).IsRequired();
            b.Property(x => x.Total).HasColumnType("decimal(18,2)");
            b.Property(x => x.Status).HasConversion<int>();
            b.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId);
            b.HasMany(x => x.Lines).WithOne().HasForeignKey(l => l.InvoiceId);
        });

        modelBuilder.Entity<InvoiceLine>(b =>
        {
            b.ToTable("invoice_line");
            b.HasKey(x => x.Id);
            b.Property(x => x.Label).HasMaxLength(512).IsRequired();
            b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        });
    }
}
