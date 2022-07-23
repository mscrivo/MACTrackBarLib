#region Copyright (c) 2002-2006 X-Component, All Rights Reserved

/* ---------------------------------------------------------------------*
*                           X-Component,                              *
*              Copyright (c) 2002-2006 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by Vietnam and               *
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
* TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
* TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
* CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
* THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF ECONTECH JSC.,     *
*                                                                       *
* UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
* PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
* SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY ECONTECH JSC. PRODUCT.   *
*                                                                       *
* THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
* CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF ECONTECH JSC.,     *
* THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO             *
* INSURE ITS CONFIDENTIALITY.                                           *
*                                                                       *
* THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
* PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
* EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
* THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
* SOURCE CODE CONTAINED HEREIN.                                         *
*                                                                       *
* THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
* --------------------------------------------------------------------- *
*/

#endregion Copyright (c) 2002-2006 X-Component, All Rights Reserved

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MACTrackBarLib;

/// <summary>
///     Summary description for DrawMACStyleHelper.
/// </summary>
public static class DrawMACStyleHelper
{
    /// <summary>
    /// </summary>
    /// <param name="g"></param>
    /// <param name="drawRectF"></param>
    /// <param name="drawColor"></param>
    /// <param name="orientation"></param>
    public static void DrawAquaPill(Graphics g, RectangleF drawRectF, Color drawColor, Orientation orientation)

    {
        LinearGradientBrush gradientBrush;
        var colorBlend = new ColorBlend();

        var color1 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, Color.Black, 100), 40);
        var color2 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(64, 64, 64), 100), 20);
        var color3 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(128, 128, 128), 100);
        var color4 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(192, 192, 192), 100);
        var color5 = ColorHelper.OverlayMix(ColorHelper.SoftLightMix(drawColor, Color.White, 100), Color.White, 75);

        //			
        colorBlend.Colors = new[] { color1, color2, color3, color4, color5 };
        colorBlend.Positions = new[] { 0, 0.25f, 0.5f, 0.75f, 1 };
        if (orientation == Orientation.Horizontal)
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top - 1), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height + 1),
                color1, color5);
        }
        else
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left - 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width + 1, (int)drawRectF.Top),
                color1, color5);
        }

        gradientBrush.InterpolationColors = colorBlend;
        FillPill(gradientBrush, drawRectF, g);

        //
        color2 = Color.White;
        colorBlend.Colors = new[] { color2, color3, color4, color5 };
        colorBlend.Positions = new[] { 0, 0.5f, 0.75f, 1 };
        if (orientation == Orientation.Horizontal)
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left + 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + 1, (int)drawRectF.Top + (int)drawRectF.Height - 1),
                color2, color5);
        }
        else
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top + 1), new Point((int)drawRectF.Left + (int)drawRectF.Width - 1, (int)drawRectF.Top + 1),
                color2, color5);
        }

        gradientBrush.InterpolationColors = colorBlend;
        FillPill(gradientBrush, RectangleF.Inflate(drawRectF, -3, -3), g);
    }

    /// <summary>
    /// </summary>
    /// <param name="g"></param>
    /// <param name="drawRectF"></param>
    /// <param name="drawColor"></param>
    /// <param name="orientation"></param>
    public static void DrawAquaPillSingleLayer(Graphics g, RectangleF drawRectF, Color drawColor, Orientation orientation)
    {
        LinearGradientBrush gradientBrush;
        var colorBlend = new ColorBlend();

        var color2 = ControlPaint.Light(drawColor);
        var color3 = ControlPaint.Light(color2);
        var color4 = ControlPaint.Light(color3);

        colorBlend.Colors = new[] { drawColor, color2, color3, color4 };
        colorBlend.Positions = new[] { 0, 0.25f, 0.65f, 1 };

        if (orientation == Orientation.Horizontal)
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height), drawColor,
                color4);
        }
        else
        {
            gradientBrush = new LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width, (int)drawRectF.Top), drawColor,
                color4);
        }

        gradientBrush.InterpolationColors = colorBlend;

        FillPill(gradientBrush, drawRectF, g);
    }

    /// <summary>
    /// </summary>
    /// <param name="b"></param>
    /// <param name="rect"></param>
    /// <param name="g"></param>
    private static void FillPill(Brush b, RectangleF rect, Graphics g)
    {
        if (rect.Width > rect.Height)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillEllipse(b, new RectangleF(rect.Left, rect.Top, rect.Height, rect.Height));
            g.FillEllipse(b, new RectangleF(rect.Left + rect.Width - rect.Height, rect.Top, rect.Height, rect.Height));

            var w = rect.Width - rect.Height;
            var l = rect.Left + rect.Height / 2;
            g.FillRectangle(b, new RectangleF(l, rect.Top, w, rect.Height));
            g.SmoothingMode = SmoothingMode.Default;
        }
        else if (rect.Width < rect.Height)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillEllipse(b, new RectangleF(rect.Left, rect.Top, rect.Width, rect.Width));
            g.FillEllipse(b, new RectangleF(rect.Left, rect.Top + rect.Height - rect.Width, rect.Width, rect.Width));

            var t = rect.Top + rect.Width / 2;
            var h = rect.Height - rect.Width;
            g.FillRectangle(b, new RectangleF(rect.Left, t, rect.Width, h));
            g.SmoothingMode = SmoothingMode.Default;
        }
        else if (Math.Abs(rect.Width - rect.Height) < float.Epsilon)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillEllipse(b, rect);
            g.SmoothingMode = SmoothingMode.Default;
        }
    }
}
