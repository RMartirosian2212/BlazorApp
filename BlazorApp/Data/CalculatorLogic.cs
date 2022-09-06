using Microsoft.JSInterop;
using System.Text;

namespace BlazorApp.Data
{
    public class CalculatorLogic
    {
        private string firstNumber { get; set; } = "";
        private string secondNumber { get; set; } = "";
        private string sign { get; set; } = "";
        private bool finish { get; set; } = false;
        public string equation { get; private set; } = "0";
        public List<string> equations { get; private set; } = new List<string>();
        public void ClearAllButton()
        {
            firstNumber = "";
            secondNumber = "";
            sign = "";
            finish = false;
            equation = "0";
        }
        public void GetValuesButton(string value)
        {
            if (value == "-" || value == "+" || value == "X" || value == "/")
            {
                sign = value;
                equation = sign;
            }
            else
            {
                if (secondNumber == "" && sign == "")
                {
                    firstNumber += value;
                    equation = firstNumber;
                }
                else if (firstNumber != "" && secondNumber != "" && finish)
                {
                    secondNumber += value;
                    equation = secondNumber;
                    finish = false;
                }
                else
                {
                    secondNumber += value;
                    equation = secondNumber;
                }

            }
        }
        public void ResultButton()
        {
            if (secondNumber == "")
            {
                secondNumber = firstNumber;
            }
            decimal a = decimal.Parse(firstNumber);
            decimal b = decimal.Parse(secondNumber);
            switch (sign)
            {
                case "-":
                    a = a - b;
                    equation = Convert.ToString(a);
                    AddToList(firstNumber, secondNumber, sign, equation);
                    secondNumber = "";
                    sign = "";
                    firstNumber = Convert.ToString(a);
                    break;
                case "+":
                    a = a + b;
                    equation = Convert.ToString(a);
                    AddToList(firstNumber, secondNumber, sign, equation);
                    secondNumber = "";
                    sign = "";
                    firstNumber = Convert.ToString(a);
                    break;
                case "X":
                    a = a * b;
                    equation = Convert.ToString(a);
                    AddToList(firstNumber, secondNumber, sign, equation);
                    secondNumber = "";
                    sign = "";
                    firstNumber = Convert.ToString(a);
                    break;
                case "/":
                    if (b == 0)
                    {
                        equation = "Error";
                        AddToList(firstNumber, secondNumber, sign, equation);
                        firstNumber = "";
                        secondNumber = "";
                        sign = "";
                    }
                    else
                    {

                        a = a / b;
                        equation = Convert.ToString(a);
                        AddToList(firstNumber, secondNumber, sign, equation);
                        secondNumber = "";
                        sign = "";
                        firstNumber = Convert.ToString(a);
                    }
                    break;
            }
            finish = true;
        }
        public void PercentButton()
        {
            decimal a;
            if (secondNumber == "" && sign == "")
            {
                a = decimal.Parse(firstNumber) / 100;
                firstNumber = $"{a}";
                equation = firstNumber;
            }
            else if (firstNumber != "" && secondNumber != "")
            {
                a = decimal.Parse(secondNumber) / 100;
                secondNumber = $"{a}";
                equation = secondNumber;
            }
        }
        public void PlusMinusButton()
        {
            decimal a;
            if (secondNumber == "")
            {
                a = decimal.Parse(firstNumber);
                a = -a;
                firstNumber = $"{a}";
                equation = firstNumber;
            }
            else if (firstNumber != "" && secondNumber != "")
            {
                a = decimal.Parse(secondNumber);
                a = -a;
                secondNumber = $"{a}";
                equation = secondNumber;
            }
        }
        public void AddToList(string firstNumber, string secondNumber, string sign, string equation)
        {
            if (secondNumber.StartsWith('-'))
            {
                equations.Add($"{firstNumber} {sign} ({secondNumber}) = {equation}");
            }
            else
            {
                equations.Add($"{firstNumber} {sign} {secondNumber} = {equation}");
            }

        }
        
    }
}
