

namespace Client.UI.UserControls.Common;

public partial class MxCancelButton : MxButton
{
    public MxCancelButton()
    {
        InitializeComponent();
        Text = "انصراف";
        DialogResult = DialogResult.Cancel;

    }
}
