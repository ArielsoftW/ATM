using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATM_project_new
{
    class Program
    {
        public static int size = 2, connect = 1, AccNum = 0;
        public static double balance, CashOut;
        public static bool active = false;
        public static string[,] algorithm_String = new string[size, 2]; //0.Name,1.ExpiredDate,
        public static long[,] algorithm_Int = new long[size, 5]; //0.NumberAccount, 1.AccountCode, 2.CreditNumber, 3.SecretCode, 4.IDnumber
        public static double[] algorithm_Double = new double[size]; //Balance

        public static void haveAccount()
        {
            int NumAcc, CodAcc;

            Console.WriteLine("great lets start");
        NumberAccount:
            Console.WriteLine("what is your number account?");
            NumAcc = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                if (algorithm_Int[size, 0].Equals(NumAcc))
                {
                    Console.WriteLine("great");
                CodeAccount:
                    Console.WriteLine("what is your account code?");
                    CodAcc = int.Parse(Console.ReadLine());
                    for (int j = 0; j < size; j++)
                    {
                        if (algorithm_Int[size, 1].Equals(CodAcc))
                        {
                            Console.WriteLine("great you loged hello {0}", algorithm_String[j, 0]);
                            AccNum = j;
                        }
                        else
                        {
                            Console.WriteLine("you did wrong function pls try again");
                            Thread.Sleep(1500);
                            goto CodeAccount;
                        }
                    }
                    Console.WriteLine("hello {0} what do you want to do", algorithm_String[AccNum, 1]);
                    active = true;
                }
                else
                {
                    Console.WriteLine("you did wrong function pls try again");
                    Thread.Sleep(1500);
                    goto NumberAccount;
                }
            }
        }

        static void NewAccount()
        {
            Console.WriteLine("hello");
            Console.WriteLine("what is your name?");
            algorithm_String[connect, 0] = Console.ReadLine();

        IDnumber:
            Console.WriteLine("waht is your ID number?");
            long IDnum = long.Parse(Console.ReadLine());
            if (IDnum >= 000000001 && IDnum <= 9999999999999)
            {
                algorithm_Int[connect, 4] = IDnum;
            }
            else
            {
                goto IDnumber;
            }
        Credit:
            Console.WriteLine("what is your credit number?");
            long Credit = long.Parse(Console.ReadLine());
            if (Credit >= 000000000001 && Credit <= 9999999999999999)
            {
                algorithm_Int[connect, 2] = Credit;
            }
            else
            {
                goto Credit;
            }
        SecretCode:
            Console.WriteLine("waht is your Secret number?");
            int SecCod = int.Parse(Console.ReadLine());
            if (SecCod >= 001 && SecCod <= 999)
            {
                algorithm_Int[connect, 3] = SecCod;
            }
            else
            {
                goto SecretCode;
            }

            Console.WriteLine("what is your Expired Date?");
            Console.WriteLine("pls write like that xx/xx");
            algorithm_String[connect, 1] = Console.ReadLine();

        NumberAccount:
            Console.WriteLine("waht is your Number account?   (6 number)");
            int AccNum = int.Parse(Console.ReadLine());
            if (AccNum >= 000001 && AccNum <= 999999)
            {
                algorithm_Int[connect, 0] = AccNum;
            }
            else
            {
                goto NumberAccount;
            }

        CodeAccount:
            Console.WriteLine("waht is your Code for your account?   (4 number)");
            int CodeAcc = int.Parse(Console.ReadLine());
            if (CodeAcc >= 0001 && CodeAcc <= 9999)
            {
                algorithm_Int[connect, 1] = CodeAcc;
            }
            else
            {
                goto CodeAccount;
            }
            Console.WriteLine("waht is your Balance?");
            algorithm_Double[connect] = double.Parse(Console.ReadLine());
            connect++; ;
            size++;
            algorithm_Int = (long[,])ResizeArray(algorithm_Int, new long[] { size, 5 });
            algorithm_String = (string[,])ResizeArray(algorithm_String, new string[] { size, 2 });
            Console.WriteLine("thank you for sign up to the atm");

        }

        static void FirstLogin()
        {
            string Login;

            Console.WriteLine("Welcome to the ATM app");
        account:
            Console.WriteLine("Do You have acount");
            Console.WriteLine("y = yes, n = no");
            Login = Console.ReadLine();
            switch (Login)
            {
                case ("n"):
                    NewAccount();
                    break;

                case ("y"):
                    haveAccount();
                    break;

                default:
                    Console.WriteLine("you did wrong function pls try again");
                    Thread.Sleep(1500);
                    goto account;
            }

        }

        static void withdrawFunction()
        {
            string withdrawName;
            double withdraw;
            DateTime Time = DateTime.Now;

            Console.WriteLine("to who you want withdraw the money?");
            Console.WriteLine("*write the exact name of the person you want withdraw the cash");
            withdrawName = Console.ReadLine();
            int result = Array.IndexOf(algorithm_String, withdrawName);
            if (result <= -1)
            {
                Console.WriteLine("try again");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("who much money you want to withdraw?");
                withdraw = double.Parse(Console.ReadLine());
                if (withdraw <= algorithm_Double[AccNum])
                {
                    algorithm_Double[result] = algorithm_Double[result] + withdraw;
                    algorithm_Double[AccNum] = algorithm_Double[AccNum] - withdraw;

                    Console.WriteLine("your Transfer passed successfully at " + Time);
                    Console.WriteLine("your money balance now is " + algorithm_Double[AccNum] + " dollars");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        static void BalanceFunction()
        {
            Console.WriteLine("your balance is " + algorithm_Double[AccNum] + " dollars");
            Thread.Sleep(10000);
            Console.Clear();
        }

        static void DepositFunction()
        {
            double deposit;
            Console.WriteLine("who much money you want to deposit?");
            deposit = double.Parse(Console.ReadLine());
            algorithm_Double[AccNum] = algorithm_Double[AccNum] + deposit;
            Console.WriteLine("your money balance now is " + algorithm_Double[AccNum] + " dollars");
            Thread.Sleep(3000);
            Console.Clear();
        }

        public static void CashOutFunction()
        {
            static void MoreBalance()
            {
            CashOut1:
                Console.WriteLine("you can cash out up to 8000 dollar");
                Console.WriteLine("who much money you want to cash out?");
                CashOut = double.Parse(Console.ReadLine());
                if (CashOut <= 8000)
                {
                    Console.WriteLine("ok you cash out {0} dollars", CashOut);
                    algorithm_Double[AccNum] = algorithm_Double[AccNum] - CashOut;
                    Console.WriteLine("your money balance now is {0} dollars", algorithm_Double[AccNum]);
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("try again");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto CashOut1;
                }
            }
            static void LowerBalance()
            {
            CashOut2:
                Console.WriteLine("you can cash out up to {0} dollar ", balance);
                Console.WriteLine("who much money you want to cash out?");
                CashOut = double.Parse(Console.ReadLine());
                if (CashOut <= balance)
                {
                    Console.WriteLine("ok you cash out {0} dollars", CashOut);
                    algorithm_Double[AccNum] = algorithm_Double[AccNum] - CashOut;
                    Console.WriteLine("your money balance now is {0} dollars", algorithm_Double[AccNum]);
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("try again");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto CashOut2;
                }
            }
            static void EqualBalance()
            {
            CashOut3:
                Console.WriteLine("you can cash out up to 8000 dollar");
                Console.WriteLine("who much money you want to cash out?");
                CashOut = int.Parse(Console.ReadLine());
                if (CashOut <= 8000)
                {
                    Console.WriteLine("ok you cash out " + CashOut + " dollars");
                    algorithm_Double[AccNum] = algorithm_Double[AccNum] - CashOut;
                    Console.WriteLine("your money balance now is {0} dollars", algorithm_Double[AccNum]);
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("try again");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto CashOut3;
                }
            }
            Console.WriteLine("your balance is {0} dollars", algorithm_Double[AccNum]);
            balance = algorithm_Double[AccNum] * 0.20;
            if (balance > 8000)
            {
                MoreBalance();
            }
            else if (balance < 8000)
            {
                LowerBalance();
            }
            else
            {
                EqualBalance();
            }
        }

        static void Main(string[] args)
        {
            int Choise;
            while (!active)
            {
                FirstLogin();
            }
            Console.WriteLine("hello {0} what do you want to do", algorithm_String[1, AccNum]);  
        Choise:
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1.Withdraw       3.Deposit ");
            Console.WriteLine("2.Balance-Inq    4.Cash Out");
            Console.WriteLine("*pick a number");
            Choise = int.Parse(Console.ReadLine());
            switch (Choise)
            {
                case (1):
                    withdrawFunction();
                    break;
                case (2):
                    BalanceFunction();
                    break;
                case (3):
                    DepositFunction();
                    break;
                case (4):
                    CashOutFunction();
                    break;
                default:
                    Console.WriteLine("you did wrong function try again in 5 seconeds");
                    Thread.Sleep(5000);
                    Console.Clear();
                    goto Choise;
            }
        }

    }
}
