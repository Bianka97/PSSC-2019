using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class Produs
	{
		public IdProdus IdProdus { get; set; }
		public PlainText TipProdus { get; set; }
		public PlainText NumeProdus { get; set; }
		public Stoc Stoc { get; set; }

		internal Produs(IdProdus idProdus,PlainText numeProdus,Stoc stoc)
		{
			//Contract.Requires(nrMatricol != null, "numar matricol");
			//Contract.Requires(nume != null, "nume");
			IdProdus = idProdus;
			NumeProdus = numeProdus;
			Stoc = stoc;
		}
	}
}