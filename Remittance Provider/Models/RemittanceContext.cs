using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class RemittanceContext : DbContext
    {
        public RemittanceContext()
        {
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
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Remittance;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Accounts__BE2ACD6EA50806D6");

                entity.Property(e => e.BankCode)
                    .IsRequired()
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
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Code })
                    .HasName("PK__Bank__483129AD4D806EF7");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Bank)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank__CountryCod__4316F928");
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
                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rate).HasColumnType("decimal(2, 2)");

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
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

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

                entity.Property(e => e.TransactionNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.SendFromStateNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SendFromState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__SendF__66603565");

                entity.HasOne(d => d.SenderCountryNavigation)
                    .WithMany(p => p.TransactionsSenderCountryNavigation)
                    .HasForeignKey(d => d.SenderCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Sende__656C112C");

                entity.HasOne(d => d.ToCountryNavigation)
                    .WithMany(p => p.TransactionsToCountryNavigation)
                    .HasForeignKey(d => d.ToCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__ToCou__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
