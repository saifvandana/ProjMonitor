using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class SampleExtraction
    {
		public SampleExtraction()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public DateTime NumuneAlisTarihi { get; set; }
		public string TeslimAlinan { get; set; }
		public string TeslimAlan { get; set; }
		public string NumuneIsim { get; set; }
		public string NumuneKodu { get; set; }
		public string NumuneTuru { get; set; }
		public string NumuneKurum { get; set; }
		public string DiagenNukleikAsidKodu { get; set; }
		public DateTime EkstraksiyonTarihi { get; set; }
		public string YapanKisi { get; set; }
		public string Yontem { get; set; }
		public string KullanilanKit { get; set; }
		public string Aciklama { get; set; }
		
		public ICollection<Projects> Projects { get; set; }

	}
}
