﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispatch_Processing_System
{
    public partial class MainForm : Form
    {
        // Replace StudentClass with DispatchClass
        DispatchClass dispatch = new DispatchClass();

        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Keep original structure, but modify display content for dispatch-related data
            label_total_dispatch.Text = "Today's Delivery Orders: " + dispatch.TodayDispatchCount();
            label_pending.Text = "Pending: " + dispatch.PendingDispatchCount();
            label_completed.Text = "Completed: " + dispatch.CompletedDispatchCount();
        }

        // Keep the following panel paint event unchanged
        private void panel_slide_Paint(object sender, PaintEventArgs e)
        {
        }

        // Keep the original custom submenu design method
        private void customizeDesign()
        {
            panel_dispatchSubmenu.Visible = false;
            panel_receiptSubmenu.Visible = false;
            panel_reportSubmenu.Visible = false;
        }

        // Keep the original method for hiding submenus
        private void hideSubmenu()
        {
            if (panel_dispatchSubmenu.Visible == true)
                panel_dispatchSubmenu.Visible = false;
            if (panel_receiptSubmenu.Visible == true)
                panel_receiptSubmenu.Visible = false;
            if (panel_reportSubmenu.Visible == true)
                panel_reportSubmenu.Visible = false;
        }

        // Keep the original method for showing submenus
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        // Change the Student button to the Dispatch button
        private void button_dispatch_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_dispatchSubmenu);
        }

        #region DispatchSubmenu
        private void button_createDispatch_Click(object sender, EventArgs e)
        {
            openChildForm(new CreateDispatchForm());
            hideSubmenu();
        }

        private void button_manageDispatch_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageDispatch());
            hideSubmenu();
        }

        private void button_printDispatch_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintDispatch());
            hideSubmenu();
        }
        #endregion

        // Change the Course button to the Receipt button
        private void button_receipt_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_receiptSubmenu);
        }

        #region ReceiptSubmenu
        private void button_recordReceipt_Click(object sender, EventArgs e)
        {
            openChildForm(new RecordReceiptForm());
            hideSubmenu();
        }

        private void button_manageReceipt_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageReceipt());
            hideSubmenu();
        }

        private void button_printReceipt_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion

        // Change the Score button to the Report button
        private void button_report_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_reportSubmenu);
        }

        #region ReportSubmenu
        private void button_dispatchReport_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button_receiptReport_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button_inventoryReport_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion

        // Keep the original method for opening child forms
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Keep the original dashboard button method unchanged
        private void dashboard_button_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
        }
    }
}