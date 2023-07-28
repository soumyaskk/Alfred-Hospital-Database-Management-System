using Microsoft.EntityFrameworkCore;
using AlfredHospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AlfredHospital.Models.ViewModels;

namespace AlfredHospital.DataAccess;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {

    }

    public DbSet<Patient> Patients { get; set; }
	public DbSet<Physician> Physicians { get; set; }

	public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
    public DbSet<Billing> Billings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<History> Historys { get; set; }
}
