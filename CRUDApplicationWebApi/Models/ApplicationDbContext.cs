using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using YourNamespace.Models;

namespace CRUDApplicationWebApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<TaskList> Tasks { get; set; }
    }
}
