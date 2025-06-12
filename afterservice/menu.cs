using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace afterservice
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button_dispatch_Click(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;


        }

        private void button_product_Click(object sender, EventArgs e)
        {
            
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            loginForm log = new loginForm();
            this.Hide();
            log.Show();
        }

        private void button_inventory_Click(object sender, EventArgs e)
        {
            
        }

        private void button_afterservice_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void customizeDesign()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

        }
        private void hideSubmenu()
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false; 
            if (panel5.Visible == true)
                panel5.Visible = false;
        }

        private void sohwSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;

        }

        private void button_inventory_Click_1(object sender, EventArgs e)
        {
            CreaterequirementMenu req = new CreaterequirementMenu();
            this.Hide();
            req.Show();
            sohwSubmenu(panel3);
        }

        private void button_record_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispatch dis = new Dispatch();
            this.Hide();
            dis.Show();
            sohwSubmenu(panel4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sohwSubmenu(panel5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Supplie sup = new Supplie();
            this.Hide();
            sup.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            record1 re = new record1();
            this.Hide();
            re.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
