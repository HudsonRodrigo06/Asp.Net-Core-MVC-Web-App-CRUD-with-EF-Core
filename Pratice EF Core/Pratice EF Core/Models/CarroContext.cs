using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratice_EF_Core.Models
{
	public class CarroContext:DbContext
	{
		public CarroContext(DbContextOptions<CarroContext> options):base(options)
		{

		}

		public DbSet<Carro> Carros { get; set; }

	}
}
