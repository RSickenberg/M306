﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Sony_ICF_C717PJ
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

        private void Main_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            int fontLength = Properties.Resources.digital_7.Length;

            byte[] fontData = Properties.Resources.digital_7;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontData, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            label1.Font = new Font(pfc.Families[0], label1.Font.Size);
        }
    }
}
