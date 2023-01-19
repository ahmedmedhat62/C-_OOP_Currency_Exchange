using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlTypes;
using System.Security.Policy;

namespace oop1
{
    class acc : IComparable<acc>, IEquatable<acc>
    {
        char _sign;
        int _money ;
        int _fp_money ;
        string _currency;
        public char sign
        {
            get => _sign;
            set
            {

                
                    _sign = value;
                
                
            }
        }
        public int money
        {
            get => _money;
            set
            {
                
                    _money = value;
                

            }
        }
        public int fp_money
        {
            get => _fp_money;
            set
            {
                
                _fp_money = value;
            }
        }
        public string currency
        {
            get => _currency;
            set
            {
                _currency = value;
            }
        }
        public acc()
        {
            Random rnd = new Random();
            money = rnd.Next(1, 6874);
            fp_money = rnd.Next(0, 99);
            int rnd_cur;
            int rnd_cur2;
            rnd_cur = rnd.Next(1, 4);
            rnd_cur2 = rnd.Next(1,3);

            if(rnd_cur2 == 1 || rnd_cur2 == 2)
            {
                sign = '+';
            }
            if(rnd_cur2 == 1)
            {
                sign = '-';
            }
            if (rnd_cur == 1)
            {
                currency = "usd";
            }
            else if (rnd_cur == 2)
            {
                currency = "eur";
            }
            else if (rnd_cur == 3)
            {
                currency = "rub";
            }
            if (sign == '-' || sign == '+')
            {
                sign = sign;
            }
            else
            {
                sign = '\0';
                Console.WriteLine("sign not valid");
            }

            this.money = money;
            if ((fp_money < 99) && fp_money > 0)
            {
                fp_money = fp_money;
            }
            else
            {
                fp_money = 0;
                Console.WriteLine("number of fractional money not valid");
            }
            if ((currency == "rub") || (currency == "usd") || (currency == "eur"))
            {
                currency = currency;
            }
            else
            {
                currency = "";
                Console.WriteLine("currency not valid");
            }
            

            //  Console.WriteLine(sign, _money, _fp_money, currency);
        } 
        
       

        public acc(string Whole_number )
        {
            sign = Whole_number[0];
            
            string sm = "";
            string sfm = "";
            for(int i =1; i < Whole_number.Length; i++)
            {
                if (Whole_number[i] == '.')
                {

                    break;
                    
                }

                sm += Whole_number[i];
                
            }
            for (int i =sm.Length+2 ; i < Whole_number.Length-3; i++)
            {
                sfm += Whole_number[i];

            }
            
            for(int i =Whole_number.Length-3;i < Whole_number.Length; i++)
            {
                currency += Whole_number[i];
            }
            
            if(sign == '-'|| sign == '+')
            {
                sign = sign;
            }
            else
            {
                sign = '\0';
                Console.WriteLine("sign not valid");
            }
            money = Int32.Parse(sm);
            
            fp_money = Int32.Parse(sfm);
            if( (fp_money < 99) && fp_money > 0 )
            {
                fp_money = fp_money;
            }
            else
            {
                fp_money = 0;
                Console.WriteLine("number of fractional money not valid");
            }

            if ((currency == "rub") || (currency == "usd") || (currency == "eur"))
            {
                currency  = currency ;
            }
            else
            {
                currency = "";
                Console.WriteLine("currency not valid");
            }
            
        }
       
         
        public Tuple<int,int,string> Transfer(acc acc2)
        {
            
            if (currency == "usd" && acc2.currency == "eur")
            {
                money = money * 2;
                fp_money = fp_money * 2;
                currency = acc2.currency;
            }
            if(currency == "usd"&&acc2.currency == "rub")
            {
                money = money * 4;
                fp_money = fp_money * 4;
                currency = acc2.currency;
            }
            if(currency == "eur"&& acc2.currency == "usd")
            {
                acc2.money = acc2.money * 2;
                acc2.fp_money = acc2.fp_money * 2;
                currency = currency;
            }
            if(currency == "eur"&& acc2.currency == "rub")
            {
                money = money * 2;
                fp_money = fp_money * 2;
                currency = acc2.currency;
            }
            if(currency == "rub"&& acc2.currency == "usd")
            {
                acc2.money = acc2.money * 4;
                acc2.fp_money = acc2.fp_money * 4;
                currency= currency;
            }
            if(currency == "rub"&& acc2.currency == "eur")
            {
                acc2.money = acc2.money * 2;
                acc2.fp_money = acc2.fp_money * 2;
                currency = currency;
            }
            var tuple2 = new Tuple<int, int,string>(acc2.money, money,currency);

            
            return (tuple2);
           
            
        }
        public Tuple  <int,int,string> addition(acc acc2)
        {
            
            
            

            
            if(currency != acc2.currency)
            {
                
                Transfer(acc2);
                

            }
            int sum = money + acc2.money;
            int fsum = fp_money + acc2.fp_money;
            if(fsum > 100)
            {
                fsum = fsum - 100;
                sum = sum + 1;
            }
            money = sum;
            fp_money = fsum;
           
            var tuple = new Tuple<int, int,string>(sum, fsum,currency);
            Console.Write(sum);
            Console.Write(",");
            Console.Write(fsum);
            Console.Write(currency);
            Console.WriteLine();

            return (tuple);
           

        }
        public Tuple<int, int, string> substraction(acc acc2)
        {





            if (currency != acc2.currency)
            {

                Transfer(acc2);


            }
            int sum = money - acc2.money;
            int fsum = fp_money - acc2.fp_money;
            
            if (fsum < 0)
            {
                fsum = fsum + 100;
                sum = sum - 1;
            }
            money = sum;
            fp_money = fsum;

            var tuple = new Tuple<int, int, string>(sum, fsum, currency);
            Console.Write(sum);
            Console.Write(",");
            Console.Write(fsum);
            Console.Write(currency);
            Console.WriteLine();

            return (tuple);


        }
        public Tuple<int, int> add(int num,int fnum)
        {
            money += num;
            if(fnum+fp_money > 100)
            {
                money += 1;
                fp_money += fnum-100;
            }
            else
            {
                fp_money += fnum;
            }



            var tuple = new Tuple<int, int>(money, fp_money);
           

            return (tuple);


        }
        public Tuple<int, int> sub(int num, int fnum)
        {
            money -= num;
            if (fp_money - fnum < 0)
            {
                money -= 1;
                fp_money -= fnum ;
                fp_money *= -1;
            }
            else
            {
                fp_money -= fnum;
            }



            var tuple = new Tuple<int, int>(money, fp_money);


            return (tuple);


        }
        public bool Equals(acc other)
        {
            if (other == null)
                return false;

            return money == other.money && fp_money == other.fp_money && sign == other.sign && currency == other.currency;
        }
        public int CompareTo(acc other)
        {
            if (other == null)
                return 1;

            int money_compare = money.CompareTo(other.money);
            
            if (currency != other.currency)
                throw new InvalidOperationException("Cannot compare money of different currencies.");
            if(money_compare == 0)
            {
                return fp_money.CompareTo(other.fp_money);
            }
            else { 

            return money.CompareTo(other.money);
                }
        }



        public acc(acc oldAcc)
        {
            this.sign = oldAcc.sign;
            this.money = oldAcc.money;
            this.fp_money = oldAcc.fp_money;
            this.currency = oldAcc.currency;
            
        }

        
       
        internal class Program
        {
            static void Main(string[] args)
            {
                acc account = new acc("+500.90usd");
                acc account2 = new acc();
                Console.WriteLine(account.Equals(account2));
                Console.WriteLine(account.add(10,55));
                Console.WriteLine(account.sub(10, 55));
                Console.WriteLine(account.addition(account2));
                Console.WriteLine(account.substraction(account2));
                Console.WriteLine (account.CompareTo(account2));

                 
                
            }
        }
    }
}
