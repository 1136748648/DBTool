namespace FDBIntercross
{
    partial class DBConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_Ip = new System.Windows.Forms.TextBox();
            this.txb_User = new System.Windows.Forms.TextBox();
            this.txb_Pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_DbDefault = new System.Windows.Forms.ComboBox();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库服务:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码:";
            // 
            // txb_Ip
            // 
            this.txb_Ip.Location = new System.Drawing.Point(107, 27);
            this.txb_Ip.Name = "txb_Ip";
            this.txb_Ip.Size = new System.Drawing.Size(152, 21);
            this.txb_Ip.TabIndex = 3;
            // 
            // txb_User
            // 
            this.txb_User.Location = new System.Drawing.Point(107, 67);
            this.txb_User.Name = "txb_User";
            this.txb_User.Size = new System.Drawing.Size(152, 21);
            this.txb_User.TabIndex = 4;
            // 
            // txb_Pwd
            // 
            this.txb_Pwd.Location = new System.Drawing.Point(107, 109);
            this.txb_Pwd.Name = "txb_Pwd";
            this.txb_Pwd.Size = new System.Drawing.Size(151, 21);
            this.txb_Pwd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "默认库:";
            // 
            // cbx_DbDefault
            // 
            this.cbx_DbDefault.FormattingEnabled = true;
            this.cbx_DbDefault.Location = new System.Drawing.Point(107, 154);
            this.cbx_DbDefault.Name = "cbx_DbDefault";
            this.cbx_DbDefault.Size = new System.Drawing.Size(152, 20);
            this.cbx_DbDefault.TabIndex = 7;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(286, 107);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 8;
            this.btn_Test.Text = "测试";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(153, 210);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // DBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 275);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.cbx_DbDefault);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_Pwd);
            this.Controls.Add(this.txb_User);
            this.Controls.Add(this.txb_Ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_Ip;
        private System.Windows.Forms.TextBox txb_User;
        private System.Windows.Forms.TextBox txb_Pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_DbDefault;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_Save;
    }
}