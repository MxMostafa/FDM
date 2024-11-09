using System;
using System.Collections.Generic;

namespace Client.UI.Forms.DialogForms;

public partial class AddNewDownloadQueueDialogForm : MasterFixedDialogForm
{
    public string DowanloadQueueTitle { get; set; }
    public AddNewDownloadQueueDialogForm(ILogger<AddNewDownloadQueueDialogForm> logger) : base(logger)
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
