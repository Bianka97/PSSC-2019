using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class NrProduse
	{
		private int _nr;
		public int Numar { get { return _nr; } }

		public NrProduse(int nr)
		{
			_nr = nr;
		}
	}
}