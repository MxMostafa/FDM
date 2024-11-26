using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.UI.Forms.DialogForms;

public partial class AddNewDownloadQueueDialogForm : MasterFixedDialogForm
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string DowanloadQueueTitle { get; set; }
    public AddNewDownloadQueueDialogForm()
    {
        InitializeComponent();
    }

    private void mxActionGroup1_SaveButtonClick(object sender, EventArgs e)
    {
        DowanloadQueueTitle = mxTextBox1.Text;
        DialogResult = DialogResult.OK;
        Close();
    }
}
