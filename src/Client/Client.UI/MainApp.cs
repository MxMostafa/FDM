using Client.Infra.DbContexts;
using Client.UI.Extensions;
using Client.UI.Forms.DialogForms;
using DevExpress.XtraBars;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UI
{
    public partial class MainApp : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        public MainApp( )
        {
            InitializeComponent();
        }

        private void SettingButton_ItemClick(object sender, ItemClickEventArgs e)
        {
      
        }



        
    }
}