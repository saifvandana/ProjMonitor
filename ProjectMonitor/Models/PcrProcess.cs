using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class PcrProcess
    {
		public PcrProcess()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public string Cihaz { get; set; }
		public string OperatorAdi { get; set; }
		public DateTime Tarih { get; set; }
		public string KayitAdi { get; set; }
		public string CalisanGen { get; set; }
		public int ResultSlipId { get; set; }
		public string Results { get; set; }
		public int MixAId { get; set; }
		public int MixBId { get; set; }
		public int EnzymeId { get; set; }
		public int DH20 { get; set; }
		public int DenaturationId { get; set; }
		public int Pcr1Id { get; set; }
		public int Pcr2Id { get; set; }
		public int CoolingId { get; set; }
		public int NucleicAcidId { get; set; }
		public string CalismaAmaci { get; set; }
		public string Yorum { get; set; }

		public ResultSlip ResultSlip { get; set; }
		public MixA MixA { get; set; }
		public MixB MixB { get; set; }
		public Enzyme Enzyme { get; set; }
		public Denaturation Denaturation { get; set; }
		public Pcr1 Pcr1 { get; set; }
		public Pcr2 Pcr2 { get; set; }
		public Cooling Cooling { get; set; }
		public NucleicAcid NucleicAcid { get; set; }


		public ICollection<Projects> Projects { get; set; }
	}
}
