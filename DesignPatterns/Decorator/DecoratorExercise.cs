using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class DecoratorExercise
    {
        MultiplyBy4 _MultiplyBy = new MultiplyBy4(new MultiplyBy2(new ShowValue()));

        public void Run(int value)
        {
            _MultiplyBy.CalculateValue(value);
        }
    }

    public class ShowValue : INumberManipulation
    {
        public int CalculateValue(int input) {

            Console.WriteLine($"the result is {input}");
            return input;

        }
    }

    public abstract class Decorator : INumberManipulation
    {
        public Decorator(INumberManipulation manipulation)
        {
                this.manipulation = manipulation;
        }

        INumberManipulation manipulation;

        public void SetManipulation(INumberManipulation manipulation) { 
        this.manipulation = manipulation;
        }


        public virtual int CalculateValue(int input)
        {
            if(manipulation == null)
            {
                return 0;
            }

            else
            {
                return manipulation.CalculateValue(input);
            }

           
        }
    }


    public class MultiplyBy2 : Decorator
    {
        public MultiplyBy2(INumberManipulation manipulation) : base(manipulation)
        {
        }

        public override int CalculateValue(int input)
        {
            return base.CalculateValue(input*2);
        }
    }



    public class MultiplyBy4 : Decorator
    {
        public MultiplyBy4(INumberManipulation manipulation) : base(manipulation)
        {
        }

        public override int CalculateValue(int input)
        {
            return base.CalculateValue(input * 4);
        }
    }
}
