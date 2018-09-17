﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM1
{
    public partial class Form1 : Form
    {
        SimonXml XmlFile;
        Random rnd = new Random();
        private string fileName = "simon.xml";
        List<Secuencia> secuencias = new List<Secuencia>();
        Secuencia SecuenciaJuego;
        int contador = 0;
        

        public string FileName { get => fileName; set => fileName = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargo el archivo xml
            XmlFile = new SimonXml(FileName);
            XmlFile.ConvertXmlToSecuencia();
            secuencias = XmlFile.secuencias;
            DisableButtons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            int totalSecuencias = secuencias.Count;
            int randomValue = rnd.Next(1, 5);
            Secuencia sec;
            if (totalSecuencias > 0)
            {
                // obtengo el ultimo juego
                sec = secuencias.Last();
            } else
            {
                // si aun no existen jugadas se crea la primera
                sec = new Secuencia(1);
                secuencias.Add(sec);
                
            }
            sec.AddObjetoByVal(randomValue);
            SecuenciaJuego = sec;
            MostrarSecuencia(sec);
        }

        // obtengo el boton correspondiente
        public Button GetButton(int val)
        {
            switch (val)
            {
                case 1:
                    return button4;
                case 2:
                    return button1;
                case 3:
                    return button2;
                case 4:
                    return button3;
                default:
                    return new Button();
            }
        }

        // metodo que muestra la secuencia a memorizar
        private void MostrarSecuencia(Secuencia sec)
        {
            DisableButtons();
            button5.Enabled = false;
            foreach (Objeto objeto in sec.Objetos)
            {                
                Button boton = GetButton(objeto.Valor);
                boton.BackColor = objeto.GetColor(objeto.Valor);
                boton.Refresh();
                Thread.Sleep(300);
                boton.BackColor = Color.Transparent;
                boton.Refresh();
                Thread.Sleep(100);
            }
            EnableButtons();
            
        }

        // metodo que se encarga de deshabilitar los botones mientras se ejecuta la secuencia a memorizar
        private void DisableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        // metodo que habilita los botones
        private void EnableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarValor(2, contador);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ValidarValor(1, contador);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ValidarValor(4, contador);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValidarValor(3, contador);
        }

        // metodo que valida cada click dado en cada color
        private void ValidarValor(int v, int cont)
        {
            if (v != SecuenciaJuego.Objetos[cont].Valor)
            {
                MessageBox.Show("Error");
                secuencias.Add(new Secuencia(SecuenciaJuego.Juego + 1));
                XmlFile.saveToFile(FileName, secuencias);
                DisableButtons();
                button5.Enabled = true;
                
                contador = 0;
            }
            contador++;
            if (contador == SecuenciaJuego.Objetos.Count - 1)
            {
                DisableButtons();
            }
        }
    }
}
