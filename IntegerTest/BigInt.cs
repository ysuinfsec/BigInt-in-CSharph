using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerTest
{
    class BigInt
    {
        private List<int> arr;
        public int Sign { get; }

        public BigInt(List<int> num, int sign)
        {
            this.arr = num;
            this.Sign = sign;
        }

        public BigInt(int num)
        {
            arr = new List<int>();
            if (num > 0)
            {
                this.Sign = 1;
            }
            else if (num == 0)
            {
                this.Sign = 0;
            }
            else
            {
                this.Sign = -1;
                num = Math.Abs(num);
            }
            while (num > 0)
            {
                arr.Add(num % 10);
                num /= 10;
            }
        }

        public BigInt(BigInt num)
        {
            arr = new List<int>();
            this.Sign = num.Sign;
            this.arr = num.arr;
        }

        public BigInt(long num)
        {
            arr = new List<int>();
            if (num > 0)
            {
                this.Sign = 1;
            }
            else if (num == 0)
            {
                this.Sign = 0;
            }
            else
            {
                this.Sign = -1;
                num = Math.Abs(num);
            }
            while (num > 0)
            {
                arr.Add((int)(num % 10));
                num /= 10;
            }
        }

        public override string ToString()
        {
            string mynum = "";
            if (this.Sign < 0)
            {
                mynum += "-";
            }

            for (int i = this.arr.Count - 1; i >= 0; i--)
            {
                mynum += this.arr.ElementAt(i);
            }
            return mynum;
        }



        public static BigInt operator +(BigInt a, BigInt b)
        {
            if(a.arr.Count < b.arr.Count)
            {
                BigInt tmpint = new BigInt(a);
                a = b;
                b = tmpint;
            }

            List<int> added = new List<int>();
            int tmp = 0;
            for (int i = 0; i < a.arr.Count; i++)
            {
                int first = a.arr[i];
                int second = (i >= b.arr.Count) ? 0 :  b.arr[i];
                int plus = first + second;
                if (tmp != 0)
                {
                    plus += tmp;
                    tmp = 0;
                }
                if(plus >= 10)
                {
                    tmp = plus;
                    plus = plus % 10;
                    tmp = tmp / 10;
                }
                added.Add(plus);
            }
            BigInt c = new BigInt(added, 1);
            return c;
        }

    }
}
