using System;

public class FizzBuzz
{
    public void FizzBuzz()
    {
    }

    public void StandardFizzBuzz()
    {
        int numbers = 100;
        for (int i = 1; i <= numbers; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                Console.WriteLine("FizzBuzz");
            else if (i % 3)
                Console.WriteLine("Fizz");
            else if (i % 5)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(i.ToString());
        }
    }

    public void FizzBuzzUsingOutput()
    {
        int numbers = 100;
        for (int i = 1; i <= numbers; i++)
        {
            string output = "";

            if (i % 3)
                output += "Fizz";

            if (i % 5)
                output += "Buzz";

            output = output != "" ? output : i.ToString;

            Console.WriteLine(output);
        }
    }

    // still uses a conditional...
    public void FizzBuzzWithoutIf()
    {
        for (int i = 1; i <= 100; i++)
            Console.WriteLine(i % 3 == 0 && i % 5 == 0 ? "FizzBuzz" : i % 3 == 0 ? "Fizz" : i % 5 == 0 ? "Buzz" : i.ToString());
    }
}