
namespace afterservice
{
    partial class DeliveryOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTime = new System.Windows.Forms.Label();
            this.l_Time = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.l_Date = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDeliveryOrderForm = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxCustomerInformationGroupbox = new System.Windows.Forms.GroupBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.groupBoxCustomerInformationGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTime.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelTime.Location = new System.Drawing.Point(776, 29);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(76, 17);
            this.labelTime.TabIndex = 101;
            this.labelTime.Text = "HH:MM:SS";
            this.labelTime.Click += new System.EventHandler(this.TimerDateTime_Tick);
            // 
            // l_Time
            // 
            this.l_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Time.AutoSize = true;
            this.l_Time.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Time.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.l_Time.Location = new System.Drawing.Point(724, 29);
            this.l_Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_Time.Name = "l_Time";
            this.l_Time.Size = new System.Drawing.Size(55, 19);
            this.l_Time.TabIndex = 27;
            this.l_Time.Text = "Time :";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDate.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDate.Location = new System.Drawing.Point(776, 9);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(96, 17);
            this.labelDate.TabIndex = 100;
            this.labelDate.Text = "YYYY-MM-DD";
            this.labelDate.Click += new System.EventHandler(this.TimerDateTime_Tick);
            // 
            // l_Date
            // 
            this.l_Date.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l_Date.AutoSize = true;
            this.l_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Date.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.l_Date.Location = new System.Drawing.Point(724, 6);
            this.l_Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_Date.Name = "l_Date";
            this.l_Date.Size = new System.Drawing.Size(52, 20);
            this.l_Date.TabIndex = 25;
            this.l_Date.Text = "Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.labelDeliveryOrderForm);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.l_Time);
            this.panel1.Controls.Add(this.l_Date);
            this.panel1.Controls.Add(this.labelDate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 90);
            this.panel1.TabIndex = 44;
            // 
            // labelDeliveryOrderForm
            // 
            this.labelDeliveryOrderForm.AutoSize = true;
            this.labelDeliveryOrderForm.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDeliveryOrderForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDeliveryOrderForm.Location = new System.Drawing.Point(350, 35);
            this.labelDeliveryOrderForm.Name = "labelDeliveryOrderForm";
            this.labelDeliveryOrderForm.Size = new System.Drawing.Size(145, 21);
            this.labelDeliveryOrderForm.TabIndex = 0;
            this.labelDeliveryOrderForm.Text = "Delivery Order";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 97);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(569, 287);
            this.dataGridViewProducts.TabIndex = 45;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 12);
            this.labelName.TabIndex = 55;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(53, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 22);
            this.textBoxName.TabIndex = 54;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // groupBoxCustomerInformationGroupbox
            // 
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.labelAddress);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.textBoxAddress);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.labelEmail);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.textBoxEmail);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.labelPhone);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.textBoxPhone);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.textBoxName);
            this.groupBoxCustomerInformationGroupbox.Controls.Add(this.labelName);
            this.groupBoxCustomerInformationGroupbox.Location = new System.Drawing.Point(587, 97);
            this.groupBoxCustomerInformationGroupbox.Name = "groupBoxCustomerInformationGroupbox";
            this.groupBoxCustomerInformationGroupbox.Size = new System.Drawing.Size(286, 137);
            this.groupBoxCustomerInformationGroupbox.TabIndex = 56;
            this.groupBoxCustomerInformationGroupbox.TabStop = false;
            this.groupBoxCustomerInformationGroupbox.Text = "Add to receipt";

            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(3, 110);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(42, 12);
            this.labelAddress.TabIndex = 61;
            this.labelAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(53, 105);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(100, 22);
            this.textBoxAddress.TabIndex = 60;

            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(13, 82);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 12);
            this.labelEmail.TabIndex = 59;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(53, 77);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 22);
            this.textBoxEmail.TabIndex = 58;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(13, 54);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(34, 12);
            this.labelPhone.TabIndex = 57;
            this.labelPhone.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(53, 49);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(100, 22);
            this.textBoxPhone.TabIndex = 56;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBoxPhone_TextChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(8, 410);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(200, 23);
            this.labelTotal.TabIndex = 57;
            this.labelTotal.Text = "Total";
            this.labelTotal.Click += new System.EventHandler(this.labelTotal_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(592, 409);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 58;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(673, 409);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 60;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(754, 409);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 61;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // DeliveryOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.groupBoxCustomerInformationGroupbox);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.panel1);
            this.Name = "DeliveryOrderForm";
            this.Text = "DeliveryOrderForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.groupBoxCustomerInformationGroupbox.ResumeLayout(false);
            this.groupBoxCustomerInformationGroupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label l_Time;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label l_Date;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDeliveryOrderForm;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxCustomerInformationGroupbox;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonBack;
    }
}