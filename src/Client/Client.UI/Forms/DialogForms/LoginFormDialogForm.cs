namespace Client.UI.Forms.DialogForms
{
    public partial class LoginFormDialogForm : MasterFixedDialogForm
    {
        public LoginFormDialogForm()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPageIndex = 1;
        }
    }
}
