using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MinecraftManager.Utils
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            _connectionString = "Server=CRISTIAN\\SQLEXPRESS01;Database=PARCIAL2_CRISTIAN;Integrated Security=True; TrustServerCertificate=True;";
        }

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }

        public bool TestConnection()
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }

        public string? ObtenerBloquesPorRareza(string rareza)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Nombre FROM Bloques WHERE Rareza = @Rareza";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Rareza", rareza);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return reader["Nombre"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return null;
        }
        public string? AggJugadores(string nombre, string nivel)
        {
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "Insert into Jugadores (Nombre, Nivel) values (@Nombre, @Nivel)";
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Nivel", nivel);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Jugador agregado correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Revisa y averigua el error, Error al conectar a la base de datos: " + ex.Message);
                    }
                }
                return null;
            }
        }
        public string? EliminarJugadores(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Jugadores WHERE ID = @ID";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Jugador eliminado correctamente del sistema de Minecraft");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return null;
        }
    
    public string? ActualizarJugador(string id, string nombre, string nivel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Jugadores SET Nombre = @Nombre, Nivel = @Nivel WHERE ID = @ID";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Nivel", nivel);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Jugador actualizado correctamente en el sistema de Minecraft");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return null;
        }
       
    }
}