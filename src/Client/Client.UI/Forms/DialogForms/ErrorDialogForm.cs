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
