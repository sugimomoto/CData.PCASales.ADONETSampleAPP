using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.CData.PCASales;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        // 得意先マスタ（MasterTMS）
        private void button1_Click(object sender, EventArgs e)
        {
            var sql = "SELECT TokuisakiCode, TokuisakiMei1,YubinBango,Jyusyo1,AitesakiTelNo FROM MasterTMS limit 15";
            textBox1.Text = sql;
        }

        // 商品マスタ（MasterSMS）
        private void button2_Click(object sender, EventArgs e)
        {
            var sql = "SELECT * FROM MasterSMS limit 15";
            textBox1.Text = sql;
        }

        // 見積伝票（InputMIT）
        private void button3_Click(object sender, EventArgs e)
        {
            var sql = "SELECT * FROM InputMIT limit 15";
            textBox1.Text = sql;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sql = textBox1.Text;

            string connectionString = "CallbackURL=XXXXXX;DefaultDataArea=XXXXXXX;InitiateOAuth=GETANDREFRESH;OAuth Client Id=XXXXXXXOAuth Client Secret=XXXXXXX;DataCenter=east02;ProductCode=Kon20;";
            
            using (var connection = new PCASalesConnection(connectionString))
            {
                var dataAdapter = new PCASalesDataAdapter(
                sql, connection);

                var table = new DataTable();
                dataAdapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }
    }
}
