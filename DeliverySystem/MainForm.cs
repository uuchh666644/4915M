using System;
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
        // 将StudentClass替换为DispatchClass
        DispatchClass dispatch = new DispatchClass();

        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 保留原有结构，但修改显示内容为调度相关数据
            label_total_dispatch.Text = "今日送货单数: " + dispatch.todayDispatchCount();
            label_pending.Text = "待处理: " + dispatch.pendingDispatchCount();
            label_completed.Text = "已完成: " + dispatch.completedDispatchCount();
        }

        // 以下面板绘制事件保持不变
        private void panel_slide_Paint(object sender, PaintEventArgs e)
        {
        }

        // 保持原有的子菜单设计方法
        private void customizeDesign()
        {
            panel_dispatchSubmenu.Visible = false;
            panel_receiptSubmenu.Visible = false;
            panel_reportSubmenu.Visible = false;
        }

        // 保持原有的隐藏子菜单方法
        private void hideSubmenu()
        {
            if (panel_dispatchSubmenu.Visible == true)
                panel_dispatchSubmenu.Visible = false;
            if (panel_receiptSubmenu.Visible == true)
                panel_receiptSubmenu.Visible = false;
            if (panel_reportSubmenu.Visible == true)
                panel_reportSubmenu.Visible = false;
        }

        // 保持原有的显示子菜单方法
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

        // 将学生按钮改为调度按钮
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

        // 将课程按钮改为收货按钮
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

        // 将成绩按钮改为报表按钮
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

        // 保持原有的子窗体打开方法不变
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

        // 保持原有的仪表板按钮方法不变
        private void dashboard_button_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
        }
    }
}