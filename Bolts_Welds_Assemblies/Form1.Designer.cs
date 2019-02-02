namespace Bolts_Welds_Assemblies
{
    partial class frm_Bolts_Welds_Assemblies
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
            this.btn_Bolt = new System.Windows.Forms.Button();
            this.btn_Weld = new System.Windows.Forms.Button();
            this.btn_Add_To = new System.Windows.Forms.Button();
            this.btn_Get_Assembly = new System.Windows.Forms.Button();
            this.btn_Set_Workplane = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Bolt
            // 
            this.btn_Bolt.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Bolt.Location = new System.Drawing.Point(38, 12);
            this.btn_Bolt.Name = "btn_Bolt";
            this.btn_Bolt.Size = new System.Drawing.Size(90, 23);
            this.btn_Bolt.TabIndex = 0;
            this.btn_Bolt.Text = "Bolt";
            this.btn_Bolt.UseVisualStyleBackColor = false;
            this.btn_Bolt.Click += new System.EventHandler(this.btn_Bolt_Click);
            // 
            // btn_Weld
            // 
            this.btn_Weld.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Weld.Location = new System.Drawing.Point(38, 42);
            this.btn_Weld.Name = "btn_Weld";
            this.btn_Weld.Size = new System.Drawing.Size(90, 23);
            this.btn_Weld.TabIndex = 1;
            this.btn_Weld.Text = "Weld";
            this.btn_Weld.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Weld.UseVisualStyleBackColor = false;
            this.btn_Weld.Click += new System.EventHandler(this.btn_Weld_Click);
            // 
            // btn_Add_To
            // 
            this.btn_Add_To.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Add_To.Location = new System.Drawing.Point(38, 71);
            this.btn_Add_To.Name = "btn_Add_To";
            this.btn_Add_To.Size = new System.Drawing.Size(90, 23);
            this.btn_Add_To.TabIndex = 2;
            this.btn_Add_To.Text = "Add To";
            this.btn_Add_To.UseVisualStyleBackColor = false;
            this.btn_Add_To.Click += new System.EventHandler(this.btn_Add_To_Click);
            // 
            // btn_Get_Assembly
            // 
            this.btn_Get_Assembly.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Get_Assembly.Location = new System.Drawing.Point(38, 100);
            this.btn_Get_Assembly.Name = "btn_Get_Assembly";
            this.btn_Get_Assembly.Size = new System.Drawing.Size(90, 23);
            this.btn_Get_Assembly.TabIndex = 3;
            this.btn_Get_Assembly.Text = "Get Assembly";
            this.btn_Get_Assembly.UseVisualStyleBackColor = false;
            this.btn_Get_Assembly.Click += new System.EventHandler(this.btn_Get_Assembly_Click);
            // 
            // btn_Set_Workplane
            // 
            this.btn_Set_Workplane.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Set_Workplane.Location = new System.Drawing.Point(158, 12);
            this.btn_Set_Workplane.Name = "btn_Set_Workplane";
            this.btn_Set_Workplane.Size = new System.Drawing.Size(91, 23);
            this.btn_Set_Workplane.TabIndex = 4;
            this.btn_Set_Workplane.Text = "Set Workplane";
            this.btn_Set_Workplane.UseVisualStyleBackColor = false;
            this.btn_Set_Workplane.Click += new System.EventHandler(this.btn_Set_Workplane_Click);
            // 
            // frm_Bolts_Welds_Assemblies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(295, 142);
            this.Controls.Add(this.btn_Set_Workplane);
            this.Controls.Add(this.btn_Get_Assembly);
            this.Controls.Add(this.btn_Add_To);
            this.Controls.Add(this.btn_Weld);
            this.Controls.Add(this.btn_Bolt);
            this.Name = "frm_Bolts_Welds_Assemblies";
            this.Text = "Bolts Welds and Assemblies";
            this.Load += new System.EventHandler(this.frm_Bolts_Welds_Assemblies_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Bolt;
        private System.Windows.Forms.Button btn_Weld;
        private System.Windows.Forms.Button btn_Add_To;
        private System.Windows.Forms.Button btn_Get_Assembly;
        private System.Windows.Forms.Button btn_Set_Workplane;
    }
}

