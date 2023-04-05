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
    public partial class Form2 : Form
    {

        SqlConnection connection;
        SqlDataAdapter DataAdapter1, DataAdapter2;
        DataSet DataSet2;
        BindingSource BindingSource2;

        public Form2()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=LAPTOP-PRIMU5UA\\KOSTASSQL;Initial Catalog=APOTHIKI_4645;Persist Security Info=True;User ID=sa;Password=45528619");
            connection.Open();

            DataAdapter1 = new SqlDataAdapter("Select * from PELATHS", connection);
            DataTable dt1 = new DataTable();
            DataAdapter1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EPITHETO";

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
        }

        public void fillDataSet()
        {
            DataAdapter2 = new SqlDataAdapter("SELECT EPONYMIA, AFM, EIDOS, KATHGORIA, TIMH_POLHSHS, FPA, POSOTTHTA FROM PELATHS INNER JOIN(PARAGELIA INNER JOIN(PROIONTA_PARAGELIAS INNER JOIN APOTHIKI ON APOTHIKI.KE=PROIONTA_PARAGELIAS.K_E) ON PARAGELIA.KOD_PAR=PROIONTA_PARAGELIAS.K_PAR) ON PELATHS.KOD_PELATI=PARAGELIA.K_PEL WHERE PELATHS.EPITHETO='" + comboBox1.Text.ToString() + "'", connection);
            DataSet2 = new DataSet();
            DataAdapter2.Fill(DataSet2);
            BindingSource2 = new BindingSource();
            DataTable dt = new DataTable();
            BindingSource2.DataSource = DataSet2.Tables[0].DefaultView;
            dataGridView1.DataSource = BindingSource2;
            float timi = 0, sum = 0, fpa = 0, timip = 0, posotita = 0, tel_timi;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                timi = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                posotita = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                fpa = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                timip = (timi * posotita);
                tel_timi = (float)((timip * (fpa/100)) + timip);
                sum += tel_timi;
            }
            label4.Text = sum.ToString();
        }

    }
}
