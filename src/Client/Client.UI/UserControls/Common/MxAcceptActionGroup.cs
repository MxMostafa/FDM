using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
