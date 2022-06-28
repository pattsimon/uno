using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.UI.Xaml.Documents
{
	partial class TextElement
	{
		protected virtual void InvalidateFontInfo() { }

		partial void OnFontFamilyChangedPartial()
		{
			InvalidateFontInfo();
		}

		partial void OnFontStyleChangedPartial()
		{
			InvalidateFontInfo();
		}

		partial void OnFontWeightChangedPartial()
		{
			InvalidateFontInfo();
		}
	}
}
