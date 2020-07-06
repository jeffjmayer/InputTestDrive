using System;

namespace InputTestDrive
{
    public class TestDrive
    {
        static void Main()
        {
            var input = new Input();
            input.CustomerInput();
        }
    }

    public abstract class InputWithHook
    {
        public void CustomerInput()
        {
            CustomerWants();
        }

        public void Serve(int answer)
        {
            Console.WriteLine("\n" + "Serving " + answer + "\n");
        }

        public virtual int CustomerWants()
        {
            return 0;
        }
    }

    public class Input : InputWithHook
    {
        public override int CustomerWants()
        {
            return GetUserInput();
        }

        public int GetUserInput()
        {
            Console.WriteLine("How many items would you like? ");

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());

                Serve(answer);
                CustomerInput();
            }
            catch
            {
                Console.WriteLine("IO error trying to read your answer needs to be a small integer" + "\n");
                CustomerInput();
            }

            return 0;
        }
    }
}
