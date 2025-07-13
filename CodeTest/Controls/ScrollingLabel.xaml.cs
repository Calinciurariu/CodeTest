namespace CodeTest.Controls
{
    public partial class ScrollingLabel : Grid
    {
        public ScrollingLabel()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty GradientColorProperty = BindableProperty.Create(
             nameof(GradientColor), typeof(Color), typeof(ScrollingLabel), Color.FromArgb("#ffffff"));
        public Color GradientColor
        {
            get { return (Color)GetValue(GradientColorProperty); }
            set { SetValue(GradientColorProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
                BindableProperty.Create(nameof(Text), typeof(string), typeof(ScrollingLabel), string.Empty);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
                BindableProperty.Create(nameof(FontSize), typeof(double), typeof(ScrollingLabel), 16d);
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // NEW: Add TextColor property
        public static readonly BindableProperty TextColorProperty =
                BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ScrollingLabel), Colors.Black);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        // NEW: Add FontAttributes property
        public static readonly BindableProperty FontAttributesProperty =
                BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(ScrollingLabel), FontAttributes.None);
        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public void ShowFade(bool show, double lengthOfThreeDotsByFontsize)
        {
            if (show)
            {
                double calc_lengthOfThreeDotsByFontsize = 10d;
                if (lengthOfThreeDotsByFontsize > 10d)
                    calc_lengthOfThreeDotsByFontsize = lengthOfThreeDotsByFontsize;

                fadeLeft.WidthRequest = calc_lengthOfThreeDotsByFontsize;
                fadeRight.WidthRequest = calc_lengthOfThreeDotsByFontsize * 1.9d;

                this.ColumnDefinitions = new ColumnDefinitionCollection
                {
                     new ColumnDefinition{ Width = 10 },
                     new ColumnDefinition{ Width = GridLength.Star }
                };

                fadeLeft.IsVisible = true;
                fadeRight.IsVisible = true;
            }
            else
            {
                fadeLeft.IsVisible = false;
                fadeRight.IsVisible = false;

                this.ColumnDefinitions = new ColumnDefinitionCollection
                {
                     new ColumnDefinition{ Width = 0.001 },
                     new ColumnDefinition{ Width = GridLength.Star }
                };
            }
        }
    }
}