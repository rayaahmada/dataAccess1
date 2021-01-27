using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataAccess1
{
    public partial class registerProduct : Form
    {
        public registerProduct()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-CBER67G;" +
                "Initial Catalog=CDemo;Integrated Security=True");
        private void lblProductID_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand command = new SqlCommand("insert into tbl_Product" +
                "(ProductID,ItemName,Design,Color,InsertDate) values('" + int.Parse(txtProductID.Text) + "'," +
                "'" + txtItemName.Text+ "','"+txtDesign.Text+"','"+cmbColor.Text+"',getdate())",conn);
            command.ExecuteNonQuery();
           // MessageBox.Show("Successfully Inserted");
            conn.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from tbl_product", conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("update tbl_Product " +
                "set ItemName='" + txtItemName.Text + "',Design='" + txtDesign.Text + "'" +
                ",Color='" + cmbColor.Text + "',UpdateDate = '"+DateTime.Parse(dtpUpdateDate.Text)+"' where productID='" + int.Parse(txtProductID.Text) + "'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successsfully Updated");
            BindData();


        }

        private void registerProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("delete from tbl_Product where " +
                "ProductID = '"+int.Parse(txtProductID.Text)+"'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Deleted!");
            BindData();
        }
    }
}
