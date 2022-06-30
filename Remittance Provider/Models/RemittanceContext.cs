using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class RemittanceContext : DbContext
    {
        private IConfiguration _configuration;
        public RemittanceContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RemittanceContext(DbContextOptions<RemittanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRate { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("conn1"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.BankCode })
                    .HasName("PK__Accounts__C7102D21E5C0619C");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__BankCo__0C85DE4D");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Bank__A25C5AA63BC22D13");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Bank)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank__CountryCod__09A971A2");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Countrie__A25C5AA6DE23A81E");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExchangeRate1)
                    .HasColumnName("ExchangeRate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SourceCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DestinationCountryNavigation)
                    .WithMany(p => p.ExchangeRateDestinationCountryNavigation)
                    .HasForeignKey(d => d.DestinationCountry)
                    .HasConstraintName("FK__ExchangeR__Desti__5441852A");

                entity.HasOne(d => d.SourceCountryNavigation)
                    .WithMany(p => p.ExchangeRateSourceCountryNavigation)
                    .HasForeignKey(d => d.SourceCountry)
                    .HasConstraintName("FK__ExchangeR__Sourc__534D60F1");
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.Property(e => e.BaseRate).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SourceCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DestinationCountryNavigation)
                    .WithMany(p => p.FeesDestinationCountryNavigation)
                    .HasForeignKey(d => d.DestinationCountry)
                    .HasConstraintName("FK__Fees__Destinatio__60A75C0F");

                entity.HasOne(d => d.SourceCountryNavigation)
                    .WithMany(p => p.FeesSourceCountryNavigation)
                    .HasForeignKey(d => d.SourceCountry)
                    .HasConstraintName("FK__Fees__SourceCoun__619B8048");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__States__A25C5AA6A8BD2643");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionNumber)
                    .HasName("PK__Transact__E733A2BEA6EED04D");

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Fees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FromAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FromCurrency)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SendFromState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SenderAddress)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SenderCity)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenderCountry)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SenderEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenderFirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenderLastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenderPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SenderPostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankAccountName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankAccountNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToCountry)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ToFirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToLastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
