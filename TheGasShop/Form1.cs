using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TheGasShop
{
    public partial class Form1 : Form
    {

        //connection string iassigned the database file address path
        string MyConnection2 = "server=localhost;username = root ;password= ; database =thegasshop";
        public Form1()
        {
            InitializeComponent();
            cmbtype.Text = "--Select--";


    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            try { 
            string Querystock = "select sum(big),sum(medium),sum(small)  from stock;";
            MySqlConnection MyConnstock = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommandstock = new MySqlCommand(Querystock, MyConnstock);
            MyConnstock.Open();
            var dr = MyCommandstock.ExecuteReader();
            // Now check if any rows returned.
            if (dr.HasRows)
            {
                dr.Read();// Get first record.
                lblbig.Text = dr.GetString(0);
                lblmedium.Text = dr.GetString(1);
                lblsmall.Text = dr.GetString(2);

            }
            dr.Close();// Close reader.
            MyConnstock.Close();// Close connection.
            }
            catch 
            {
                
            }


            //Display query order list
            try
            {
                string Query = "select * from customer;";
                MySqlConnection MyConn1 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand1 = new MySqlCommand(Query, MyConn1);
                MyConn1.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand1;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                table.DataSource = dTable;
                MyConn1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my insert query
                string Query = "insert into customer(Name,NIC,Size,Qty) values('" + this.txtname.Text + "','" + this.txtnic.Text + "','" + this.cmbtype.Text + "','" + this.txtqty.Text + "');";
                //This is  MySqlConnection here created the object and pass connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                MessageBox.Show("Registration Complete Successfully");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Display query customer Details
            try { 
            string Query2 = "select * from customer;";

            MySqlConnection MyConn3 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand3 = new MySqlCommand(Query2, MyConn3);
            MyConn3.Open();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand3;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            table.DataSource = dTable;
            MyConn3.Close();
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            txtname.Text = "";
            txtnic.Text = "";
            txtqty.Text = "";
            cmbtype.Text = "--Select--";


        }

        public void button4_Click(object sender, EventArgs e)
        {
            try
            {

                //This is my insert query
                string Query = "insert into stock(big, medium, small) values('" +this.txtl.Text + "','" + this.txtm.Text + "','" + this.txts.Text + "');";
                //This is  MySqlConnection here created the object and pass connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                MessageBox.Show("Stock Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string Querystock = "select sum(big),sum(medium),sum(small)  from stock;";
                MySqlConnection MyConnstock = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommandstock = new MySqlCommand(Querystock, MyConnstock);
                MyConnstock.Open();
                var dr = MyCommandstock.ExecuteReader();
                // Now check if any rows returned.
                if (dr.HasRows)
                {
                    dr.Read();// Get first record.
                    lblbig.Text = dr.GetString(0);
                    lblmedium.Text = dr.GetString(1);
                    lblsmall.Text = dr.GetString(2);

                }
                dr.Close();// Close reader.
                MyConnstock.Close();// Close connection.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtl.Text = "";
            txtm.Text = "";
            txts.Text = "";
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete select datagrid row
            string del = table.CurrentRow.Cells[0].Value.ToString();
            int rowIndex = table.CurrentCell.RowIndex;
            table.Rows.RemoveAt(rowIndex);

            try
            {
                //Delete query select db row
                string Query = "delete from customer where `Order No` = " + del + ";";
                
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Order No"+del+" Deleted");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Delete select datagrid row
                txtno.Text = table.CurrentRow.Cells[0].Value.ToString();
                txtcsize.Text = table.CurrentRow.Cells[3].Value.ToString();
                txtcqty.Text = table.CurrentRow.Cells[4].Value.ToString();
                int rowIndex = table.CurrentCell.RowIndex;
                table.Rows.RemoveAt(rowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                //Delete query select db row
                string Query = "delete from customer where `Order No` = " + txtno.Text + ";";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtcsize.Text == "12.5 kg")
            {

                int a = Int32.Parse(txtcqty.Text);
                int d = 2200 * a;
                txttotal.Text = d.ToString();
                int aa = - a;
                try
                {

                    //This is sell qty insert query into stock db big field
                    string Query = "insert into stock(big, medium, small) values('" + aa + "','" + null + "','" + null + "');";
                    //This is  MySqlConnection here created the object and pass connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (txtcsize.Text == "5 kg")
            {
                int c = Int32.Parse(txtcqty.Text);
                int d = 2200 * c;
                txttotal.Text = d.ToString();
                int cc = -c;
                try
                {

                    //This is sell qty insert query into stock db medium field
                    string Query = "insert into stock(big, medium, small) values('" + null + "','" + cc + "','" + null + "');";
                    //This is  MySqlConnection here created the object and pass connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (txtcsize.Text == "2.5 kg")
            {
                int g = Int32.Parse(txtcqty.Text);
                int f = 1100 * g;
                txttotal.Text = f.ToString();
                int gg = -g;
                try
                {

                    //This is sell qty insert query into stock db big field
                    string Query = "insert into stock(big, medium, small) values('" + null + "','" + null + "','" + gg + "');";
                    //This is  MySqlConnection here created the object and pass connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            string Querystock = "select sum(big),sum(medium),sum(small)  from stock;";
            MySqlConnection MyConnstock = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommandstock = new MySqlCommand(Querystock, MyConnstock);
            MyConnstock.Open();
            var dr = MyCommandstock.ExecuteReader();
            // Now check if any rows returned.
            if (dr.HasRows)
            {
                dr.Read();// Get first record.
                lblbig.Text = dr.GetString(0);
                lblmedium.Text = dr.GetString(1);
                lblsmall.Text = dr.GetString(2);

            }
            dr.Close();// Close reader.
            MyConnstock.Close();// Close connection.

        }

        private void textBox9_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int x;
            int y;
            int z;
            try
            {
                y = Convert.ToInt16(txtcash.Text);
                x = Convert.ToInt16(txttotal.Text);
                z = y - x;
                txtbalance.Text = z.ToString();
            }
            catch
            {
                //Default Value  
                txtbalance.Text = "";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtcsize.Text == "12.5 kg")
            {
                int a = Int32.Parse(txtcqty.Text);
                int b = 5100 * a;
                txttotal.Text = b.ToString();

            }
            else if (txtcsize.Text == "5 kg")
            {
                int c = Int32.Parse(txtcqty.Text);
                int d = 2200 * c;
                txttotal.Text = d.ToString();

            }
            else if (txtcsize.Text == "2.5 kg")
            {
                int g = Int32.Parse(txtcqty.Text);
                int f = 1100 * g;
                txttotal.Text = f.ToString();

            }

            Form2 f2 = new Form2();
           
            f2.label2.Text = txtno.Text.ToString();
            f2.label4.Text = txtcsize.Text.ToString();
            f2.label6.Text = txtcqty.Text.ToString();
            f2.label8.Text = txttotal.Text.ToString();
            f2.label10.Text = txtcash.Text.ToString();
            f2.label12.Text = txtbalance.Text.ToString();
           
            f2.Show();


            txttotal.Text = "";
            txtbalance.Text = "";
            txtcash.Text = "";
            txtno.Text = "";
            txtcqty.Text = "";
            txtcsize.Text = "";



        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // delete all data(rows) in customer table in db
            try
            {
                string Queryc = "delete from customer;";
                MySqlConnection MyConnc = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommandc = new MySqlCommand(Queryc, MyConnc);
                MySqlDataReader MyReader2;
                MyConnc.Open();
                MyReader2 = MyCommandc.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyConnc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // delete all data(rows) in stock table in db
            try
            {
                string Queryc = "delete from stock;";
                MySqlConnection MyConnc = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommandc = new MySqlCommand(Queryc, MyConnc);
                MySqlDataReader MyReader2;
                MyConnc.Open();
                MyReader2 = MyCommandc.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyConnc.Close();

                int i = 0;
                //This is my insert query
                string Queryi = "insert into stock(big, medium, small) values('" + i + "','" + i + "','" + i + "');";
                //This is  MySqlConnection here created the object and pass connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Queryi, MyConn2);
                MySqlDataReader MyReader21;
                MyConn2.Open();
                MyReader21 = MyCommand2.ExecuteReader();     // query will be executed and data saved into the db.
                while (MyReader21.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Order List and Stock clear");
        }
    }
}
