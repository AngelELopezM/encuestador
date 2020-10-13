namespace Encuestador_itla
{
    partial class frm_editar_encuesta
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_preguntas = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_eliminar_pregunta = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_agregar_pregunta = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.lb_nombre_encuesta = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preguntas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_preguntas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_preguntas
            // 
            this.dgv_preguntas.AllowUserToAddRows = false;
            this.dgv_preguntas.AllowUserToDeleteRows = false;
            this.dgv_preguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_preguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_preguntas, 2);
            this.dgv_preguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_preguntas.Location = new System.Drawing.Point(3, 228);
            this.dgv_preguntas.MultiSelect = false;
            this.dgv_preguntas.Name = "dgv_preguntas";
            this.dgv_preguntas.ReadOnly = true;
            this.dgv_preguntas.RowHeadersWidth = 51;
            this.dgv_preguntas.RowTemplate.Height = 24;
            this.dgv_preguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_preguntas.Size = new System.Drawing.Size(794, 219);
            this.dgv_preguntas.TabIndex = 2;
            this.dgv_preguntas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_preguntas_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_eliminar_pregunta, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_editar, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_agregar_pregunta, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_volver, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lb_nombre_encuesta, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 219);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_eliminar_pregunta
            // 
            this.btn_eliminar_pregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_eliminar_pregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_eliminar_pregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar_pregunta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_eliminar_pregunta.Location = new System.Drawing.Point(400, 153);
            this.btn_eliminar_pregunta.Name = "btn_eliminar_pregunta";
            this.btn_eliminar_pregunta.Size = new System.Drawing.Size(391, 53);
            this.btn_eliminar_pregunta.TabIndex = 4;
            this.btn_eliminar_pregunta.Text = "Eliminar pregunta";
            this.btn_eliminar_pregunta.UseVisualStyleBackColor = false;
            this.btn_eliminar_pregunta.Click += new System.EventHandler(this.btn_eliminar_pregunta_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_editar.Location = new System.Drawing.Point(3, 153);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(391, 53);
            this.btn_editar.TabIndex = 3;
            this.btn_editar.Text = "Editar pregunta";
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_agregar_pregunta
            // 
            this.btn_agregar_pregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_agregar_pregunta.BackColor = System.Drawing.Color.Green;
            this.btn_agregar_pregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar_pregunta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_agregar_pregunta.Location = new System.Drawing.Point(400, 74);
            this.btn_agregar_pregunta.Name = "btn_agregar_pregunta";
            this.btn_agregar_pregunta.Size = new System.Drawing.Size(391, 53);
            this.btn_agregar_pregunta.TabIndex = 2;
            this.btn_agregar_pregunta.Text = "Agregar nueva pregunta";
            this.btn_agregar_pregunta.UseVisualStyleBackColor = false;
            this.btn_agregar_pregunta.Click += new System.EventHandler(this.btn_agregar_pregunta_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_volver.BackColor = System.Drawing.Color.Red;
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_volver.Location = new System.Drawing.Point(3, 74);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(391, 53);
            this.btn_volver.TabIndex = 1;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // lb_nombre_encuesta
            // 
            this.lb_nombre_encuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lb_nombre_encuesta.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lb_nombre_encuesta, 2);
            this.lb_nombre_encuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombre_encuesta.Location = new System.Drawing.Point(275, 0);
            this.lb_nombre_encuesta.Name = "lb_nombre_encuesta";
            this.lb_nombre_encuesta.Size = new System.Drawing.Size(244, 61);
            this.lb_nombre_encuesta.TabIndex = 0;
            this.lb_nombre_encuesta.Text = "Editar encuesta";
            // 
            // frm_editar_encuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_editar_encuesta";
            this.Text = "Editor de encuesta";
            this.Load += new System.EventHandler(this.frm_editar_encuesta_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preguntas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb_nombre_encuesta;
        private System.Windows.Forms.Button btn_eliminar_pregunta;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_agregar_pregunta;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.DataGridView dgv_preguntas;
    }
}