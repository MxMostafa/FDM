namespace Client.UI.UserControls.Common
{
    public partial class MxRadioButton : CheckEdit
    {
        public MxRadioButton()
        {
            InitializeComponent();
            Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
        }
    }
}
