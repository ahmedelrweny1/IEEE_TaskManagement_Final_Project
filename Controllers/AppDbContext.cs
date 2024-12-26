using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace Project.Controllers
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<SuperVisor> SuperVisors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BigTask> BigTasks{ get; set; }
        public DbSet<SubTask> SubTasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = . ; DataBase = TaskManagement ; TrustServerCertificate = true ; Integrated Security =SSPI ");
        }
    }
}
