namespace BudgetAppV2.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DbSet<FinancialTransactionHistory> FinancialTransactionHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the relationship between FinancialTransaction and FinancialTransactionHistory
        modelBuilder.Entity<FinancialTransaction>()
            .HasMany(ft => ft.History)
            .WithOne()
            .HasForeignKey("FinancialTransactionId")
            .OnDelete(DeleteBehavior.Cascade);

        // Data Seeding with static GUIDs
        modelBuilder.Entity<FinancialTransaction>().HasData(
            new FinancialTransaction
            {
                Id = new Guid("b1501478-fdba-49aa-8599-e23cdd8ad3b1"),
                TransactionType = TransactionType.Expense,
                IsRecurring = true,
                TransactionFrequency = TransactionFrequency.Monthly,
                Name = "Netflix Subscription",
                CurrentAmount = 15.99,
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = null
            },
            new FinancialTransaction
            {
                Id = new Guid("c02ee91f-7c3a-42c6-ba14-7a2df4934a3d"),
                TransactionType = TransactionType.Income,
                IsRecurring = true,
                TransactionFrequency = TransactionFrequency.Monthly,
                Name = "Salary",
                CurrentAmount = 2500.00,
                StartDate = new DateOnly(2022, 6, 15),
                EndDate = null
            },
            new FinancialTransaction
            {
                Id = new Guid("6ea81ae4-3bf4-4099-b844-72348a47bb0b"),
                TransactionType = TransactionType.Expense,
                IsRecurring = false,
                TransactionFrequency = TransactionFrequency.OneTime,
                Name = "New Laptop",
                CurrentAmount = 1200.00,
                StartDate = new DateOnly(2024, 2, 10),
                EndDate = new DateOnly(2024, 2, 10)
            },
            new FinancialTransaction
            {
                Id = new Guid("e36e7193-fd9d-4b53-929b-46dd90dc7317"),
                TransactionType = TransactionType.Income,
                IsRecurring = false,
                TransactionFrequency = TransactionFrequency.OneTime,
                Name = "Freelance Project",
                CurrentAmount = 800.00,
                StartDate = new DateOnly(2024, 1, 15),
                EndDate = null
            },
            new FinancialTransaction
            {
                Id = new Guid("73489b93-b090-4746-bbcc-b99c729f36ab"),
                TransactionType = TransactionType.Expense,
                IsRecurring = true,
                TransactionFrequency = TransactionFrequency.Monthly,
                Name = "Gym Membership",
                CurrentAmount = 25.00,
                StartDate = new DateOnly(2023, 3, 1),
                EndDate = null
            },
            new FinancialTransaction
            {
                Id = new Guid("0993573a-9d10-46d2-887a-5e29b3b32308"),
                TransactionType = TransactionType.Expense,
                IsRecurring = false,
                TransactionFrequency = TransactionFrequency.OneTime,
                Name = "Concert Tickets",
                CurrentAmount = 150.00,
                StartDate = new DateOnly(2024, 5, 20),
                EndDate = new DateOnly(2024, 5, 20)
            }
        );
    }
}