using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleExamples.Classes;
using SimpleExamples.Extensions;

namespace SimpleExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Shown += OnShown;

            DataOperations.GetCommandText += ReceiveQuery;
        }

        /// <summary>
        /// Show decoded SQL SELECT
        /// </summary>
        /// <param name="sender"></param>
        private void ReceiveQuery(string sender)
        {
            label1.Text = sender;
        }

        private void OnShown(object sender, EventArgs e)
        {
            CompanyCheckedListBox.DataSource = DataOperations.GetCompanies();
        }

        private void GetSelectedButton_Click(object sender, EventArgs e)
        {
            CompanyListBox.DataSource = null;

            var list = CompanyCheckedListBox.CheckedList();

            if (list.Count <= 0) return;
            var indices = list.Select(company => company.Id).ToList();

            var (companies, exception) = DataOperations.GetByPrimaryKeys(indices);
            if (exception is null)
            {
                CompanyListBox.DataSource = companies;
            }
            else
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
