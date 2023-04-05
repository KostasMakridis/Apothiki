using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace project
{
    public partial class Form1 : Form
    {

        SqlConnection connection;
        SqlCommand command, command1;


        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=LAPTOP-PRIMU5UA\\KOSTASSQL;Initial Catalog=APOTHIKI_4645;Persist Security Info=True;User ID=sa;Password=45528619");
            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aPOTHIKI_4645DataSet.PARAGELIA' table. You can move, or remove it, as needed.
            this.pARAGELIATableAdapter.Fill(this.aPOTHIKI_4645DataSet.PARAGELIA);
            // TODO: This line of code loads data into the 'aPOTHIKI_4645DataSet.APOTHIKI' table. You can move, or remove it, as needed.
            this.aPOTHIKITableAdapter.Fill(this.aPOTHIKI_4645DataSet.APOTHIKI);
            // TODO: This line of code loads data into the 'aPOTHIKI_4645DataSet.PELATHS' table. You can move, or remove it, as needed.
            this.pELATHSTableAdapter.Fill(this.aPOTHIKI_4645DataSet.PELATHS);
            // TODO: This line of code loads data into the 'aPOTHIKI_4645DataSet.PROIONTA_PARAGELIAS' table. You can move, or remove it, as needed.
            this.pROIONTA_PARAGELIASTableAdapter.Fill(this.aPOTHIKI_4645DataSet.PROIONTA_PARAGELIAS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            refreshImage();
        }

        public void refreshImage()
        {
            String photoPath = textBox4.Text.Trim();
            if (photoPath != null && File.Exists(photoPath))
            {
                pictureBox1.Image = Image.FromFile(photoPath);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\makrk\OneDrive\Υπολογιστής\ΕΑΡ 2021\Ειδικά θέματα βάσεων δεδομένων - Ε\Project\images\SKLAVENITHS.png");
            }
        }

        private void bindingNavigator4_RefreshItems(object sender, EventArgs e)
        {
            refreshImage();
        }

        private void bindingNavigatorMoveNextItem3_Click(object sender, EventArgs e)
        {
            String openPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openPath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                textBox4.Text = openPath;
                pictureBox1.Image = Image.FromFile(openPath);
                command = new SqlCommand("update PELATHS set FOTO='" + openPath + "' where KOD_PELATI=" + textBox1.Text + ";", connection);
                command.ExecuteNonQuery();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm1 = new Form3();
            frm1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            refreshImage1();
        }

        public void refreshImage1()
        {
            String photoPath = textBox4.Text.Trim();
            if (photoPath != null && File.Exists(photoPath))
            {
                pictureBox1.Image = Image.FromFile(photoPath);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\makrk\OneDrive\Υπολογιστής\ΕΑΡ 2021\Ειδικά θέματα βάσεων δεδομένων - Ε\Project\images\SKLAVENITHS.png");
            }
        }

        private void bindingNavigator3_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem2_Click(object sender, EventArgs e)
        {
            String openPath;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                openPath = openFileDialog2.InitialDirectory + openFileDialog2.FileName;
                textBox4.Text = openPath;
                pictureBox2.Image = Image.FromFile(openPath);
                command1 = new SqlCommand("update APOTHIKI set FOTO='" + openPath + "' where KE=" + textBox1.Text + ";", connection);
                command1.ExecuteNonQuery();
            }
        }




    }
}