namespace EM
{
    partial class update
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
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.textBoxMobilePhone = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Items.AddRange(new object[] {
            "BBAC",
            "BAIC",
            "Daimler",
            "Supplier"});
            this.comboBoxCompany.Location = new System.Drawing.Point(92, 71);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(96, 20);
            this.comboBoxCompany.TabIndex = 22;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(92, 96);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(96, 20);
            this.comboBoxDepartment.TabIndex = 23;
            this.comboBoxDepartment.Visible = false;
            this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(92, 45);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(96, 20);
            this.comboBoxLevel.TabIndex = 24;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(92, 122);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(96, 20);
            this.comboBoxGroup.TabIndex = 25;
            this.comboBoxGroup.Visible = false;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(92, 148);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(96, 20);
            this.comboBoxTeam.TabIndex = 26;
            this.comboBoxTeam.Visible = false;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(45, 48);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(35, 12);
            this.labelLevel.TabIndex = 31;
            this.labelLevel.Text = "Level";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(39, 74);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(47, 12);
            this.labelCompany.TabIndex = 30;
            this.labelCompany.Text = "Company";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Location = new System.Drawing.Point(51, 151);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(29, 12);
            this.labelTeam.TabIndex = 29;
            this.labelTeam.Text = "Team";
            this.labelTeam.Visible = false;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(51, 126);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(35, 12);
            this.labelGroup.TabIndex = 28;
            this.labelGroup.Text = "Group";
            this.labelGroup.Visible = false;
            // 
            // labelDepartment
            // 
            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Location = new System.Drawing.Point(21, 99);
            this.labelDepartment.Name = "labelDepartment";
            this.labelDepartment.Size = new System.Drawing.Size(65, 12);
            this.labelDepartment.TabIndex = 27;
            this.labelDepartment.Text = "Department";
            this.labelDepartment.Visible = false;
            // 
            // textBoxMobilePhone
            // 
            this.textBoxMobilePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMobilePhone.Location = new System.Drawing.Point(277, 44);
            this.textBoxMobilePhone.Name = "textBoxMobilePhone";
            this.textBoxMobilePhone.Size = new System.Drawing.Size(329, 21);
            this.textBoxMobilePhone.TabIndex = 38;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new System.Drawing.Point(278, 98);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(329, 21);
            this.textBoxEmail.TabIndex = 37;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(278, 71);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(329, 21);
            this.textBoxPhoneNumber.TabIndex = 36;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(202, 139);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(65, 29);
            this.buttonUpdate.TabIndex = 39;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "MobilePhone";
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxMobilePhone);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelDepartment);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxCompany);
            this.Name = "update";
            this.Text = "update";
            this.Load += new System.EventHandler(this.update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.TextBox textBoxMobilePhone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}