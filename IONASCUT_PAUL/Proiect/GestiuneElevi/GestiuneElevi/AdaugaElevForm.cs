﻿using GestiuneElevi.Entities;
using GestiuneElevi.Reositories;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneElevi
{
    public partial class AdaugaElevForm : Form
    {
        public AdaugaElevForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string cnp = textBox3.Text;
            int varsta, clasa;
            try { varsta = int.Parse(textBox4.Text); } catch(Exception) { varsta = -1; }
            try { clasa = int.Parse(textBox5.Text); } catch(Exception) { clasa = -1; }

            if(!string.IsNullOrWhiteSpace(nume) && !string.IsNullOrWhiteSpace(prenume) && !string.IsNullOrWhiteSpace(cnp) && varsta != -1 && clasa != -1)
            {
                ElevEntity elevEntity = new ElevEntity(Guid.NewGuid().ToString(), cnp);
                elevEntity.Nume = nume;
                elevEntity.Prenume = prenume;
                elevEntity.Varsta = varsta;
                elevEntity.Clasa = clasa;

                Task.Run(() => { MasterRepository.EleviRepository.AdaugaElevAsyncTask(elevEntity); });

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Completati toate datele!");
            }
        }
    }
}
