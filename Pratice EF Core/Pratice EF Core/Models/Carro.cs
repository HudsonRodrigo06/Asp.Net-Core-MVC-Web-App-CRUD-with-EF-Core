using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pratice_EF_Core.Models
{
	public class Carro
	{
		[Key]
		public int CarroId { get; set; }

		[Column(TypeName = "varchar(10)")]
		[DisplayName("Valor R$")]
		public string Valor { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string Nome { get; set; }

	}
}
