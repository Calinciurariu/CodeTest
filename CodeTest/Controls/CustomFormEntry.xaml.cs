using System.Windows.Input;

namespace CodeTest.Controls;

public partial class CustomFormEntry : Grid
{
    public static readonly BindableProperty ParameterObjectProperty =
         BindableProperty.Create(nameof(ParameterObject), typeof(VisualElement), typeof(CustomFormEntry), null);
    public VisualElement ParameterObject
    {
        get => (VisualElement)GetValue(ParameterObjectProperty);
        set => SetValue(ParameterObjectProperty, value);
    }

    public static readonly BindableProperty CompletedEventToCommandProperty =
         BindableProperty.Create(nameof(CompletedEventToCommand), typeof(ICommand), typeof(CustomFormEntry
             ), null);

    public ICommand CompletedEventToCommand
    {
        get { return (ICommand)GetValue(CompletedEventToCommandProperty); }
        set { SetValue(CompletedEventToCommandProperty, value); }
    }


    public static readonly BindableProperty IsPasswordProperty =
     BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(CustomFormEntry), false);

    public bool IsPassword
    {
        get { return (bool)GetValue(IsPasswordProperty); }
        set { SetValue(IsPasswordProperty, value); }
    }


    public static readonly BindableProperty KeyboardProperty =
        BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(CustomFormEntry), Keyboard.Default);
    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public static readonly BindableProperty OnFocusCommandProperty =
       BindableProperty.Create(nameof(OnFocusCommand), typeof(ICommand), typeof(CustomFormEntry), null);

    public ICommand OnFocusCommand
    {
        get { return (ICommand)GetValue(OnFocusCommandProperty); }
        set { SetValue(OnFocusCommandProperty, value); }
    }


    public static readonly BindableProperty OnFocusCommandParameterProperty =
      BindableProperty.Create(nameof(OnFocusCommandParameter), typeof(object), typeof(CustomFormEntry), null);

    public object OnFocusCommandParameter
    {
        get { return GetValue(OnFocusCommandParameterProperty); }
        set { SetValue(OnFocusCommandParameterProperty, value); }
    }

    public static readonly BindableProperty TruncateValueProperty =
       BindableProperty.Create(nameof(TruncateValue), typeof(bool), typeof(CustomFormEntry), false);
    public bool TruncateValue
    {
        get => (bool)GetValue(TruncateValueProperty);
        set => SetValue(TruncateValueProperty, value);
    }

    public static readonly BindableProperty FullTextProperty =
      BindableProperty.Create(nameof(FullText), typeof(string), typeof(CustomFormEntry), string.Empty, defaultBindingMode: BindingMode.TwoWay);
    public string FullText
    {
        get => (string)GetValue(FullTextProperty);
        set => SetValue(FullTextProperty, value);
    }

    public static readonly BindableProperty MaxLengthProperty =
  BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(CustomFormEntry), int.MaxValue);
    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    //public ISsVirtualKeyboard VirtualKeyboardHandler { get; set; }

    public static readonly BindableProperty ShowKeyboardOnFocusProperty =
        BindableProperty.Create(
            "ShowKeyboardOnFocus",
            typeof(bool),
            typeof(ContentView),
            true);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string),
        typeof(CustomFormEntry), "", BindingMode.TwoWay);
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string),
            typeof(CustomFormEntry), "");
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(string),
            typeof(CustomFormEntry));
    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly BindableProperty HorizontalTextAlignmentProperty =
        BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment),
            typeof(CustomFormEntry), TextAlignment.Start);
    public TextAlignment HorizontalTextAlignment
    {
        get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
        set { SetValue(HorizontalTextAlignmentProperty, value); }
    }

    public static readonly BindableProperty IsReadOnlyProperty =
        BindableProperty.Create(nameof(IsReadOnly), typeof(bool),
            typeof(CustomFormEntry), false);
    public bool IsReadOnly
    {
        get { return (bool)GetValue(IsReadOnlyProperty); }
        set { SetValue(IsReadOnlyProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string),
            typeof(CustomFormEntry));
    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(string),
            typeof(CustomFormEntry));

    public string FontSize
    {
        get { return (string)GetValue(FontSizeProperty); }
        set
        {
            SetValue(FontSizeProperty, value);
            OnPropertyChanged(nameof(FontSizeInternal));
        }
    }

    public double FontSizeInternal
    {
        get
        {
            if (string.IsNullOrEmpty(FontSize))
                return Device.GetNamedSize(NamedSize.Default, typeof(CustomEntry));
            if (double.TryParse(FontSize, out double result))
                return result;
            return Device.GetNamedSize(
                (NamedSize)Enum.Parse(typeof(NamedSize), FontSize)
                , typeof(CustomEntry));
        }
    }

    public static readonly BindableProperty ClearButtonVisibilityProperty =
        BindableProperty.Create(nameof(FontSize), typeof(ClearButtonVisibility),
            typeof(CustomFormEntry));
    public ClearButtonVisibility ClearButtonVisibility
    {
        get { return (ClearButtonVisibility)GetValue(ClearButtonVisibilityProperty); }
        set { SetValue(ClearButtonVisibilityProperty, value); }
    }

    public CustomFormEntry()
    {
        InitializeComponent();
        Focused += OnFocused;
    }

    private void OnFocused(object? sender, FocusEventArgs e)
    {
        if (e.IsFocused)
            OnFocusCommand?.Execute(OnFocusCommandParameter);    
    }
}