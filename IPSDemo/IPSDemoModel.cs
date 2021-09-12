using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPSDemo
{
    public class IPSDemoModel : DbContext
    {
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<CorporateAccount> CorporateAccounts { get; set; }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            IPSDemoModel context = serviceProvider.GetRequiredService<IPSDemoModel>();
            if (!context.Database.EnsureCreated())
                context.Database.Migrate();
        }

        public IPSDemoModel(DbContextOptions<IPSDemoModel> options) : base(options) { }

        public class Person
        {
            [Key]
            public Guid Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required] 
            public DateTime DOB { get; set; }
        }

        public abstract class Account
        {
            [Key]
            public Guid Id { get; set; }
            
            [Required]
            public string AccountName { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            public DateTime DOB { get; set; }
        }

        public class PersonalAccount : Account
        {
            [Required]
            public string TFN { get; set; }

            [Required]
            public string BankAccountNo { get; set; }

            [Required]
            public string BankAccountBSB { get; set; }

            [Required]
            public int NoOfPersonnel { get; set; }

            public List<Person> Personnel { get; set; }
        }

        public class CorporateAccount : Account
        {
            [Required]
            public string CompanyName { get; set; }

            [Required]
            public string ABN { get; set; }

            [Required]
            public string BankAccountNo { get; set; }

            [Required]
            public string BankAccountBSB { get; set; }

            [Required]
            public int NoOfCompanyOfficers { get; set; }

            public List<CompanyOfficer> CompanyOfficers { get; set; }

            public class CompanyOfficer : Person
            {

            }
        }
    }
}