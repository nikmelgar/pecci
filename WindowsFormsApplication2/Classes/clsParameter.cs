﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication2.Classes
{
    class clsParameter
    {
        Global global = new Global();

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public void displayParameter(DataGridView dgv)
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT * FROM Parameter", con);
                dt = new DataTable();
                adapter.Fill(dt);

                dgv.DataSource = dt;

                dgv.Columns["frm"].HeaderText = "Form";
                dgv.Columns["val"].HeaderText = "Values";
                dgv.Columns["inserted_by"].Visible = false;
                dgv.Columns["dateInserted"].Visible = false;
                dgv.Columns["lastmodified"].Visible = false;
                dgv.Columns["lastvaluebeforemodified"].Visible = false;
                dgv.Columns["usermodified"].Visible = false;
            }  
        }

        public void loadComboBox(ComboBox cmb)
        {
            cmb.DataSource = null;

            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("select * from frms", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmb.DisplayMember = dt.Columns[0].ToString();
                cmb.ValueMember = dt.Columns[0].ToString();
                cmb.DataSource = dt;
            }
        }

        public Decimal cashLimit()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Cash Limit' and frm = 'Savings'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            }
        }

        public Decimal DeferredAmount()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();
                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Deferred Amount' and frm = 'Billing'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            }
               
        }

        public Decimal MembershipFee()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();


                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Membership Fee' and frm = 'Billing'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            }

        }

        public Decimal remainingBalance() //100php as of 10/29/2018
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Remaining Balance' and frm = 'Savings'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            }

               
        }

        public int withdrawalPerDay()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Withdrawal A day' and frm = 'Savings'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            }
        }

        public int MembershipFeePriority()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Membership Fee Priority' and frm = 'Billing'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            }

            
        }

        public int ShareCapitalPriority()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Share Capital Priority' and frm = 'Billing'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            }

               
        }

        public Decimal serviceFee()
        {
            using (SqlConnection con = new SqlConnection(global.connectString()))
            {
                con.Open();

                adapter = new SqlDataAdapter("SELECT val FROM Parameter WHERE Description = 'Service Fee' and frm = 'Loan'", con);
                dt = new DataTable();
                adapter.Fill(dt);

                return Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            }

              
        }

    }
}
