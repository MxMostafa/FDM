using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UI.Forms.DialogForms
{
    public partial class AddDownloadNewAddressDialogForm : MasterFixedDialogForm
    {
        public AddDownloadNewAddressDialogForm(ILogger<AddDownloadNewAddressDialogForm> logger) : base(logger)
        {
            InitializeComponent();
        }

        private void UseAuthorizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseAuthorizationCheckBox.Checked)
            
                panelControl1.Enabled = true;
            
            else
                panelControl1.Enabled = false;
        }
    }
}
