namespace Client.UI.UserControls.Common
{
    public partial class MxAcceptActionGroup : UserControl
    {
        public event EventHandler ConfirmButtonClick;
        public MxAcceptActionGroup()
        {
            InitializeComponent();
            saveButton.Click += (sender, e) => OnSaveButtonClick();
        }

        protected virtual void OnSaveButtonClick()
        {
            ConfirmButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public void StartProcessingMode()
        {
            saveButton.StartProcessingMode();

        }

        public void EndProcessingMode()
        {
            saveButton.EndProcessingMode();
        }
    }
}
