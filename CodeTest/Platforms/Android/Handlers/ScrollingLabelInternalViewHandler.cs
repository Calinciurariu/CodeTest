using Android.Widget;
using CodeTest.Controls;
using CodeTest.Platforms.Android.Listeners;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.ComponentModel;

namespace CodeTest.Platforms.Android.Handlers
{
    public class ScrollingLabelInternalViewHandler : ViewHandler<ScrollingLabelInternal, TextView>
    {
        public ScrollingLabelInternalViewHandler() : base(ScrollingLabelInternalMapper)
        {
        }

        public static PropertyMapper<ScrollingLabelInternal, ScrollingLabelInternalViewHandler> ScrollingLabelInternalMapper = new(ViewHandler.ViewMapper)
        {
            [nameof(ScrollingLabelInternal.ScrollText)] = MapScrollText,
        };

        protected override TextView CreatePlatformView()
        {
            return new TextView(Context);
        }

        protected override void ConnectHandler(TextView platformView)
        {
            base.ConnectHandler(platformView);
            ControlIfScrollNeeded();
        }

        protected override void DisconnectHandler(TextView platformView)
        {
            base.DisconnectHandler(platformView);
        }

        static void MapScrollText(ScrollingLabelInternalViewHandler handler, ScrollingLabelInternal view)
        {
            handler.ControlIfScrollNeeded();
        }

        void ControlIfScrollNeeded()
        {
            if (VirtualView != null && PlatformView != null)
            {
                PlatformView.ViewTreeObserver.AddOnGlobalLayoutListener(
                    new TextViewLayoutListner(PlatformView, VirtualView));
            }
        }
    }
}
