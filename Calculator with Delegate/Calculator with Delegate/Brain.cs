using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_with_Delegate
{
    public enum WhatOperation
    {
        Plus,
        Minus,
        Divide,
        Multiply,
        None
    }

    public enum State
    {
        Zero,
        AccumulateDigits,
        Compute,
        Result
    }

    public class Brain
    {
        MyDelegate d;

        string text;

        string first;
        string second;

        WhatOperation operation = WhatOperation.None;
        State state = State.Zero;


        public Brain(MyDelegate d)
        {
            this.d = d;
        }

        public void Process(string command)
        {
            switch (state)
            {
                case State.Zero:
                    Zero(false, command);
                    break;
                case State.AccumulateDigits:
                    AccumulateDigits(false, command);
                    break;
                case State.Compute:
                    Compute(false, command);
                    break;
                case State.Result:
                    Result(false, command);
                    break;
            }

        }

        void Zero(bool input, string command)
        {
            if (input)
            {
                d.Invoke("0");
            }
            else
            {
                if (command.Length == 1 && command[0] <= '9' && command[0] > '0')
                {
                    AccumulateDigits(true, command);
                }
                else
                {
                    Zero(true, command);
                }
            }
        }

        void AccumulateDigits(bool input, string command)
        {
            if (input)
            {
                state = State.AccumulateDigits;
                text = text + command;
                d.Invoke(text);
            }
            else                                                  // состояние false 
            {
                if (command.Length == 1 && command[0] == '+')
                {
                    Compute(true, command);
                    operation = WhatOperation.Plus;
                }
                else if(command.Length == 1 && command[0] == '-')
                {
                    Compute(true, command);
                    operation = WhatOperation.Minus;
                }
                else if (command.Length == 1 && command[0] == '×')
                {
                    Compute(true, command);
                    operation = WhatOperation.Multiply;
                }
                else if (command.Length == 1 && command[0] == '/')
                {
                    Compute(true, command);
                    operation = WhatOperation.Divide;
                }

                
                else if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
                {
                    AccumulateDigits(true, command);
                }

                else if (command.Length == 1 && command[0] == '=')
                {
                    Result(true, command);
                }
            }
        }

        void Compute(bool input, string command)
        {
            if (input)
            {
                state = State.Compute;
                first = text;
                text = "";
            }
            else
            {
                if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
                {
                    AccumulateDigits(true, command);
                }
            }
        }

        void Result(bool input, string command)
        {
            if (input)
            {
                state = State.Result;
                second = text;
                switch (operation)
                {

                    case WhatOperation.Plus:
                        text = (int.Parse(first) + int.Parse(second)).ToString();
                        break;

                    case WhatOperation.Minus:
                        text = (int.Parse(first) - int.Parse(second)).ToString();
                        break;

                    case WhatOperation.Multiply:
                        text = (int.Parse(first) * int.Parse(second)).ToString();
                        break;

                    case WhatOperation.Divide:
                        text = (int.Parse(first) / int.Parse(second)).ToString();
                        break;
                    case WhatOperation.None:
                        text = "MATH ERROR!";
                        break;
                    
                    default:
                        break;
                }

                d.Invoke(text);
                text = "";
            }
            else if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
            {
                AccumulateDigits(true, command);
            }
            else
            {
                AccumulateDigits(false, command);
                
            }
        }
    }
}
//else if (command.Length == 1 && command[0] == '%')
//{
//    Compute(true, command);
//    operation = WhatOperation.Percent;
//}
//else if (command.Length == 1 && command[0] == '²')
//{
//    Compute(true, command);
//    operation = WhatOperation.Sqrd;
//}

//else if (command.Length == 1 && command[0] == '√')
//{
//    Compute(true, command);
//    operation = WhatOperation.Sqrt;
//}


//case WhatOperation.Percent:
//    text = (int.Parse(first) / 100).ToString();
//    break;
//case WhatOperation.Sqrd:
//    text = (int.Parse(first) * int.Parse(first)).ToString();
//    break;
//case WhatOperation.Sqrt:
//    text = (int.Parse(first) / int.Parse(second)).ToString();
//    break;