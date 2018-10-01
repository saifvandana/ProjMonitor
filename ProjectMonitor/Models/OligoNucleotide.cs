using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class OligoNucleotide
    {
        public OligoNucleotide()
        {
            OligonucleotideInfo = new HashSet<OligonucleotideInfo>();
        }

        public int Id { get; set; }
        public string SiparisKodu { get; set; }
        public DateTime? SiparisTarihi { get; set; }
        public DateTime? AlinmaTarihi { get; set; }
        public string HedefGenTur { get; set; }
        public string OligoNucleotideType { get; set; }
        public string BesIsaretleme { get; set; }
        public string NucleotideSequence { get; set; }
        public string UcIsaretleme { get; set; }
        public int NucleotideLength { get; set; }
        public string Tm { get; set; }
        public string GcPercent { get; set; }
        public string SelfComp { get; set; }
        public string Self3Comp { get; set; }
        public int HedefBolgeUzunlugu { get; set; }
        public string PrimerDimertur { get; set; }
        public string KaynakTasarlananSistem { get; set; }

        public ICollection<OligonucleotideInfo> OligonucleotideInfo { get; set; }
    }
}
