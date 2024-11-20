namespace Ejercicio3
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
            this.textProcesses = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.killButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.startsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textProcesses
            // 
            this.textProcesses.Font = new System.Drawing.Font("Unispace", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProcesses.Location = new System.Drawing.Point(9, 10);
            this.textProcesses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textProcesses.Multiline = true;
            this.textProcesses.Name = "textProcesses";
            this.textProcesses.ReadOnly = true;
            this.textProcesses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textProcesses.Size = new System.Drawing.Size(370, 347);
            this.textProcesses.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(382, 10);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 20);
            this.textBox2.TabIndex = 1;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(495, 107);
            this.viewButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(96, 32);
            this.viewButton.TabIndex = 2;
            this.viewButton.Text = "View Processes";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(382, 32);
            this.infoButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(96, 32);
            this.infoButton.TabIndex = 3;
            this.infoButton.Text = "Process Info";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(495, 32);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(96, 32);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close Process";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(382, 70);
            this.killButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(96, 32);
            this.killButton.TabIndex = 5;
            this.killButton.Text = "Kill Process";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(495, 70);
            this.runButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(96, 32);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run App";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // startsButton
            // 
            this.startsButton.Location = new System.Drawing.Point(382, 107);
            this.startsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startsButton.Name = "startsButton";
            this.startsButton.Size = new System.Drawing.Size(96, 32);
            this.startsButton.TabIndex = 7;
            this.startsButton.Text = "Starts With...";
            this.startsButton.UseVisualStyleBackColor = true;
            this.startsButton.Click += new System.EventHandler(this.startsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.startsButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textProcesses);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textProcesses;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button startsButton;
    }
}

