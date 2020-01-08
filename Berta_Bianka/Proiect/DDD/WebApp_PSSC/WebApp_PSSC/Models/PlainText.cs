using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_PSSC.Models
{
	public class PlainText
	{
		private string _text;
		public string Text { get { return _text; } }

		public PlainText(string text)
		{
			//Contract.Requires<ArgumentNullException>(text != null, "text");
			//Contract.Requires<ArgumentCannotBeEmptyStringException>(!string.IsNullOrEmpty(text), "text");

			_text = text;
		}
	}
}