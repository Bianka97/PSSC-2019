using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class IdComanda
	{
		private int _id;
		public int Id { get { return _id; } }

		public IdComanda(int id)
		{
			//Contract.Requires<ArgumentException>(valoare > 0, "valoare");
			//Contract.Requires<ArgumentException>(valoare <= 100, "valoare");

			_id = id;
		}
	}
}