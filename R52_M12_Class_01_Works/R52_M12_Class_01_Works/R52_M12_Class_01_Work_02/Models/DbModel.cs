using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R52_M12_Class_01_Work_02.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; } = default!;
        [Required, Column(TypeName ="money")]
        public decimal PayRate { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

    }
    public class WorkerDbContext : DbContext
    {
        public WorkerDbContext(DbContextOptions<WorkerDbContext> options):base(options) { }
        public DbSet<Worker> Workers { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id=1, Name="Worker 1", PayRate=1050.00M, StartDate=new DateTime(2021, 2, 7), EndDate=new DateTime(2021, 3, 2)},
                new Worker { Id = 2, Name = "Worker 2", PayRate = 1050.00M, StartDate = new DateTime(2021, 2, 27) }
                );
        }
    }
}
