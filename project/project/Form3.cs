using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Form3 : Form
    {

        SqlConnection connection;
        SqlDataAdapter DataAdapter1, DataAdapter2;
        DataSet DataSet2;
        BindingSource BindingSource2;

        public Form3()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=LAPTOP-PRIMU5UA\\KOSTASSQL;Initial Catalog=APOTHIKI_4645;Persist Security Info=True;User ID=sa;Password=45528619");
            connection.Open();

            DataAdapter1 = new SqlDataAdapter("Select * from APOTHIKI", connection);
            DataTable dt1 = new DataTable();
            DataAdapter1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EIDOS";
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
        }

        public void fillDataSet()
        {
            DataAdapter2 = new SqlDataAdapter("Select KE,K_PAR,EIDOS,KATHGORIA,APOTHEMA,TIMH_POLHSHS,POSOTTHTA,FPA from APOTHIKI INNER JOIN (PROIONTA_PARAGELIAS  INNER JOIN (PELATHS INNER JOIN PARAGELIA ON PELATHS.KOD_PELATI= PARAGELIA.K_PEL) ON PARAGELIA.KOD_PAR = PROIONTA_PARAGELIAS.K_PAR) ON APOTHIKI.KE= PROIONTA_PARAGELIAS.K_E WHERE APOTHIKI.EIDOS='" + comboBox1.Text.ToString() + "'", connection);
            DataSet2 = new DataSet();
            DataAdapter2.Fill(DataSet2);
            BindingSource2 = new BindingSource();
            DataTable dt = new DataTable();
            BindingSource2.DataSource = DataSet2.Tables[0].DefaultView;
            dataGridView1.DataSource = BindingSource2;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            label4.Text = sum.ToString();
        }

    }
}
