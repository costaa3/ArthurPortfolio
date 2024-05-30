using FluentAssertions;

namespace testingSum
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2, 1, 1, 1, 2, 3, 4, 5, 2)]
        [InlineData(2, 2, 1, 1, 2, 3, 4, 5, 1, 3, 0)]
        public void Test1(int expectedOutcome, int sumToFind, params int[] numbers)
        {
            Exercise.SumOfTwo(numbers, sumToFind).Should().Be(expectedOutcome);
        }
    }
}