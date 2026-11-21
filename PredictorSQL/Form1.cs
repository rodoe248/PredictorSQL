using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PredictorSQL
{
    public partial class Form1 : Form
    {
        private List<string> sentenciasSql;
        private string palabraSugerida = "";

        public Form1()
        {
            InitializeComponent();
            CargarArchivoPredicciones();

        
            labelsug.Text = "";
        }

        private void CargarArchivoPredicciones()
        {
            sentenciasSql = new List<string>();
            string rutaArchivo = "LLMFINETUNNING.txt"; 

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string lineaLimpia = linea.Trim();

                    // Ignorar líneas vacías y comentarios de SQL
                    if (!string.IsNullOrWhiteSpace(lineaLimpia) && !lineaLimpia.StartsWith("--"))
                    {
                        sentenciasSql.Add(lineaLimpia);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo LLMFINETUNNING.txt en la carpeta del ejecutable.", "Error"); //[cite: 1]
            }
        }


        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//tecla tab
        {
            if (keyData == Keys.Tab && txtEntrada.Focused && !string.IsNullOrEmpty(palabraSugerida)) 
            {
                // Inyectar solo la siguiente palabra detectada
                txtEntrada.Text += palabraSugerida;

                // Mover el cursor al final
                txtEntrada.SelectionStart = txtEntrada.Text.Length;

                return true; // Cancelar el comportamiento normal de la tecla TAB (cambiar el foco)
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtEntrada_TextChanged_1(object sender, EventArgs e)
        {
            string textoActual = txtEntrada.Text; 
            palabraSugerida = "";
            labelsug.Text = ""; 

            if (string.IsNullOrWhiteSpace(textoActual)) return;

            foreach (string sentencia in sentenciasSql)
            {
                if (sentencia.StartsWith(textoActual, StringComparison.OrdinalIgnoreCase))
                {
                    // Extraer lo que falta escribir de la sentencia completa
                    string restante = sentencia.Substring(textoActual.Length);

                    if (string.IsNullOrEmpty(restante)) continue;

                    // Calcular dónde termina la siguiente "palabra"
                    int espaciosIniciales = restante.Length - restante.TrimStart().Length;
                    int indiceSiguienteEspacio = restante.TrimStart().IndexOf(' ');

                    if (indiceSiguienteEspacio == -1)
                    {
                        // Si ya no hay más espacios, sugerimos el final de la cadena
                        palabraSugerida = restante;
                    }
                    else
                    {
                        // Sugerir hasta el próximo espacio (incluyendo los espacios iniciales si los hay)
                        palabraSugerida = restante.Substring(0, espaciosIniciales + indiceSiguienteEspacio);
                    }

                    // Muestra la sentencia completa de fondo para dar contexto
                    labelsug.Text = "Autocompletar: " + palabraSugerida + " | De: " + sentencia;
                    return;
                }
            }
        }
    }
}