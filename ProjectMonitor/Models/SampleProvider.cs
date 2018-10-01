using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class SampleProvider
	{
		public SampleProvider()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public string ProviderName { get; set; }

		public ICollection<Projects> Projects { get; set; }
	}
}
