namespace proyecto_parcial
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            TextBoxNombre = new TextBox();
            label2 = new Label();
            TextBoxNivel = new TextBox();
            comboBoxBloques = new ComboBox();
            listBoxBloques = new ListBox();
            button2 = new Button();
            button3 = new Button();
            textBoxId = new TextBox();
            label3 = new Label();
            comboBox2 = new ComboBox();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            MINECRAFT = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 239);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "NOMBRE:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Location = new Point(59, 188);
            button1.Name = "button1";
            button1.Size = new Size(216, 29);
            button1.TabIndex = 1;
            button1.Text = "AGREGAR JUGADOR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TextBoxNombre
            // 
            TextBoxNombre.Location = new Point(486, 232);
            TextBoxNombre.Name = "TextBoxNombre";
            TextBoxNombre.Size = new Size(125, 27);
            TextBoxNombre.TabIndex = 2;
            TextBoxNombre.TextChanged += TextBoxNombre_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(336, 292);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 3;
            label2.Text = "NIVEL:";
            // 
            // TextBoxNivel
            // 
            TextBoxNivel.Location = new Point(486, 292);
            TextBoxNivel.Name = "TextBoxNivel";
            TextBoxNivel.Size = new Size(125, 27);
            TextBoxNivel.TabIndex = 4;
            // 
            // comboBoxBloques
            // 
            comboBoxBloques.BackColor = Color.FromArgb(255, 192, 192);
            comboBoxBloques.FormattingEnabled = true;
            comboBoxBloques.Location = new Point(807, 188);
            comboBoxBloques.Name = "comboBoxBloques";
            comboBoxBloques.Size = new Size(264, 28);
            comboBoxBloques.TabIndex = 5;
            comboBoxBloques.Text = "Bloques por tipo de Rareza:";
            comboBoxBloques.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBoxBloques
            // 
            listBoxBloques.FormattingEnabled = true;
            listBoxBloques.Location = new Point(807, 292);
            listBoxBloques.Name = "listBoxBloques";
            listBoxBloques.Size = new Size(277, 124);
            listBoxBloques.TabIndex = 6;
            listBoxBloques.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Location = new Point(293, 188);
            button2.Name = "button2";
            button2.Size = new Size(216, 29);
            button2.TabIndex = 7;
            button2.Text = "ELIMINAR JUGADOR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 192);
            button3.Location = new Point(547, 188);
            button3.Name = "button3";
            button3.Size = new Size(216, 29);
            button3.TabIndex = 8;
            button3.Text = "ACTUALIZAR JUGADOR";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(486, 376);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(125, 27);
            textBoxId.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 376);
            label3.Name = "label3";
            label3.Size = new Size(384, 20);
            label3.TabIndex = 10;
            label3.Text = "ID (SOLO PARA ACTUALIZAR O ELIMINAR UN JUGADOR)";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.FromArgb(255, 192, 192);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1126, 182);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(264, 28);
            comboBox2.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1106, 251);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(431, 186);
            dataGridView1.TabIndex = 13;
            // 
            // button4
            // 
            button4.Location = new Point(1155, 216);
            button4.Name = "button4";
            button4.Size = new Size(216, 29);
            button4.TabIndex = 14;
            button4.Text = "MOSTRAR INVENTARIO";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1277, 443);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 15;
            button5.Text = "IMPORTAR";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // MINECRAFT
            // 
            MINECRAFT.AutoSize = true;
            MINECRAFT.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MINECRAFT.Location = new Point(588, 103);
            MINECRAFT.Name = "MINECRAFT";
            MINECRAFT.Size = new Size(232, 50);
            MINECRAFT.TabIndex = 16;
            MINECRAFT.Text = "MINECRAFT";
            MINECRAFT.Click += MINECRAFT_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(17, 26);
            label4.Name = "label4";
            label4.Size = new Size(370, 50);
            label4.TabIndex = 17;
            label4.Text = "CRISTIAN CASTILLO";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1618, 600);
            Controls.Add(label4);
            Controls.Add(MINECRAFT);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(textBoxId);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBoxBloques);
            Controls.Add(comboBoxBloques);
            Controls.Add(TextBoxNivel);
            Controls.Add(label2);
            Controls.Add(TextBoxNombre);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox TextBoxNombre;
        private Label label2;
        private TextBox TextBoxNivel;
        private ComboBox comboBoxBloques;
        private ListBox listBoxBloques;
        private Button button2;
        private Button button3;
        private TextBox textBoxId;
        private Label label3;
        private ComboBox comboBox2;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button5;
        private Label MINECRAFT;
        private Label label4;
    }
}
