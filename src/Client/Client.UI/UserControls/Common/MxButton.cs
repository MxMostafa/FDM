

namespace Client.UI.UserControls.Common;

public partial class MxButton : SimpleButton
{
    public MxButton()
    {
        InitializeComponent();
    }

    public void StartProcessingMode()
    {
        Enabled = false;

    }

    public void EndProcessingMode()
    {
        Enabled = true;
    }
}
