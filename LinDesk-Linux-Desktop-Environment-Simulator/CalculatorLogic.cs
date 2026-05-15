using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class CalculatorLogic
    {
        public string Value = null;
        public void Press(string value)
        {
            Value = value;
        }
        public bool Operator = false;
        public bool Equals = false;
        public bool Clear = false;
        private string FS = null;
        private string SS = null;
        private string OP = "";
        public void Calculator(TextBlock CalcOutput) 
        {
            
            if (Operator == false)
            {
                FS = FS + Value;
            }
            else if (Operator == true && Equals == false)
            {
                if (Value == "+" || Value == "-" || Value == "*" || Value == "/")
                {
                    OP = Value;
                    //do literally nothing for now, just wait for the next number to be entered
                }
                else
                {
                    SS = SS + Value;
                }
            }


            if (Equals == true)
            {
                double FirstNum = Convert.ToDouble(FS);
                double SecondNum = Convert.ToDouble(SS);
                double Result = 0;
                if (OP == "+")
                {
                    Result = FirstNum + SecondNum;
                }
                else if (OP == "-")
                {
                    Result = FirstNum - SecondNum;
                }
                else if (OP == "*")
                {
                    Result = FirstNum * SecondNum;
                }
                else if (OP == "/")
                {
                    Result = FirstNum / SecondNum;
                }
                CalcOutput.Text = Result.ToString();
                Equals = false;
                Operator = false;
                FS = null;
                SS = null;
                OP = "";
                Clear = true;
            }
        }
    }
}
