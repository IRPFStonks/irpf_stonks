namespace IRPFStonks.View.Controls;

public partial class LossesDisplay : ContentView
{
	public LossesDisplay()
	{
		InitializeComponent();

	}
}

public class Loss
{
	public string Month { get; set; }
	public double Value { get; set; }
}