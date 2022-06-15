using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.UI.Xaml.Markup
{
	public partial interface IXamlTypeResolver
	{
		Type Resolve(string qualifiedTypeName);
	}
}
