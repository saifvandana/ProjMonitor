using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMonitor.Models;

namespace ProjectMonitor.Models
{
	public class ProjectMonitorContext : DbContext
	{
		public ProjectMonitorContext (DbContextOptions<ProjectMonitorContext> options)
			: base(options)
		{
		}

		public DbSet<ProjectMonitor.Models.Cooling> Cooling { get; set; }

		public DbSet<ProjectMonitor.Models.Denaturation> Denaturation { get; set; }

		public DbSet<ProjectMonitor.Models.EmployeeRoles> EmployeeRoles { get; set; }

		public DbSet<ProjectMonitor.Models.Employees> Employees { get; set; }

		public DbSet<ProjectMonitor.Models.Enzyme> Enzyme { get; set; }

		public DbSet<ProjectMonitor.Models.MenuItem> MenuItem { get; set; }

		public DbSet<ProjectMonitor.Models.MixA> MixA { get; set; }

		public DbSet<ProjectMonitor.Models.MixB> MixB { get; set; }

		public DbSet<ProjectMonitor.Models.NucleicAcid> NucleicAcid { get; set; }

		public DbSet<ProjectMonitor.Models.OligoNucleotide> OligoNucleotide { get; set; }

		public DbSet<ProjectMonitor.Models.OligonucleotideInfo> OligonucleotideInfo { get; set; }

		public DbSet<ProjectMonitor.Models.OligoNucleotideMixB> OligoNucleotideMixB { get; set; }

		public DbSet<ProjectMonitor.Models.Operation> Operations { get; set; }

		public DbSet<ProjectMonitor.Models.OperationRole> OperationRole { get; set; }

		public DbSet<ProjectMonitor.Models.Pcr1> Pcr1 { get; set; }

		public DbSet<ProjectMonitor.Models.Pcr2> Pcr2 { get; set; }

		public DbSet<ProjectMonitor.Models.PcrProcess> PcrProcess { get; set; }

		public DbSet<ProjectMonitor.Models.ProjectResearchPlan> ProjectResearchPlan { get; set; }

		public DbSet<ProjectMonitor.Models.Projects> Projects { get; set; }

		public DbSet<ProjectMonitor.Models.ProjectState> ProjectState { get; set; }

		public DbSet<ProjectMonitor.Models.ProjectSteps> ProjectSteps { get; set; }

		public DbSet<ProjectMonitor.Models.ReferenceArticles> ReferenceArticles { get; set; }

		public DbSet<ProjectMonitor.Models.Results> Results { get; set; }

		public DbSet<ProjectMonitor.Models.ResultSlip> ResultSlip { get; set; }

		public DbSet<ProjectMonitor.Models.Role> Roles { get; set; }

		public DbSet<ProjectMonitor.Models.SampleExtraction> SampleExtraction { get; set; }

		public DbSet<ProjectMonitor.Models.SampleProvider> SampleProvider { get; set; }

		public DbSet<ProjectMonitor.Models.StepsResearch> StepsResearch { get; set; }

		internal User FindAsync(int? id)
		{
			throw new NotImplementedException();
		}

		public DbSet<ProjectMonitor.Models.User> User { get; set; }

		public DbSet<ProjectMonitor.Models.UserLog> UserLog { get; set; }

		public DbSet<ProjectMonitor.Models.WorkItemMonitor> WorkItemMonitor { get; set; }

		public DbSet<ProjectMonitor.Models.WorkItems> WorkItems { get; set; }

		public DbSet<ProjectMonitor.Models.WorkItemType> WorkItemType { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RoleOperation>()
				.HasKey(x => new { x.RoleId, x.OperationId });

			modelBuilder.Entity<RoleOperation>()
				.HasOne(x => x.Role)
				.WithMany(m => m.RoleOperations)
				.HasForeignKey(x => x.RoleId);

			modelBuilder.Entity<RoleOperation>()
				.HasOne(x => x.Operation)
				.WithMany(e => e.RoleOperations)
				.HasForeignKey(x => x.OperationId);
		}
	}
}
