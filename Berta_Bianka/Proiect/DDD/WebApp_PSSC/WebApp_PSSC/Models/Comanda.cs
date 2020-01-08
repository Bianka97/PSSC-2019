using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class Comanda
	{
		public IdComanda IdComanda { get; internal set; }
		public IdClient IdClient { get; internal set; }
		public IdProdus IdProdus { get; set; }
		[Range(1, 10), Display(Name = "Numar de produse de acest fel comandate")]
		public NrProduse NrProduse { get; set; }

		private List<Produs> _produseComandate;
		public virtual Client Client { get; set; }
		public virtual Produs Produs { get; set; }

		internal Comanda(IdComanda idComanda, IdClient idClient, IdProdus idProdus, NrProduse nrProduse)
		{
			//Contract.Requires(nume != null, "nume");
			//Contract.Requires(pondereExamen != null, "pondereExamen");

			IdComanda = idComanda;
			IdClient = idClient;
			IdProdus = idProdus;
			_produseComandate = new List<Produs>();
			NrProduse = nrProduse;
		}

		#region operatii
		//adaug un produs in cos
		public void Adauga_Produs(Produs produs)
		{
			var gasit = _produseComandate.FirstOrDefault(p => p.Equals(produs));
			if (gasit == null)
			{
				var copieProdus = new Produs(produs.IdProdus, produs.NumeProdus,produs.Stoc);
				_produseComandate.Add(copieProdus);
			}
			else
			{
				throw new ProdusulExistaException();
			}
		}
		#endregion
	}
}