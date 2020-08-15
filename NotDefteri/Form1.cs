using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        byte x = 0,y=0;
        void kaydet()
        {

            DialogResult soru = MessageBox.Show("Kaydetmek istiyor musunuz?", "Kaydet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                StreamWriter Kayit = new StreamWriter(ofd.FileName);
                Kayit.WriteLine(richTextBox1.Text);
                Kayit.Close();
                richTextBox1.Clear();
                x = 0;
                y = 0;
                MessageBox.Show("Dosya Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        void fkayit()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Desktop\";
            sfd.Title = "Metin Dosyaları";
            sfd.Filter ="Metin Dosyası (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(sfd.FileName);
                Kayit.WriteLine(richTextBox1.Text);
                Kayit.Close();
                richTextBox1.Clear();
                x = 0;
                y = 0;
            }
        }
        
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ofd.Filter = "Metin Dosyası (*.txt)|*.txt";
            ofd.Title = "Metin Dosyası Aç";
           DialogResult ac= ofd.ShowDialog();
            if (ac==DialogResult.OK)
            {
                StreamReader oku = new StreamReader(ofd.FileName);
                FontDialog f = new FontDialog();
                richTextBox1.Text = oku.ReadToEnd();
                oku.Close();
                y = 1;
            }
            

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(y==0)
            {
                fkayit();
            }
            else
            {
                kaydet();
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fkayit();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(x==1)
            {
                kaydet();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length != 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText.Length!=0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Clipboard.GetText();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            x = 1;
        }

        private void notDefteriHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu editör *.txt türünde dosyalar oluşturabilme ve bu türde ki dosyalar üzerinde değişiklik yapabilmeniz için geliştirildi.","Hakkında",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (x == 1)
            {
                kaydet();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText!="")
            {
                kesToolStripMenuItem.Enabled = true;
                kopyalaToolStripMenuItem.Enabled = true;
            }
            else
            {
                kesToolStripMenuItem.Enabled = false;
                kopyalaToolStripMenuItem.Enabled = false;
            }
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.Font = fd.Font;
        }
    }
}
