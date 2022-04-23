using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class MainForm : Form
    {
        double operand1 = 0, operand2 = 0, memory;
        string binaryOperator;
        bool numStore = false;
        bool op2Percent = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void NumClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool percentExist = label1.Text.Contains("%");
            if (!percentExist)
            {
                if (btn.Text != "%")
                {
                    label1.Text = label1.Text == "0" ? btn.Text : label1.Text + btn.Text;
                } else if (operand1 != 0)
                {
                    label1.Text += btn.Text;
                }
            }
        }

        private void DotClick(object sender, EventArgs e)
        {
            if (!label1.Text.Contains(".")) label1.Text += ".";
        }

        void GetOperand1()
        {
            operand1 = Convert.ToDouble(label1.Text);
        }

        void GetOperand2()
        {
            if (!label1.Text.Contains("%"))
            {
                operand2 = Convert.ToDouble(label1.Text);
            } else
            {
                op2Percent = true;
                operand2 = operand1 * Convert.ToDouble(label1.Text.Substring(0, label1.Text.Length - 1)) / 100;
            }
        }

        private void ClearClick(object sender, EventArgs e)
        {
            label1.Text = "0";
        }

        private void MSClick(object sender, EventArgs e)
        {
            if (!label1.Text.Contains("%"))
            {
                memory = Convert.ToDouble(label1.Text);
                numStore = true;
            }
        }

        private void MRClick(object sender, EventArgs e)
        {
            if (numStore == true) label1.Text = memory.ToString();
        }

        private void MCClick(object sender, EventArgs e)
        {
            if (numStore == true) 
            {
                memory = 0;
                numStore = false;
            }
        }

        private void BinOpClick(object sender, EventArgs e)
        {
            GetOperand1();
            Button btn = (Button)sender;
            binaryOperator = btn.Text;
            label1.Text = "0";
        }

        private void EvalClick(object sender, EventArgs e)
        {
            GetOperand2();
            if (binaryOperator == "+")
            {
                label1.Text = (operand1 + operand2).ToString();
            }
            else if (binaryOperator == "-")
            {
                label1.Text = (operand1 - operand2).ToString();
            }
            else if (binaryOperator == "/")
            {
                if (!op2Percent)
                {
                    label1.Text = (operand1 / operand2).ToString();
                }
                else
                {
                    label1.Text = (operand1 / (operand2 / 100)).ToString();
                }
            }
            else if (binaryOperator == "*")
            {
                if (!op2Percent)
                {
                    label1.Text = (operand1 * operand2).ToString();
                }
                else
                {
                    label1.Text = (operand1 * (operand2 / 100)).ToString();
                }
            }
            else if (binaryOperator == "x^y")
            {
                label1.Text = Math.Pow(operand1, operand2).ToString();
            }
            else if (binaryOperator == "y√x")
            {
                label1.Text = Math.Pow(operand1, (1 / operand2)).ToString();
            }
            else if (binaryOperator == "Mod")
            {
                label1.Text = (operand1 % operand2).ToString();
            }
            
            binaryOperator = null;
            operand1 = 0;
            operand2 = 0;
            op2Percent = false;
        }

        private void BackClick(object sender, EventArgs e)
        {
            int length = label1.Text.Length;
            if (length > 1)
            {
                label1.Text = label1.Text.Substring(0, length - 1);
            } else
            {
                label1.Text = "0";
            }
        }

        private void PiClick(object sender, EventArgs e)
        {
            label1.Text = "3.1415926";
        }

        private void TrigonometricClick(object sender, EventArgs e)
        {
            if (label1.Text != "0")
            {
                Button btn = (Button)sender;
                GetOperand1();
                if (radioButton1.Checked == true) operand1 = operand1 * Math.PI / 180;

                switch (btn.Text)
                {
                    case "sin":
                        label1.Text = Math.Sin(operand1).ToString();
                        break;
                    case "cos":
                        label1.Text = Math.Cos(operand1).ToString();
                        break;
                    default:  // tan
                        label1.Text = Math.Tan(operand1).ToString();
                        break;
                }

                operand1 = 0;
            }
        }

        private void HyperTrigonometricClick(object sender, EventArgs e)
        {
            if (label1.Text != "0")
            {
                Button btn = (Button)sender;
                GetOperand1();
                switch (btn.Text)
                {
                    case "sinh":
                        label1.Text = Math.Sinh(operand1).ToString();
                        break;
                    case "cosh":
                        label1.Text = Math.Cosh(operand1).ToString();
                        break;
                    default:  // tanh
                        label1.Text = Math.Tanh(operand1).ToString();
                        break;
                }

                operand1 = 0;
            }
        }

        private void OtherOpClick(object sender, EventArgs e)
        {
            if (label1.Text != "0")
            {
                Button btn = (Button)sender;
                GetOperand1();
                switch (btn.Text)
                {
                    case "x^2":
                        label1.Text = Math.Pow(operand1, 2).ToString();
                        break;
                    case "x^3":
                        label1.Text = Math.Pow(operand1, 3).ToString();
                        break;
                    case "√":
                        label1.Text = Math.Pow(operand1, 0.5).ToString();
                        break;
                    case "x-1":
                        label1.Text = Math.Pow(operand1, -1).ToString();
                        break;
                    case "n!":
                        double n = 1;
                        for (int i = 1; i <= operand1; i++)
                        {
                            n *= i;
                        }
                        label1.Text = n.ToString();
                        break;
                    case "3√x":
                        label1.Text = Math.Pow(operand1, 0.33333333333333333333333333333333333333).ToString();
                        break;
                    case "10^x":
                        label1.Text = Math.Pow(10, operand1).ToString();
                        break;
                    default:  // log
                        label1.Text = Math.Log(operand1, 10).ToString();
                        break;
                }

                operand1 = 0;
            }
        }
    }
}
