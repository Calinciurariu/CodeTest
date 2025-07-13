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
        private ScrollingLabelInternal _scrollingLabelInternal;

        public TextViewLayoutListner(TextView textView, ScrollingLabelInternal scrollingLabelInternal)
        {
            this.textView = textView;
            this._scrollingLabelInternal = scrollingLabelInternal;
        }

        public void OnGlobalLayout()
        {
            textView.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);

            if (textView.Layout.LineCount > 0)
                _scrollingLabelInternal.StartScroll(textView.Layout.GetEllipsisCount(0) > 0);
            else
                _scrollingLabelInternal.StartScroll(false);
        }

    }
}
