using Android.Content;
using Android.Text;
using Android.Util;
using Android.Widget;
using CodeTest.Controls;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Platforms.Android.Handlers
{
    public class ScrollingLabelHandler : ViewHandler<ScrollingLabel, TextView>
    {
        public static PropertyMapper<ScrollingLabel, ScrollingLabelHandler> PropertyMapper = new(ViewMapper)
        {
            [nameof(ScrollingLabel.Text)] = MapText,
            [nameof(ScrollingLabel.FontSize)] = MapFontSize
        };

        public ScrollingLabelHandler() : base(PropertyMapper)
        {
        }

        protected override TextView CreatePlatformView()
        {
            var textView = new TextView(Context)
            {
                Ellipsize = TextUtils.TruncateAt.Marquee,
                Selected = true
            };
            textView.SetMarqueeRepeatLimit(-1);
            textView.SetSingleLine(true);
            textView.SetHorizontallyScrolling(true);
            return textView;
        }

        private static void MapText(ScrollingLabelHandler handler, ScrollingLabel label)
        {
            handler.PlatformView.Text = label.Text;
        }

        private static void MapFontSize(ScrollingLabelHandler handler, ScrollingLabel label)
        {
            handler.PlatformView.SetTextSize(ComplexUnitType.Sp, (float)label.FontSize);
        }

        protected override void ConnectHandler(TextView platformView)
        {
            base.ConnectHandler(platformView);
            platformView.Selected = true;
        }
    }
}
