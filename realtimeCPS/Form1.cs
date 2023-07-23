using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace realtimeCPS
{
    public partial class Form1 : Form
    {
        private long cps = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssff"));
        private int total = 0;
        private int max = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            timer1.Interval = 10; 
            timer1.Start();
            listBox1.Enabled = false;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            total++;
            label4.Text = total.ToString();
            label1.Text = listBox1.Items.Count.ToString();
            listBox1.Items.Add(cps + 100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cps = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssff"));
            if (listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;

                if (cps >= long.Parse(listBox1.SelectedItem.ToString()))
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            if (listBox1.Items.Count > max)
            {
                max = listBox1.Items.Count;
                label7.Text = max.ToString();
            }
            
            label1.Text = listBox1.Items.Count.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
        "カウントをリセットしますか？",
        "Realtime CPS",
        MessageBoxButtons.YesNo,  // ボタンの一覧は MessageBoxButtons 参照
        MessageBoxIcon.Question   // アイコンの一覧は  MessageBoxIcon 参照
    )
    == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                total = 0;
                max = 0;
                label7.Text = max.ToString();
                label4.Text = total.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}