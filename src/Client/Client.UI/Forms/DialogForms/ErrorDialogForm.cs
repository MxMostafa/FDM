namespace Client.UI.Forms.DialogForms
{
    public partial class ErrorDialogForm : MasterFixedDialogForm
    {
        public ErrorDialogForm(string error)
        {
            InitializeComponent();
            errorContentLabel.Text = error;
            Icon = SystemIcons.Error;
            // پخش صدای خطا
            System.Media.SystemSounds.Hand.Play();
        }
    }
}
