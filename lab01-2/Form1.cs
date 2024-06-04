using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01_2
{
    public partial class Form1 : Form
    {
        private double _num;
        public double Num
        {
            get { return _num; }
            set { _num = value; }
        }

        private double _result;
        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _operation;
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        private bool _resultDisplayed;
        public bool ResultDisplayed
        {
            get { return _resultDisplayed; }
            set { _resultDisplayed = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Num = 0.0;
            Result = 0.0;
            Operation = "x"; //x oznacza brak operacji
            ResultDisplayed = true; //czy obecnie jest wyswietlany wynik poprzedniej operacji
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double PerformOperation(double num1, double num2, string operation)
        {//zwraca wynik operacji, a w przypadku dzielenia przez 0 zwraca 0
            double result = 0.0;
            switch (operation) 
            {
                case "+":
                    result = num1 + num2;
                    Operation = "x";
                    break;
                case "-":
                    result = num1 - num2;
                    Operation = "x";
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                        MessageBox.Show("Błąd: dzielenie przez zero.");
                    else
                        result = num1 / num2;
                    break;
                case "x":
                    result = num2;
                    break;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {//jesli wyswietlany jest wynik poprzedniej operacji usunac go i zastapic wpisanym znakiem a w przeciwnym wypadku dopisac znak
            Button button = (Button)sender;
            if(button != null)
            {
                if (ResultDisplayed)
                {
                    ResultDisplayed = false;
                    if (button.Text == "."|| button.Text == "0")
                        this.display.Text = "0.";
                    else
                        this.display.Text = button.Text;
                }
                else if ((this.display.Text.Contains(".")  && button.Text==".")==false && this.display.Text.Length<19)
                    this.display.Text = this.display.Text + button.Text;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {//pobrac druga liczbe i wykonac dzialanie oraz wyswietlic wynik i zresetowac znak dzialania
            Num=Double.Parse(display.Text, CultureInfo.InvariantCulture);
            Result = this.PerformOperation(Result, Num, Operation);
            this.display.Text = Result.ToString(CultureInfo.InvariantCulture);
            Operation = "x";
            ResultDisplayed = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {//pobrac liczbe i ustawic znak dzialania
           Button button = (Button)sender;
            if (button != null)
            {
                Result = Double.Parse(this.display.Text, CultureInfo.InvariantCulture);
                ResultDisplayed = true;
                Operation = button.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {//wyczyscic wyswietlacz
            this.display.Text = "0";
            ResultDisplayed = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {//zamienic znak wpisywanej liczby
            ResultDisplayed = false;
            if(this.display.Text=="0")
            {
                this.display.Text = "0."; //zeby nie bylo zer obok siebie przed przecinkiem
            }
            if(this.display.Text.StartsWith("-"))
            {
                this.display.Text = this.display.Text.Substring(1);
            }
            else
            {
                this.display.Text = "-" + this.display.Text;
            }
        }
    }
}
