using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Size = Microsoft.Maui.Graphics.Size;

namespace CodeTest.Platforms.Android.Services
{
    public static class DisplayInfoService
    {
        public static Size MeasureTextSize(string text, double fontSize, string fontName = null)
        {
            var textView = new TextView(MauiApplication.Context);
            textView.Typeface = GetTypeface(fontName);
            textView.SetText(text, TextView.BufferType.Normal);
            textView.SetTextSize(ComplexUnitType.Px, (float)fontSize);


            int widthMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
            int heightMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);

            textView.Measure(widthMeasureSpec, heightMeasureSpec);

            return new Size((double)textView.MeasuredWidth, (double)textView.MeasuredHeight);
        }

        private static Typeface GetTypeface(string fontName)
        {
            Typeface textTypeface = Typeface.Default;
            if (fontName != null)
                textTypeface = Typeface.Create(fontName, TypefaceStyle.Normal);

            return textTypeface;
        }
    }
}
