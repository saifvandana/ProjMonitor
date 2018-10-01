using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class Employees
    {
		public int Id { get; set; }
		public long Tckn { get; set; }
		public string AdSoyad { get; set; }
		public string Unvan { get; set; }
		public string Email { get; set; }
		public string FotografUrl { get; set; }
		public string CepTelefonu { get; set; }
		public string EvTelefonu { get; set; }
		public string IsTelefonu { get; set; }
		public DateTime DogumTarihi { get; set; }
		public string KullaniciAdi { get; set; }
		public string Parola { get; set; }
		public int EmployeeRoleId { get; set; }
		public bool IsActive { get; set; }

		public EmployeeRoles EmployeeRole { get; set; }
}
}
