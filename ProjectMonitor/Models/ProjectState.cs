using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class ProjectState
    {
		public ProjectState()
		{
			Projects = new HashSet<Projects>();
		}

		public int Id { get; set; }
		public int ProjectRoles { get; set; }

		public int SorumluKisiId { get; set; }
		public string YardimciKisiler { get; set; }
		public string Status { get; set; }
		public string Tamamlanan { get; set; }
		public DateTime? BaslangicTarihi { get; set; }
		public DateTime? BitisTarihi { get; set; }
		public int KalanSure { get; set; }
		public int CalismaSure { get; set; }
		 
		public Employees SorumluKisi { get; set; }
		public ICollection<Projects> Projects { get; set; }

	}
}
