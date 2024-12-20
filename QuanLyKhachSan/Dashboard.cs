﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace QuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();         
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRes1.Visible = false;
            uC_CheckOut1.Visible = false;
            btnAddRoom.PerformClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uC_AddRoom1_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomerRes_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerRes.Left+22;
            uC_CustomerRes1.Visible = true;
            uC_CustomerRes1.BringToFront();
        }

        private void btnAddRoom_Click_1(object sender, EventArgs e)
        {
            PanelMoving.Left = 15;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void bthCheckOut_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = 516;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
        }
    }
}
