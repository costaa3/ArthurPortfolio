
using SimpleCalculatorApp;

namespace UnitTestingLecture
{
    public class UnitTest1
    {
        [Fact]
        public void testingSum()

        {
            var calculator = new Calculator();

            if (calculator.addNumbers(2, 2) != 4) throw new Exception(@"The sum operation result of adding 2 plus 2 should be 4");
        }

       
    }
}