using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica22
{
    public partial class frmAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposValidos())
            {
                try
                {
                    int ISBN = int.Parse(txtIsbn.Text);
                    string Titulo = txtTitle.Text;
                    int NoEdicion = int.Parse(txtNEd.Text);
                    int AnioPu = int.Parse(txtADP.Text);
                    string NameAut = txtNameA.Text;
                    string PaisPub = txtPaisP.Text;
                    string sinopsis = txtSinopsis.Text;
                    string carrera = txtCarrera.Text;
                    string materia = txtMateria.Text;

                    ClsDaoLibros ObjLibros = new ClsDaoLibros();

                    int resultado = ObjLibros.Guardar(ISBN, Titulo, NoEdicion, AnioPu, NameAut, PaisPub, sinopsis, carrera, materia);

                    switch (resultado)
                    {
                        case 1:
                            LimpiarCampos();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro insertado correctamente')", true);
                            break;
                        case 0:
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se insertó ningún registro')", false);
                            break;
                        case -1:
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al insertar en la base de datos: Problema de SQL Server')", false);
                            break;
                        case -2:
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error desconocido')", false);
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    string errorMessage = "Error al insertar en la base de datos: Problema de SQL Server";
                    errorMessage += "\nNúmero de error: " + ex.Number;
                    errorMessage += "\nMensaje: " + ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + errorMessage + "')", false);
                }

                catch (FormatException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Uno o más campos tienen un formato incorrecto')", false);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error desconocido: " + ex.Message + "')", false);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Por favor, complete todos los campos')", false);
            }
        }

        // Método para verificar que los campos no estén vacíos
        private bool CamposValidos()
        {
            return!string.IsNullOrEmpty(txtIsbn.Text) &&
                   !string.IsNullOrEmpty(txtTitle.Text) &&
                   !string.IsNullOrEmpty(txtNEd.Text) &&
                   !string.IsNullOrEmpty(txtADP.Text) &&
                   !string.IsNullOrEmpty(txtNameA.Text) &&
                   !string.IsNullOrEmpty(txtPaisP.Text) &&
                   !string.IsNullOrEmpty(txtSinopsis.Text) &&
                   !string.IsNullOrEmpty(txtCarrera.Text) &&
                   !string.IsNullOrEmpty(txtMateria.Text);
        }

        // Método para limpiar los campos
        private void LimpiarCampos()
        {
            txtIsbn.Text = "";
            txtTitle.Text = "";
            txtNEd.Text = "";
            txtADP.Text = "";
            txtNameA.Text = "";
            txtPaisP.Text = "";
            txtSinopsis.Text = "";
            txtCarrera.Text = "";
            txtMateria.Text = "";
        }


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}

