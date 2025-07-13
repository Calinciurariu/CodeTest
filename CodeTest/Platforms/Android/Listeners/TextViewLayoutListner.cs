using Android.Views;
using Android.Widget;
using CodeTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Platforms.Android.Listeners
{
    internal class TextViewLayoutListner : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private TextView textView;
        private ScrollingLabelInternal ssLabelScroll;

        public TextViewLayoutListner(TextView textView, ScrollingLabelInternal ssLabelScroll)
        {
            this.textView = textView;
            this.ssLabelScroll = ssLabelScroll;
        }

        public void OnGlobalLayout()
        {
            textView.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);

            if (textView.Layout.LineCount > 0)
                ssLabelScroll.StartScroll(textView.Layout.GetEllipsisCount(0) > 0);
            else
                ssLabelScroll.StartScroll(false);
        }

    }
}
