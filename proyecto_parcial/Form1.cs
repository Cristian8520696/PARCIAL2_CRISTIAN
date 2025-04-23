using Microsoft.Data.SqlClient;
using MinecraftManager.Services;
using MinecraftManager.Utils;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_parcial
{
    public partial class Form1 : Form
    {
        DatabaseManager Jugadores;
        string? bloquesRareza;
        JugadorService serviciosJugador;
        string? nombreJugador;
        string? nivelJugador;
        string? IdJugador;
        public Form1()
        {
            InitializeComponent();
            Jugadores = new DatabaseManager();
            serviciosJugador = new JugadorService(Jugadores);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarJugadores();
            comboBoxBloques.Items.AddRange(new string[] { "Común", "Raro", "Épico" });
        }


        //AGG JUGADORES
        private void button1_Click(object sender, EventArgs e)
        {

            nombreJugador = TextBoxNombre.Text;
            nivelJugador = TextBoxNivel.Text;
            // Verificar si ambos campos están llenos
            if (string.IsNullOrWhiteSpace(nombreJugador) || string.IsNullOrWhiteSpace(nivelJugador))
            {
                MessageBox.Show("Todos los campos para agregar un jugador deben ser llenados.");
                return; // Sale del método si falta algún campo
            }

            try
            {
                Jugadores.AggJugadores(nombreJugador, nivelJugador);
                MessageBox.Show("Jugador agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

            TextBoxNombre.Text = "";
            TextBoxNivel.Text = "";

        }
        //ELIMINAR JUGADOR
        private void button2_Click(object sender, EventArgs e)
        {
            IdJugador = textBoxId.Text;
            // Verificar si el campo ID está lleno
            if (string.IsNullOrWhiteSpace(IdJugador))
            {
                MessageBox.Show("Debes ingresar el ID del jugador que deseas eliminar.");
                return; // Sale del método si no se ingresó el ID
            }

            Jugadores.EliminarJugadores(IdJugador);
            MessageBox.Show("Jugador eliminado correctamente.");
            TextBoxNombre.Text = "";
            TextBoxNivel.Text = "";
            textBoxId.Text = "";
          
        }
        //ACTUALIZAR JUGADOR
        private void button3_Click(object sender, EventArgs e)
        {
            nombreJugador = TextBoxNombre.Text;
            nivelJugador = TextBoxNivel.Text;
            IdJugador = textBoxId.Text;
            // Verificar si alguno de los campos está vacío
            if (string.IsNullOrWhiteSpace(IdJugador) || string.IsNullOrWhiteSpace(nombreJugador) || string.IsNullOrWhiteSpace(nivelJugador))
            {
                MessageBox.Show("Todos los campos (ID, Nombre y Nivel) deben ser llenados para actualizar un jugador.");
                return; // Sale del método si falta algún campo
            }

            Jugadores.ActualizarJugador(IdJugador, nombreJugador, nivelJugador);
            MessageBox.Show("Jugador actualizado correctamente.");

            TextBoxNombre.Text = "";
            TextBoxNivel.Text = "";
            textBoxId.Text = "";

        }

        //DATAGRIDVIEW PARA MOSTRAR INVENTARIO

        private void CargarJugadores()
        {
            using (SqlConnection conn = Jugadores.GetConnection())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT Id, Nombre FROM Jugadores ORDER BY Nombre;";
                    SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Nombre";
                    comboBox2.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar jugadores: " + ex.Message);
                }
            }
        }


        private void FiltrarPorJugador(int jugadorId)
        {
            string consulta = @"
        SELECT 
            Jugadores.Nombre AS Jugador,
            Jugadores.Nivel,
            Bloques.Nombre AS Bloque,
            Inventario.Cantidad
        FROM 
            Inventario
        INNER JOIN 
            Jugadores ON Inventario.JugadorId = Jugadores.Id
        INNER JOIN 
            Bloques ON Inventario.BloqueId = Bloques.Id
        WHERE 
            Inventario.JugadorId = @JugadorId
        ORDER BY 
            Bloques.Nombre;";

            using (SqlConnection conn = Jugadores.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@JugadorId", jugadorId);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar inventario: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedValue != null)
            {
                int jugadorId = Convert.ToInt32(comboBox2.SelectedValue);
                FiltrarPorJugador(jugadorId);
            }
        }
        //COMBOBOX PARA FILTRAR BLOQUES POR RAREZA
        private void CargarBloquesPorRareza(string rareza)
        {
            using (SqlConnection conn = Jugadores.GetConnection())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT Nombre FROM Bloques WHERE Rareza = @Rareza ORDER BY Nombre;";
                    SqlCommand cmd = new SqlCommand(consulta, conn);
                    cmd.Parameters.AddWithValue("@Rareza", rareza);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Limpiar el ListBox antes de agregar los nuevos bloques
                    listBoxBloques.Items.Clear();

                    // Verifica si hay bloques y los agrega al ListBox
                    while (reader.Read())
                    {
                        listBoxBloques.Items.Add(reader["Nombre"].ToString());
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar bloques: " + ex.Message);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBloques.SelectedItem != null)
            {
                string rarezaSeleccionada = comboBoxBloques.SelectedItem.ToString(); // Obtener la rareza seleccionada
                CargarBloquesPorRareza(rarezaSeleccionada); // Llamar al método para cargar los bloques correspondientes
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.Filter = "Archivo CSV (*.csv)|*.csv";
            guardarArchivo.Title = "Guardar archivo CSV";
            guardarArchivo.FileName = "InventarioJugador.csv";

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(guardarArchivo.FileName, false, Encoding.UTF8))
                    {
                        // Escribir encabezados
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            sw.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();

                        // Escribir filas
                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (!fila.IsNewRow)
                            {
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    sw.Write(fila.Cells[i].Value?.ToString());
                                    if (i < dataGridView1.Columns.Count - 1)
                                        sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Archivo CSV exportado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void MINECRAFT_Click(object sender, EventArgs e)
        {

        }
    }

}
        

    



    









