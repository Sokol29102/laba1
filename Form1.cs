using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab1
{
	public partial class Form1 : Form
	{
		Data data;
		string OldTextBoxExpression = String.Empty;
		string currentFileName;
		public Form1()
		{
			InitializeComponent();
			data = new Data(dataGridView1);
			this.Text = "MyExcel";
		}
		internal Data Data
		{
			get => default(Data);
			set { }
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			data.FillData(Mode.Value);
		}
		private void dataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.Value.ToString()))
			{
				data.ChangeData(e.Value.ToString(), e.RowIndex, e.ColumnIndex);
			}
		}
		private void dataGridView_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedCells.Count == 1)
			{
				var selectedcell = dataGridView1.SelectedCells[0];
				textBox1.Text = Data.cells[selectedcell.RowIndex][selectedcell.ColumnIndex].Expression;
				OldTextBoxExpression = textBox1.Text;
			}
		}
		private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (Data.cells[e.RowIndex][e.ColumnIndex].Expression != null)
			{
				if (!String.IsNullOrEmpty(Data.cells[e.RowIndex][e.ColumnIndex].Error))
				{
					dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Error;
				}
				else
				{
					dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Value.ToString();
				}
			}
		}
		private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Expression;
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox1.Text = ((TextBox)sender).Text;
			OldTextBoxExpression = textBox1.Text;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			data.RemoveColumn();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			data.AddRow();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			data.RemoveRow();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentCell != null)
			{

				string text = textBox1.Text;


				dataGridView1.CurrentCell.Value = text;
			}
		}


		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				data = new Data(dataGridView1);
				data.OpenFile(openFileDialog.FileName);
				data.FillData(Mode.Value);
				currentFileName = openFileDialog.FileName;
				this.Text = currentFileName + "Excelus";
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				data.SaveToFile(saveFileDialog.FileName);
				currentFileName = saveFileDialog.FileName;
				this.Text = currentFileName + "Excelus";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			data.AddColumn();
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}
	}
}
