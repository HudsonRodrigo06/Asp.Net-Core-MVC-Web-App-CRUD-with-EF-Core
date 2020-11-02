using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD_com_EF_Core.Models
{
	public class Empregado
	{
		[Key]
		public int EmpregadoId { get; set; }

		[Required(ErrorMessage = "Este campo é necessário")]
		[DisplayName("Nome Completo")]
		[Column(TypeName = "varchar(200)")]
		public string NomeCompleto { get; set; }

		[DisplayName("Cód. Trabalhador")]
		[Column(TypeName = "varchar(20)")]
		public string EmpCode { get; set; }

		[Column(TypeName = "varchar(40)")]
		public string Cargo { get; set; }

		[DisplayName("Local de Trabalho")]
		[Column(TypeName = "varchar(200)")]
		public string LocalTrabalho { get; set; }


	}
}
