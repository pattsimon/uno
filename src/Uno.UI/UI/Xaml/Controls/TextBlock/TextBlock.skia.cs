using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Microsoft.UI.Xaml.Documents;
using Uno.Extensions;
using System.Linq;
using Microsoft.UI.Xaml.Hosting;
using SkiaSharp;
using Microsoft.UI.Composition;
using System.Numerics;
using Microsoft.UI.Composition.Interactions;
using Uno.Disposables;
using Microsoft.UI.Xaml.Media;
using Uno.UI;
using Microsoft.UI.Xaml.Documents.TextFormatting;

namespace Microsoft.UI.Xaml.Controls
{
	partial class TextBlock : FrameworkElement, IBlock
	{
		private readonly TextVisual _textVisual;

		public TextBlock()
		{
			_textVisual = new TextVisual(Visual.Compositor, this);

			Visual.Children.InsertAtBottom(_textVisual);
		}

		private int GetCharacterIndexAtPoint(Point point)
		{
			return -1; // Not supported yet
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			var padding = Padding;
			var availableSizeWithoutPadding = availableSize.Subtract(padding);
			var desiredSize = Inlines.Measure(availableSizeWithoutPadding);

			return desiredSize.Add(padding);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			var padding = Padding;
			var availableSizeWithoutPadding = finalSize.Subtract(padding);
			var arrangedSizeWithoutPadding = Inlines.Arrange(availableSizeWithoutPadding);
			_textVisual.Size = new Vector2((float)arrangedSizeWithoutPadding.Width, (float)arrangedSizeWithoutPadding.Height);
			_textVisual.Offset = new Vector3((float)padding.Left, (float)padding.Top, 0);

			return base.ArrangeOverride(finalSize);
		}

		partial void OnInlinesChangedPartial()
		{
			Inlines.InvalidateMeasure();
		}

		// Invalidate Inlines measure when any IBlock properties used during measuring change:

		partial void OnMaxLinesChangedPartial()
		{
			Inlines.InvalidateMeasure();
		}

		partial void OnTextWrappingChangedPartial()
		{
			Inlines.InvalidateMeasure();
		}

		partial void OnLineHeightChangedPartial()
		{
			Inlines.InvalidateMeasure();
		}

		partial void OnLineStackingStrategyChangedPartial()
		{
			Inlines.InvalidateMeasure();
		}
	}
}
