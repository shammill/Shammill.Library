using System;
using System.Collections;

namespace SamsLibrary
{
    public class Loops
    {
        public Loops()
        {

        }

        public void StandardForLoop()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i;
            }
        }

        public void StandardWhileLoop()
        {
            int number = 100;
            while (number > 0)
            {
                number--;
            }
        }

        public void RecursiveLoop(int number)
        {
            if (number > 0)
            {
                number--;
                RecursiveLoop(number);
            }
        }
    }
}