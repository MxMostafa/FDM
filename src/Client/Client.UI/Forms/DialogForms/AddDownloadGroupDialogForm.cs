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
    public partial class AddDownloadGroupDialogForm : MasterFixedDialogForm
    {
        public AddDownloadGroupDialogForm()
        {
            InitializeComponent();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // دسترسی به آیتم انتخاب شده
            var selectedIndex = radioGroup1.SelectedIndex;
            var selectedItem = radioGroup1.Properties.Items[selectedIndex].Description;

            if (selectedIndex == 0)
            {
                panelControl1.Visible = true;
                panelControl2.Visible = false;
            }


            else
                if (selectedIndex == 1)
            {
                panelControl2.Visible = true;
                panelControl1.Visible = false;

            }

        }

        private void AddDownloadGroupDialogForm_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;

        }

        private void UseAuthorizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseAuthorizationCheckBox.Checked)

                panelControl3.Enabled = true;

            else
                panelControl3.Enabled = false;
        }
    }
}
