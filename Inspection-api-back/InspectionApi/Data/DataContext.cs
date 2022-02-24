using InspectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
            
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
