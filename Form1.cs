using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;

        private IList<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }


        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(GetDataGridViewColumn1());
            dataGridView1.Columns.Add(GetDataGridViewColumn2());
            dataGridView1.Columns.Add(GetDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private DataGridViewColumn GetDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }

        private DataGridViewColumn GetDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }

        private DataGridViewColumn GetDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }

        private void addStudent(string name, string surname, string recordBookNumber)
        {
             
            Student s = new Student(name, surname, recordBookNumber);
            students.Add(s);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            showListInGrid();
        }

        private void showListInGrid()
        {
            try
            {


                dataGridView1.Rows.Clear();
                foreach (Student s in students)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();

                    cell1.ValueType = typeof(string);
                    cell1.Value = s.getName();
                    cell2.ValueType = typeof(string);
                    cell2.Value = s.getSurname();
                    cell3.ValueType = typeof(string);
                    cell3.Value = s.getRecordBookName();
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    dataGridView1.Rows.Add(row);

                }
            }catch (Exception ex)
            {
                MessageBox.Show("Ошибка вводимые символы введены не верно");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            bool chis1 = textBox1.Text.Any(char.IsDigit);
            bool chis2 = textBox2.Text.Any(char.IsDigit);
            bool bukv = textBox3.Text.Any(char.IsLetter);

            if (chis1 || chis2 || bukv)
            {
                MessageBox.Show("Ошибка", "В первый двух строках должны быть буквы");
            }
            else
            {
                addStudent(textBox1.Text, textBox2.Text, textBox3.Text);
                ProverkaNaPovtorenie();
                ProverkaNaZachet();
            }
        }



        private void deleteStudent(int elementIndex)
        {
            students.RemoveAt(elementIndex);
            showListInGrid();
        }

        private void ProverkaNaPovtorenie()
        {
            try
            {


                HashSet<string> nabor_imen = new HashSet<string>();
                HashSet<string> nabor_famili = new HashSet<string>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string name = row.Cells[0].Value?.ToString();
                    string surname = row.Cells[1].Value?.ToString();

                    if (name != null && surname != null && nabor_imen.Contains(name) && nabor_famili.Contains(surname))
                    {
                        MessageBox.Show($"Повторяются имя и фамилия: {name} {surname}", "Ошибка!");
                        int index = row.Index;
                        dataGridView1.Rows.RemoveAt(index);
                    }
                    nabor_imen.Add(name);
                    nabor_famili.Add(surname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }


        private void ProverkaNaZachet()
        {
            HashSet<string> nabor_zachetok = new HashSet<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string zachetka = row.Cells[2].Value?.ToString();

                if (zachetka != null && nabor_zachetok.Contains(zachetka))
                {
                    MessageBox.Show($"Повторяется зачетка: {zachetka}", "Ошибка!");
                    int index = row.Index;
                    dataGridView1.Rows.RemoveAt(index);
                }
                nabor_zachetok.Add(zachetka);
            }
        }
        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Sort(column, ListSortDirection.Ascending);

            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить студента?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteStudent(selectedRow);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
        
    