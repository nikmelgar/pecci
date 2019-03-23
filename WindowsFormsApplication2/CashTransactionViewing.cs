﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class CashTransactionViewing : Form
    {
        public CashTransactionViewing()
        {
            InitializeComponent();
        }

        //Mouse Move Panel
        private bool m_firstClick = false;
        private Point m_firstClickLoc;

        Global global = new Global();
        SqlConnection con;
        
        Classes.clsCashTransactionViewing clsCashTransactionViewing = new Classes.clsCashTransactionViewing();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_firstClick == false)
                {
                    m_firstClick = true;
                    m_firstClickLoc = new Point(e.X, e.Y);
                }

                this.Location = new Point(
                    this.Location.X + e.X - m_firstClickLoc.X,
                    this.Location.Y + e.Y - m_firstClickLoc.Y
                    );
            }
            else
            {
                m_firstClick = false;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //Bring To Front (Child Form)
            //Nikko Melgar
            foreach (Form form in Application.OpenForms)
            {


                if (form.GetType() == typeof(CashTransactionViewing))
                {
                    form.Activate();
                    return;
                }
            }

            CashTransactionViewing frm = new CashTransactionViewing();
            MainForm main = new MainForm();
            frm.Show();
            frm.MdiParent = main;
        }

        private void CashTransactionViewing_Load(object sender, EventArgs e)
        {
            //Put Label on Date
            lblDateFrom.Text = dtFrom.Text;
            lblDateTo.Text = dtTo.Text;
        }

        private void radioLocTeltech_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtORNumber.Text = "";
            chckMember.Checked = false;
            chckNonMember.Checked = false;
            chckPerea.Checked = false;
            chckTeltech.Checked = false;
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsCashTransactionViewing.loadSearchCollection(dataGridView1,dataGridView3, dataGridView2, lblCountTransaction, lblTotalAmountChartAccounts, lblCountCancelledTransaction, txtORNumber, chckMember, chckNonMember, chckPerea, chckTeltech, dtFrom, dtTo);
            //Put Label on Date
            lblDateFrom.Text = dtFrom.Text;
            lblDateTo.Text = dtTo.Text;
        }

        
    }
}
