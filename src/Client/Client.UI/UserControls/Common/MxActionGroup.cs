namespace Client.UI.UserControls.Common
{
    public partial class MxActionGroup : UserControl
    {
        public event EventHandler SaveButtonClick;
        public MxActionGroup()
        {
            InitializeComponent();
            saveButton.Click += (sender, e) => OnSaveButtonClick();
        }

        protected virtual void OnSaveButtonClick()
        {
            SaveButtonClick?.Invoke(this, EventArgs.Empty);
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
