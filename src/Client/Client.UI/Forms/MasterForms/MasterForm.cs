using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UI.Forms.MasterForms
{
    public partial class MasterForm : XtraForm
    {
        private readonly IServiceProvider _serviceProvider;
        public MasterForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private TForm GetForm<TForm>() where TForm : Form
        {
            return _serviceProvider.GetRequiredService<TForm>();
        }
    }
}
