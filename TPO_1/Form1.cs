using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPO_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void solutionInt(double a, double b)
        {
            double n = Math.Abs(a) + Math.Abs(b);
            double step = Math.Abs((Math.Abs(b) - Math.Abs(a)) / n);
            double result = 0;
            double resultDot = 0;
            for (double i = a; i < b; i += step)
            {
                if (i < 0.4 && i > -0.4)
                {
                    richTextBox1.AppendText("Число вне ОДЗ: " + i + '\n');
                }
                else
                {
                    result += function(i); // Общий результат
                    resultDot = function(i); // Результат по точкам
                    richTextBox1.AppendText(Convert.ToString(Math.Round(resultDot, 3)) + '\n'); // Ввод значений в лист
                    chart1.Series[0].Points.AddXY(Math.Round(i, 3) , Math.Round(resultDot, 3)); // Построение графика по точкам
                }
            }
            result *= step;
            label3.Visible = true;
            label3.Text = Convert.ToString(Math.Round(result, 3));
        }
        double function(double x)
        {
            if (x < 0.4 && x > -0.4)
            {
                return 0;
            }
            else
            {
                return Math.Sqrt(Math.Pow(x, 2) - 0.16) / x; // Подынтегральная функция
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox1.Text); // Нижняя граница
                double b = Convert.ToDouble(textBox2.Text); // Верхняя граница
                if(Math.Abs(a) == b)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Вы ввели парные числа");
                }
                else
                {
                    solutionInt(a, b);
                }
            }
            catch
            {
                MessageBox.Show("Введите числа (например -1, 1, 0,5)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            chart1.Series[0].Points.Clear();
            label3.Text = "";
            label3.Visible = false;
            richTextBox1.Clear();
        }
    }
}
