namespace chat_winforms_1
{
    partial class c1
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
            this.btn_conectar = new System.Windows.Forms.Button();
            this.btn_listener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_puerto = new System.Windows.Forms.TextBox();
            this.txt_alias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ml_mensajes = new System.Windows.Forms.TextBox();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_conectar
            // 
            this.btn_conectar.Location = new System.Drawing.Point(192, 96);
            this.btn_conectar.Name = "btn_conectar";
            this.btn_conectar.Size = new System.Drawing.Size(75, 23);
            this.btn_conectar.TabIndex = 0;
            this.btn_conectar.Text = "conectar";
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.btn_conectar_Click);
            // 
            // btn_listener
            // 
            this.btn_listener.Location = new System.Drawing.Point(283, 96);
            this.btn_listener.Name = "btn_listener";
            this.btn_listener.Size = new System.Drawing.Size(75, 23);
            this.btn_listener.TabIndex = 1;
            this.btn_listener.Text = "listener";
            this.btn_listener.UseVisualStyleBackColor = true;
            this.btn_listener.Click += new System.EventHandler(this.btn_listener_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ip : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "puerto :";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(81, 49);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(137, 20);
            this.txt_ip.TabIndex = 4;
            // 
            // txt_puerto
            // 
            this.txt_puerto.Location = new System.Drawing.Point(283, 49);
            this.txt_puerto.Name = "txt_puerto";
            this.txt_puerto.Size = new System.Drawing.Size(75, 20);
            this.txt_puerto.TabIndex = 5;
            // 
            // txt_alias
            // 
            this.txt_alias.Location = new System.Drawing.Point(81, 98);
            this.txt_alias.Name = "txt_alias";
            this.txt_alias.Size = new System.Drawing.Size(100, 20);
            this.txt_alias.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "alias :";
            // 
            // txt_ml_mensajes
            // 
            this.txt_ml_mensajes.Location = new System.Drawing.Point(31, 157);
            this.txt_ml_mensajes.Multiline = true;
            this.txt_ml_mensajes.Name = "txt_ml_mensajes";
            this.txt_ml_mensajes.Size = new System.Drawing.Size(326, 196);
            this.txt_ml_mensajes.TabIndex = 8;
            // 
            // txt_mensaje
            // 
            this.txt_mensaje.Location = new System.Drawing.Point(31, 398);
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.Size = new System.Drawing.Size(250, 20);
            this.txt_mensaje.TabIndex = 9;
            // 
            // btn_enviar
            // 
            this.btn_enviar.Location = new System.Drawing.Point(287, 396);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(70, 23);
            this.btn_enviar.TabIndex = 10;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // c1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.txt_mensaje);
            this.Controls.Add(this.txt_ml_mensajes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_alias);
            this.Controls.Add(this.txt_puerto);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_listener);
            this.Controls.Add(this.btn_conectar);
            this.Name = "c1";
            this.Text = "c1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_conectar;
        private System.Windows.Forms.Button btn_listener;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_puerto;
        private System.Windows.Forms.TextBox txt_alias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ml_mensajes;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Button btn_enviar;
    }
}

