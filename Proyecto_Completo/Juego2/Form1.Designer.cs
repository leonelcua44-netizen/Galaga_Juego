namespace Juego2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Player = new System.Windows.Forms.PictureBox();
            this.MoverBgTimer = new System.Windows.Forms.Timer(this.components);
            this.DerechaTimer = new System.Windows.Forms.Timer(this.components);
            this.IzquierdaTimer = new System.Windows.Forms.Timer(this.components);
            this.ArribaTimer = new System.Windows.Forms.Timer(this.components);
            this.AbajoTimer = new System.Windows.Forms.Timer(this.components);
            this.MoverMunicion = new System.Windows.Forms.Timer(this.components);
            this.MoverEnemigos = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(194, 318);
            this.Player.Margin = new System.Windows.Forms.Padding(2);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(38, 41);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // MoverBgTimer
            // 
            this.MoverBgTimer.Enabled = true;
            this.MoverBgTimer.Interval = 20;
            // 
            // DerechaTimer
            // 
            this.DerechaTimer.Interval = 5;
            this.DerechaTimer.Tick += new System.EventHandler(this.DerechaTimer_Tick);
            // 
            // IzquierdaTimer
            // 
            this.IzquierdaTimer.Interval = 5;
            this.IzquierdaTimer.Tick += new System.EventHandler(this.IzquierdaTimer_Tick);
            // 
            // ArribaTimer
            // 
            this.ArribaTimer.Interval = 5;
            this.ArribaTimer.Tick += new System.EventHandler(this.ArribaTimer_Tick);
            // 
            // AbajoTimer
            // 
            this.AbajoTimer.Interval = 5;
            this.AbajoTimer.Tick += new System.EventHandler(this.AbajoTimer_Tick);
            // 
            // MoverMunicion
            // 
            this.MoverMunicion.Interval = 20;
            this.MoverMunicion.Tick += new System.EventHandler(this.MoverMunicion_Tick);
            // 
            // MoverEnemigos
            // 
            this.MoverEnemigos.Tick += new System.EventHandler(this.MoverEnemigos_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(436, 368);
            this.Controls.Add(this.Player);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Galaga";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer MoverBgTimer;
        private System.Windows.Forms.Timer DerechaTimer;
        private System.Windows.Forms.Timer IzquierdaTimer;
        private System.Windows.Forms.Timer ArribaTimer;
        private System.Windows.Forms.Timer AbajoTimer;
        private System.Windows.Forms.Timer MoverMunicion;
        private System.Windows.Forms.Timer MoverEnemigos;
        private System.Windows.Forms.Timer timer1;
    }
}

