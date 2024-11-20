﻿using System;
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
    public partial class MxComboBox : LookUpEdit
    {
        public MxComboBox()
        {
            InitializeComponent();
            Properties.PopupFilterMode = PopupFilterMode.Contains;
        }
    }
}