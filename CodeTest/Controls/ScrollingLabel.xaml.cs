
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
                BindableProperty.Create(propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(ScrollingLabel),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanging: OnTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextChanged(BindableObject pObj, object pOldVal, object pNewVal)
        {
            (pObj as ScrollingLabel).lblText.ScrollText = pNewVal as string;
        }





        public static readonly BindableProperty FontSizeProperty =
                BindableProperty.Create(propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ScrollingLabel),
                defaultValue: 16d,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanging: OnFontSizeChanged);
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        private static void OnFontSizeChanged(BindableObject pObj, object pOldVal, object pNewVal)
        {
            if (pNewVal != null)
                (pObj as ScrollingLabel).lblText.FontSize = Convert.ToDouble(pNewVal);
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