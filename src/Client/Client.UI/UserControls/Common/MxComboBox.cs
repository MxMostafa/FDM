namespace Client.UI.UserControls.Common
{
    public partial class MxComboBox : LookUpEdit
    {
        public MxComboBox()
        {
            InitializeComponent();
            Properties.PopupFilterMode = PopupFilterMode.Contains;
        }
    }
}
