using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combinatory
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}

		private double Factorial(int n)
		{
			double sum = 1;
			for (int i = 1; i <= n; i++)
				sum *= i;
			return sum;
		}

		private double Razmeshenie(int n, int k) => Factorial(n) / Factorial(n - k);

		private double RazmesheniePovtor(int n, int k) => Math.Pow(n, k);

		private double Sochetanie(int n, int k) => Factorial(n) / Factorial(n - k) / Factorial(k);

		private double SochetaniePovtor(int n, int k) => Factorial(n + k - 1) / Factorial(n - 1) / Factorial(k);

		private double Perestanovka(int n) => Factorial(n);

		private double PerestanovkaPovtor(string str)
		{
			string[] arr = str.Split(',');
			int sum = 0;
			double result = 1;
			for (int i = 0; i < arr.Length; i++)
			{
				result *= Factorial(Convert.ToInt32(arr[i]));
				sum += Convert.ToInt32(arr[i]);
			}
			return Factorial(sum) / result;
		}

		private bool Validation(string str)
		{
			if (str != "" && Regex.IsMatch(str, "^[0-9]{1,4}$"))
				return true;
			else
				return false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(Validation(textBoxN.Text))
				textBox3.Text = Perestanovka(Convert.ToInt32(textBoxN.Text)).ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				textBox1.Text = PerestanovkaPovtor(textBox2.Text).ToString();
			}
			catch(Exception ex) { }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (Validation(textBox6.Text) && Validation(textBox7.Text))
				textBox5.Text = Razmeshenie(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text)).ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (Validation(textBox9.Text) && Validation(textBox10.Text))
				textBox8.Text = RazmesheniePovtor(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)).ToString();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (Validation(textBox12.Text) && Validation(textBox13.Text))
				textBox11.Text = Sochetanie(Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox13.Text)).ToString();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (Validation(textBox15.Text) && Validation(textBox16.Text))
				textBox14.Text = SochetaniePovtor(Convert.ToInt32(textBox15.Text), Convert.ToInt32(textBox16.Text)).ToString();
		}

	}
}
