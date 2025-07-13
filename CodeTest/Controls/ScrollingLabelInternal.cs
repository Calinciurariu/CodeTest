using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Controls
{
    public class ScrollingLabelInternal : Label
    {
  
   


        public static readonly BindableProperty ScrollTextProperty =
     BindableProperty.Create(propertyName: nameof(ScrollText),
     returnType: typeof(string),
     declaringType: typeof(ScrollingLabelInternal),
     defaultValue: null,
     defaultBindingMode: BindingMode.OneWay,
     propertyChanging: OnScrollTextChanged);

        public string ScrollText
        {
            get { return (string)GetValue(ScrollTextProperty); }
            set { SetValue(ScrollTextProperty, value); }
        }

        private static void OnScrollTextChanged(BindableObject pObj, object pOldVal, object pNewVal)
        {
            if (pObj is ScrollingLabelInternal scrollingLabelInternal)
            {
                scrollingLabelInternal.Text = pNewVal as string;
            }
        }


        public string FullText { private set; get; }
        string fullText = null;
        Task taskScroll = null;
        CancellationTokenSource tokenSource2 = null;
        CancellationToken ct = CancellationToken.None;

        public void StartScroll(bool hasEllipsis)
        {
            if (StopScroll())
            {
                tokenSource2 = new CancellationTokenSource();
                ct = tokenSource2.Token;

                if (hasEllipsis)
                {
                    try
                    {
#if ANDROID
                        double LengthOfThreeDotsByFontSize = (CodeTest.Platforms.Android.Services.DisplayInfoService.MeasureTextSize(" ...", this.FontSize, this.FontFamily)).Width;
                        this.Dispatcher.Dispatch(() =>  (this.Parent as ScrollingLabel)?.ShowFade(true, LengthOfThreeDotsByFontSize) );
#endif 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine( $"ScrollingLabelInternal StartScroll error {ex.Message}");

                    }

                    FullText = this.ScrollText;

                    fullText = this.ScrollText;
                    fullText += new string(' ', 20);

                    taskScroll = new Task(() =>
                    {
                        try
                        {
                            ScrollTextFunc(fullText);
                        }
                        catch { }
                    }, tokenSource2.Token);
                    taskScroll.Start();
                }
                else
                {
                    try
                    {
                        this.Dispatcher.Dispatch(() =>
                        {
                            this.Text = ScrollText;
                            (this.Parent as Controls.ScrollingLabel)?.ShowFade(false, 0);
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ScrollingLabelInternal StartScroll error {ex.Message}");

                    }
                }
            }
        }

        void ScrollTextFunc(string fullText)
        {
            if (ct.IsCancellationRequested)
                ct.ThrowIfCancellationRequested();

            int startIndex = 0;
            while (!ct.IsCancellationRequested)
            {
                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();

                if (startIndex == 0)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        Thread.Sleep(100);

                        if (ct.IsCancellationRequested)
                            ct.ThrowIfCancellationRequested();
                    }
                }
                else
                    Thread.Sleep(100);

                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();

                string labelText = GetLabelTextNew(startIndex, fullText);
                this.Dispatcher.Dispatch(() => this.Text = labelText);
                startIndex = (startIndex + 1) % fullText.Length;
            }
        }
        string GetLabelTextNew(int startIndex, string fullText)
        {
            int viewLength = fullText.Length;
            string labelText;
            if (startIndex < fullText.Length)
                labelText = fullText.Substring(startIndex, Math.Min(viewLength, fullText.Length - startIndex));
            else
            {
                int textStartIndex = startIndex - fullText.Length;
                labelText = fullText.Substring(textStartIndex, Math.Min(viewLength, fullText.Length - textStartIndex));
            }

            //se rimane spazio aggiungo l'inizio della frase
            if (labelText.Length < viewLength)
                labelText += fullText.Substring(0, viewLength - labelText.Length);

            return labelText;
        }

        public bool StopScroll()
        {
            if (taskScroll != null)
                tokenSource2.Cancel();

            while (taskScroll != null && !taskScroll.IsCanceled && !taskScroll.IsFaulted &&
                                         !taskScroll.IsCompleted && taskScroll.Status == TaskStatus.Running)
            {
                //wait for task to cancel
            }

            return true;
        }
    }
}
