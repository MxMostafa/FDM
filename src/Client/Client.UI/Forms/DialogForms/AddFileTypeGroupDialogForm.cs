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
    public partial class AddFileTypeGroupDialogForm : MasterFixedDialogForm
    {

        public string Title { get; set; }
        public string suffixName { get; set; }
        public AddFileTypeGroupDialogForm()
        {
            InitializeComponent();
        }

        private void mxActionGroup1_SaveButtonClick(object sender, EventArgs e)
        {
            Title = mxTextBox1.Text;
            suffixName = mxAreaTextBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
