using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMVCCRUD.Models
{
	public class EmpregadoContext:DbContext
	{
		public EmpregadoContext(DbContextOptions<EmpregadoContext> options):base(options)
		{

		}
	}
}
