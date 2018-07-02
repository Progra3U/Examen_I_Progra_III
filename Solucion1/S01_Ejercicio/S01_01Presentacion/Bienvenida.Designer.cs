namespace S01_01Presentacion
{
    partial class Bienvenida
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
            this.NOMBREUSUARIO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NOMBREUSUARIO
            // 
            this.NOMBREUSUARIO.AutoSize = true;
            this.NOMBREUSUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBREUSUARIO.Location = new System.Drawing.Point(26, 197);
            this.NOMBREUSUARIO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NOMBREUSUARIO.Name = "NOMBREUSUARIO";
            this.NOMBREUSUARIO.Size = new System.Drawing.Size(792, 46);
            this.NOMBREUSUARIO.TabIndex = 0;
            this.NOMBREUSUARIO.Text = "   BIENVENIDO A NUESTRA APLICACION";
            this.NOMBREUSUARIO.Click += new System.EventHandler(this.label1_Click);
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(864, 557);
            this.Controls.Add(this.NOMBREUSUARIO);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NOMBREUSUARIO;
    }
}