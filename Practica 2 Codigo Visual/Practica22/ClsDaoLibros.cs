using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Practica22
{
    public class ClsDaoLibros
    {
        public int Guardar(int isbn, string titulo, int NuEdicion, int anioPubli, string NameAut, string paisPubli, string sinopsis, string carrera, string materia)
        {
            string connectionString = "Data Source=Practica2;Initial Catalog=Libreria;User ID=Practica2ENY;Password=Root123;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Libros (ISBN, TITULO, NUMERO_DE_EDICION, ANIO_DE_PUBLICACION, NOMBRE_DE_AUTORES, PAIS_DE_PUBLICACION, SINOPSIS, CARRERA, MATERIA) " +
                                   "VALUES (@ISBN, @TITULO, @NUMERO_DE_EDICION, @ANO_DE_PUBLICACION, @NOMBRE_DE_AUTORES, @PAIS_DE_PUBLICACION, @SINOPSIS, @CARRERA, @MATERIA)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ISBN", isbn);
                    command.Parameters.AddWithValue("@TITULO", titulo);
                    command.Parameters.AddWithValue("@NUMERO_DE_EDICION", NuEdicion);
                    command.Parameters.AddWithValue("@ANO_DE_PUBLICACION", anioPubli);
                    command.Parameters.AddWithValue("@NOMBRE_DE_AUTORES", NameAut);
                    command.Parameters.AddWithValue("@PAIS_DE_PUBLICACION", paisPubli);
                    command.Parameters.AddWithValue("@SINOPSIS", sinopsis);
                    command.Parameters.AddWithValue("@CARRERA", carrera);
                    command.Parameters.AddWithValue("@MATERIA", materia);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return 1; // Insertado con éxito
                    }
                    else
                    {
                        return 0; // No se insertó ninguna fila
                    }
                }
                catch (SqlException ex)
                {
                    // Error específico de SQL Server
                    return -1;
                }
                catch (Exception ex)
                {
                    // Otro tipo de error
                    return -2;
                }
            }
        }




        public DataTable CargarDatosGridView()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Data Source=Practica2;Initial Catalog=Libreria;User ID=Practica2ENY;Password=Root123;";
            string query = "SELECT * FROM Libros";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejar el error
                    Console.WriteLine("Error al cargar datos: " + ex.Message);
                }
            }

            return dataTable;
        }

    }
}