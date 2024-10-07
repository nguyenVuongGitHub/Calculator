using Microsoft.VisualBasic.Devices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private double finalResult;
        private string formular = "";
        private string firstTemp = "";
        private string secondTemp = "";
        private string math = "";
        private bool isPressMath = false;
        private bool newCalculate = true;
        private bool isPressEqual = false;
        public Form1()
        {
            InitializeComponent();
            Init();
            UpdateLable();
        }
        private void Init()
        {
            finalResult = 0;

        }
        private void ResetValues()
        {
            finalResult = 0;
            formular = "";
            firstTemp = "";
            secondTemp = "";
            formular = "";
            this.math = "";
            isPressMath = false;
            isPressEqual = false;
            newCalculate = true;
        }
        private void Calculate(string math)
        {
            if (double.TryParse(firstTemp, out finalResult) && double.TryParse(secondTemp, out finalResult))
            {
                switch (math)
                {
                    case "+":
                        {
                            finalResult = double.Parse(firstTemp) + double.Parse(secondTemp);
                            break;
                        }
                    case "-":
                        {
                            finalResult = double.Parse(firstTemp) - double.Parse(secondTemp);
                            break;
                        }
                    case "*":
                        {
                            finalResult = double.Parse(firstTemp) * double.Parse(secondTemp);
                            break;
                        }
                    case "/":
                        {
                            try
                            {
                                finalResult = double.Parse(firstTemp) / double.Parse(secondTemp);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Cannot divice for 0!");

                            }
                            break;

                        }

                }
            }


            if (math == "")
            {
                if (double.TryParse(firstTemp, out finalResult))
                {
                    finalResult = double.Parse(firstTemp);

                }
            }



            //firstTemp = finalResult.ToString();
            firstTemp = "";
            secondTemp = "";
            formular = "";
            this.math = "";
            isPressMath = false;
            isPressEqual = true;
            newCalculate = false;
        }
        private void UpdateLable()
        {
            formular = firstTemp + math + secondTemp;
            lblTemp.Text = formular;
            lblResult.Text = finalResult.ToString();
        }
        private void UpdateTemp(string value)
        {
            if (isPressEqual)
            {
                newCalculate = true;
                isPressEqual = false;
            }
            if (newCalculate)
            {
                if (!isPressMath)
                {
                    firstTemp += value;
                }
                else
                {
                    secondTemp += value;
                }
            }
            else
            {
                secondTemp += value;
            }
        }
        private void UpdateMath(string value)
        {
            if (isPressEqual)
            {
                newCalculate = false;
            }
            if (newCalculate)
            {
                if (!isPressMath)
                {
                    math = value;
                    isPressMath = true;
                }
                else if (isPressMath && math != value)
                {
                    math = value;
                    isPressMath = true;
                }
            }
            else
            {
                firstTemp = finalResult.ToString();
                if (!isPressMath)
                {
                    math = value;
                    isPressMath = true;
                }
                else if (isPressMath && math != value)
                {
                    math = value;
                    isPressMath = true;
                }
            }
            UpdateLable();
        }
        // ==========================
        private void btnNum1_Click(object sender, EventArgs e)
        {
            UpdateTemp("1");
            UpdateLable();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            UpdateTemp("2");
            UpdateLable();
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            UpdateTemp("3");
            UpdateLable();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            UpdateTemp("4");
            UpdateLable();
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            UpdateTemp("5");
            UpdateLable();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            UpdateTemp("6");
            UpdateLable();
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            UpdateTemp("7");
            UpdateLable();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            UpdateTemp("8");
            UpdateLable();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateTemp("9");
            UpdateLable();
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            if (!isPressMath)
            {
                if (!firstTemp.Contains("."))
                {
                    UpdateTemp(".");
                    UpdateLable();
                }
            }
            else
            {
                if (!secondTemp.Contains("."))
                {
                    UpdateTemp(".");
                    UpdateLable();
                }
            }

        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            UpdateTemp("0");
            UpdateLable();
        }

        private void btnRemoveLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (!newCalculate)
                {
                    if (secondTemp != "")
                    {
                        secondTemp = secondTemp.Remove(secondTemp.Length - 1);
                    }
                    else
                    {
                        if (math != "")
                        {
                            math = math.Remove(math.Length - 1);
                            isPressMath = false;
                        }
                    }
                }
                else
                {
                    if (secondTemp != "")
                    {
                        secondTemp = secondTemp.Remove(secondTemp.Length - 1);
                    }
                    else
                    {
                        if (math != "")
                        {
                            math = math.Remove(math.Length - 1);
                            isPressMath = false;
                        }
                        else
                        {
                            if (firstTemp != "")
                            {
                                firstTemp = firstTemp.Remove(firstTemp.Length - 1);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Cannot delete with nothing!");
            }
            finally
            {
                UpdateLable();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            UpdateMath("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {

            UpdateMath("-");
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {

            UpdateMath("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {

            UpdateMath("/");
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double firstNumber;

            double secondNumber;
            if (double.TryParse(firstTemp, out firstNumber))
            {
                firstNumber = double.Parse(firstTemp);
            }
            if (double.TryParse(secondTemp, out secondNumber))
            {
                secondNumber = double.Parse(secondTemp);
            }
            Calculate(math);
            UpdateLable();

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValues();
            UpdateLable();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1: // Handle both D1 and NumPad1
                    btnNum1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btnNum2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btnNum3.PerformClick();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btnNum4.PerformClick();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btnNum5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btnNum6.PerformClick();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btnNum7.PerformClick();
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    btnNum8.PerformClick();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btnNum9.PerformClick();
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    btnNum0.PerformClick();
                    break;
                case Keys.OemPeriod:
                    btnComma.PerformClick();
                    break;
                case Keys.Back:
                    btnRemoveLast.PerformClick();
                    break;
                case Keys.Add:
                    btnAdd.PerformClick();
                    break;
                case Keys.Subtract:
                    btnMinus.PerformClick();
                    break;
                case Keys.Multiply:
                    btnMulti.PerformClick();
                    break;
                case Keys.Divide:
                    btnDiv.PerformClick();
                    break;
                case Keys.Enter: // Handle the '=' key
                    btnEqual.PerformClick();
                    break;
                case Keys.Escape:
                    btnReset.PerformClick();
                    break;
                default:
                    break;
            }
        }


    }
}
