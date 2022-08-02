namespace IRPFStonks.View.Controls.Custom;

public partial class LabelWithUnderLine : ContentView
{
    public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(UnderlineColor),
                                                                                        typeof(Color),
                                                                                        typeof(LabelWithUnderLine),
                                                                                        Colors.BlanchedAlmond,
                                                                                        propertyChanged: UnderlinePropertyChanged);
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(TitleValue),
                                                                                    typeof(string),
                                                                                    typeof(LabelWithUnderLine),
                                                                                    string.Empty,
                                                                                    propertyChanged: TitleValuePropertyChanged);
    public static readonly BindableProperty DisplayProperty = BindableProperty.Create(nameof(DisplayValue),
                                                                                      typeof(string),
                                                                                      typeof(LabelWithUnderLine),
                                                                                      string.Empty,
                                                                                      propertyChanged: DisplayValuePropertyChanged);
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle),
                                                                                      typeof(Style),
                                                                                      typeof(LabelWithUnderLine),
                                                                                      null,
                                                                                      propertyChanged: TitleStylePropertyChanged);
    public static readonly BindableProperty StackOrientationProperty = BindableProperty.Create(nameof(StackOrientation),
                                                                                     typeof(StackOrientation),
                                                                                     typeof(LabelWithUnderLine),
                                                                                     StackOrientation.Horizontal,
                                                                                     propertyChanged: StackOrientationPropertyChanged);
    public Color UnderlineColor
    {
        get => (Color)GetValue(UnderlineProperty);
        set => SetValue(UnderlineProperty, value);
    }

    public string TitleValue
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string DisplayValue
    {
        get => (string)GetValue(DisplayProperty);
        set => SetValue(DisplayProperty, value);
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


    private static void UnderlinePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelWithUnderLine;
        control.Underline.Color = newValue as Color;
    }

    private static void TitleValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelWithUnderLine;
        control.Title.Text = newValue?.ToString();
    }

    private static void DisplayValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelWithUnderLine;
        control.Display.Text = newValue?.ToString();
    }


    private static void TitleStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelWithUnderLine;
        control.Title.Style = newValue as Style;
    }

    private static void StackOrientationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelWithUnderLine;
        control.Layout.Orientation = (StackOrientation) newValue;
    }


    public LabelWithUnderLine()
    {
        InitializeComponent();
    }

}
