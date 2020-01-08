using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class Client
	{
		public IdClient IdClient { get; set; }
		public PlainText Nume { get; set; }
		public PlainText Localitate { get; set; }
		public PlainText Email { get; set; }

		private List<Comanda> _Comanda;
		public virtual ICollection<Comanda> Comenzi { get; set; }

		internal Client(PlainText nume, PlainText email)
		{
			Nume = nume;
			Localitate = Localitate;
			Email = email;
			_Comanda = new List<Comanda>();
		}
	}
}