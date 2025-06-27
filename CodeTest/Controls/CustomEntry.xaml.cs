using System.Windows.Input;

namespace CodeTest.Controls;

public partial class CustomEntry : Entry
{
    public static readonly BindableProperty ParameterObjectProperty =
          BindableProperty.Create(nameof(ParameterObject), typeof(VisualElement), typeof(CustomEntry), null);
    public VisualElement ParameterObject
    {
        get => (VisualElement)GetValue(ParameterObjectProperty);
        set => SetValue(ParameterObjectProperty, value);
    }

    public static readonly BindableProperty TruncateValueProperty =
       BindableProperty.Create(nameof(TruncateValue), typeof(bool), typeof(CustomEntry), false);
    public bool TruncateValue
    {
        get => (bool)GetValue(TruncateValueProperty);
        set => SetValue(TruncateValueProperty, value);
    }

    public static readonly BindableProperty FullTextProperty =
       BindableProperty.Create(nameof(FullText), typeof(string), typeof(CustomEntry), string.Empty, defaultBindingMode: BindingMode.TwoWay);
    public string FullText
    {
        get => (string)GetValue(FullTextProperty);
        set => SetValue(FullTextProperty, value);
    }

    public static readonly BindableProperty OnFocusCommandProperty =
       BindableProperty.Create(nameof(OnFocusCommand), typeof(ICommand), typeof(CustomEntry), null);

    public ICommand OnFocusCommand
    {
        get { return (ICommand)GetValue(OnFocusCommandProperty); }
        set { SetValue(OnFocusCommandProperty, value); }
    }


    public static readonly BindableProperty OnFocusCommandParameterProperty =
      BindableProperty.Create(nameof(OnFocusCommandParameter), typeof(object), typeof(CustomEntry), null);

    public object OnFocusCommandParameter
    {
        get { return GetValue(OnFocusCommandParameterProperty); }
        set { SetValue(OnFocusCommandParameterProperty, value); }
    }


    //public ISsVirtualKeyboard VirtualKeyboardHandler { get; set; }

    public static readonly BindableProperty ShowKeyboardOnFocusProperty =
        BindableProperty.Create(
            "ShowKeyboardOnFocus",
            typeof(bool),
            typeof(ContentView),
            true);

    public CustomEntry()
    {
        InitializeComponent();
        Focused += OnFocused;
        TextChanged += TruncateForDisplay;

    }
    /// <summary>
    /// Mostra la tastiera al focus sullla entry (default true). Per alcune entry (Es. EAN va messo a false)
    /// </summary>
    public bool ShowKeyboardOnFocus
    {
        get
        {
            //SetValue(ShowKeyboardOnFocusProperty, !settingsService.AppSettings.IsBuiltinKeyboard);
            return (bool)GetValue(ShowKeyboardOnFocusProperty);
        }
        set
        {
            //value = !settingsService.AppSettings.IsBuiltinKeyboard;
            SetValue(ShowKeyboardOnFocusProperty, value);
        }
    }

    public new bool Focus()
    {
        base.Focus();

        return true;
    }

    private void OnFocused(object sender, FocusEventArgs e)
    {
        if (e.IsFocused)
        {
            //if (ShowKeyboardOnFocus)
            //    ShowKeyboard();
            //else
            //    HideKeyboard();

            OnFocusCommand?.Execute(OnFocusCommandParameter);
        }
    }

    //public void ShowKeyboard()
    //{
    //    if (VirtualKeyboardHandler != null)
    //        VirtualKeyboardHandler.ShowKeyboard();
    //}

    //public void HideKeyboard()
    //{
    //    if (VirtualKeyboardHandler != null)
    //        VirtualKeyboardHandler.HideKeyboard();

    //}
    private void TruncateForDisplay(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.OldTextValue))
        {
            var value = CustomEntryView.Text;
            var length = (int)CustomEntryView.Width / 10;
            if (string.IsNullOrEmpty(value))
                value = "";
            var truncatedValue = value;
            FullText = value;
            if (value.Length > length)
            {
                if (string.IsNullOrEmpty(value))
                    truncatedValue = value;
                else if (TruncateValue)
                    truncatedValue = value.Substring(0, length) + "...";
            }
            CustomEntryView.Text = truncatedValue;
        }
    }

}