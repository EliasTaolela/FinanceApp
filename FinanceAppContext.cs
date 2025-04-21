   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;

   public class FinanceAppContext : IdentityDbContext
   {
       public FinanceAppContext(DbContextOptions<FinanceAppContext> options)
           : base(options)
       {
       }

       public DbSet<Expense> Expenses { get; set; }
   }
   