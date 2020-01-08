using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_PSSC.Models;

namespace WebApp_PSSC.Repositories1
{
	interface IComandaRepository
	{
		void ActualizeazaComanda(Comanda comanda);
		void AdaugaComanda(Comanda comanda);
	}
}