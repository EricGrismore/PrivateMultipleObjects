using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{
    class CookieInc
    {
        private int _CookieId;
        private string _FirstName;
        private string _LastName;
        private int _Amount;

        public CookieInc()
        {
            _CookieId = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Amount = 0;
        }

        public CookieInc(int cookie, string firstName, string lastName, int amount)
        {
            _CookieId = cookie;
            _FirstName = firstName;
            _LastName = lastName;
            _Amount = amount;
        }

        public int getCookieID() { return _CookieId; }

        public string getLastName() { return _LastName; }

        public string getFirstName() { return _FirstName; }

        public void setAmount(int age) { _Amount = age; }

        public int getAmount() { return _Amount; }

        public void setCookieID(int cookie) { _CookieId = cookie; }

        public void setLastName(string lastName) { _LastName = lastName; }

        public void setFirstName(string firstName) { _FirstName = firstName; }

        public virtual void addChange()
        {
            Console.Write("COOKIEID=");
            setCookieID(int.Parse(Console.ReadLine()));

            Console.Write("First Name=");
            setFirstName(Console.ReadLine());

            Console.Write("Last Name=");
            setLastName(Console.ReadLine());

            Console.Write("Amount of cookies=");
            setAmount(int.Parse(Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {getCookieID()}");
            Console.WriteLine($"Name: {getFirstName()} {getLastName()}");
            Console.WriteLine($"Age: {getAmount()}");
        }
    }
    class CEmployer : CookieInc
    {
        private int _ECookie;
        private string _EName;

        public CEmployer()
            : base()
        {
            _EName = string.Empty;
            _ECookie = 0;
        }
        public CEmployer(int cookieid, string firstname, string lastname, int amount, int Ecookie, string Ename)
            : base(cookieid, firstname, lastname, amount)
        {
            _ECookie = Ecookie;
            _EName = Ename;
        }
        public void setECookie(int Ecookie) { _ECookie = Ecookie; }
        public double getECookie() { return _ECookie; }
        public void setEName(string Ename) { _EName = Ename; }
        public string getEName() { return _EName; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Cookies=");
            setECookie(int.Parse(Console.ReadLine()));

            Console.Write("Employers Name=");
            setEName(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Amount Of Cookies Get: {getECookie()}");
            Console.WriteLine($"Employers Name: {getEName()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many cookies do you want?");
            int chocolate;
            while (!int.TryParse(Console.ReadLine(), out chocolate))
                Console.WriteLine("Please enter a whole number");


            CookieInc[] emps = new CookieInc[chocolate];
            Console.WriteLine("How many cookies are being make per purchase?");
            int raisin;
            while (!int.TryParse(Console.ReadLine(), out raisin))
                Console.WriteLine("Please enter a whole number");

            CEmployer[] mgr = new CEmployer[raisin];

            int Number, C2, C3;
            int raiCounter = 0, cooCounter = 0;
            Number = Menu();
            while (Number != 4)
            {
                Console.WriteLine("Enter 1 for Buying or 2 for Making");
                while (!int.TryParse(Console.ReadLine(), out C3))
                    Console.WriteLine("1 for Buying or 2 for Making");
                try
                {
                    switch (Number)
                    {
                        case 1: 
                            if (C3 == 1) 
                            {
                                if (cooCounter <= raisin)
                                {
                                    mgr[cooCounter] = new CEmployer();
                                    mgr[cooCounter].addChange();
                                    cooCounter++;
                                }
                                else
                                    Console.WriteLine("The max number of cookies are being made");

                            }
                            else 
                            {
                                if (raiCounter <= chocolate)
                                {
                                    emps[raiCounter] = new CookieInc();
                                    emps[raiCounter].addChange();
                                    raiCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of cookies are being bought");
                            }

                            break;
                        case 2: 
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out C2))
                                Console.Write("Enter the record number you want to change: ");
                            C2--; 
                            if (C3 == 1) 
                            {
                                while (C2 > cooCounter - 1 || C2 < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out C2))
                                        Console.Write("Enter the record number you want to change: ");
                                    C2--;
                                }
                                mgr[C2].addChange();
                            }
                            else 
                            {
                                while (C2 > raiCounter - 1 || C2 < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out C2))
                                        Console.Write("Enter the record number you want to change: ");
                                    C2--;
                                }
                                emps[C2].addChange();
                            }
                            break;
                        case 3: 
                            if (C3 == 1) 
                            {
                                for (int i = 0; i < cooCounter; i++)
                                    mgr[i].print();
                            }
                            else 
                            {
                                for (int i = 0; i < raiCounter; i++)
                                    emps[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Number = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
