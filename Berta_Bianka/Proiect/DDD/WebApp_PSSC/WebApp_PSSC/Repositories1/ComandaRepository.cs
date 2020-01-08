using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_PSSC.Models;

namespace WebApp_PSSC.Repositories1
{
	public class ComandaRepository : WebApp_PSSC.Repositories1.IComandaRepository
	{
		private static List<Comanda> _comenzi = new List<Comanda>();

		public ComandaRepository()
		{
		}

		public void AdaugaComanda(Comanda comanda)
		{
			var result = _comenzi.FirstOrDefault(d => d.Equals(comanda));

			if (result != null) throw new DuplicateWaitObjectException();
			_comenzi.Add(comanda);
			Console.WriteLine("O noua comanda a fost adaugata.");
		}

		public void ActualizeazaComanda(Comanda comanda)
		{
			//persit changes to the database
			Console.WriteLine("Modificarile au fost salvate.");
		}

	}
}