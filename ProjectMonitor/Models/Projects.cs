using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class Projects
    {
		public int Id { get; set; }
		public int? UhtNumber { get; set; }
		public int? SdfNumber { get; set; }
		public DateTime? ProjeBaslangicTarihi { get; set; }
		public DateTime? ProjeBitisTarihi { get; set; }
		public int KullanilacakMesai { get; set; }
		public int BeklenenNumuneAdedi { get; set; }
		public string ProjeSorumlusu { get; set; }
		public string ProjeTuru { get; set; }
		public string IlgiliMusteri { get; set; }
		public string IlgiliMusteriTelNo { get; set; }
		public string IlgiliMusteriEmail { get; set; }
		public string IlgiliMusteriTemsilcisi { get; set; }
		public string ProjeServerLink { get; set; }
		public string ProjeAciklama { get; set; }
		public string ProjeSonDurum { get; set; }

		public int ProjectResearchPlanId { get; set; }
		public int WorkItemMonitorId { get; set; }
		public int OligonucleotideInfoId { get; set; }
		public int SampleExtractionId { get; set; }
		public int PcrProcessId { get; set; }
		public int ResultsId { get; set; }
		public int ProjectStateId { get; set; }
		public int SampleProviderId { get; set; }
		public string ProjectReport { get; set; }

		public ProjectResearchPlan ProjectResearchPlan { get; set; }
		public WorkItemMonitor WorkItemMonitor { get; set; }
		public OligonucleotideInfo OligonucleotideInfo { get; set; }
		public SampleExtraction SampleExtraction { get; set; }
		public PcrProcess PcrProcess { get; set; }
		public ProjectState ProjectState { get; set; }
		public SampleProvider SampleProvider { get; set; }
		public Results Results { get; set; }
	}
}
