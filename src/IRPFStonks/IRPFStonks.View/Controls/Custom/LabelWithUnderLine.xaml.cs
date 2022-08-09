namespace IRPFStonks.View.Controls.Custom;

public partial class LabelWithUnderLine : ContentView
{
    public static readonly BindableProperty UnderlineColorProperty = BindableProperty.Create(nameof(UnderlineColor),
                                                                                        typeof(Color),
                                                                                        typeof(LabelWithUnderLine),
                                                                                        Colors.BlanchedAlmond);
    public static readonly BindableProperty TitleValueProperty = BindableProperty.Create(nameof(TitleValue),
                                                                                    typeof(string),
                                                                                    typeof(LabelWithUnderLine),
                                                                                    string.Empty);
    public static readonly BindableProperty DisplayValueProperty = BindableProperty.Create(nameof(DisplayValue),
                                                                                      typeof(string),
                                                                                      typeof(LabelWithUnderLine),
                                                                                      string.Empty);
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle),
                                                                                      typeof(Style),
                                                                                      typeof(LabelWithUnderLine),
                                                                                      null);
    public static readonly BindableProperty StackOrientationProperty = BindableProperty.Create(nameof(StackOrientation),
                                                                                     typeof(StackOrientation),
                                                                                     typeof(LabelWithUnderLine),
                                                                                     StackOrientation.Horizontal);
    public Color UnderlineColor
    {
        get => (Color)GetValue(UnderlineColorProperty);
        set => SetValue(UnderlineColorProperty, value);
    }

    public string TitleValue
    {
        get => (string)GetValue(TitleValueProperty);
        set => SetValue(TitleValueProperty, value);
    }

    public string DisplayValue
    {
        get => (string)GetValue(DisplayValueProperty);
        set => SetValue(DisplayValueProperty, value);
    }

    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public StackOrientation StackOrientation
    {
        get => (StackOrientation)GetValue(StackOrientationProperty);
        set => SetValue(StackOrientationProperty, value);
    }


    public LabelWithUnderLine()
    {
        InitializeComponent();
    }

}
