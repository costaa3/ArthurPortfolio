
using Domain;
using FluentAssertions;
using SimpleCalculatorApp;
namespace UnitTestingLecture
{
    public class UnitTestingLectureTests
    {
        [Fact]
        public void Sum_of2_and_2_equals4()

        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 2);

            result.Should().Be(4);
            //if (result != 4) throw new Exception(@"The sum operation result of adding 2 plus 2 should be 4");
        }

        [Fact]
        public void Booking_of1Seat_SeatAvaiableReduceBy1()
        {
            Flight flight = new Flight(seatcapacity: 5);
            flight.SeatsAvailable.Should().Be(5);
            flight.book("arthurcmcosta@outlook.pt", 4);
            flight.SeatsAvailable.Should().Be(1);


        }
        [Fact]
        public void BookingFlightsSuccessfully()
        {
            var flight = new Flight(seatcapacity: 3);
            var error = flight.book("someone@outlook.pt", 1);
            error.Should().BeNull();
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(0, 3, 0)]
        [InlineData(2, 3, 2)]
        [InlineData(20, 10, 10)]
        public void BookingReducesTheNumberOfSeats(int numberOfSeats, int seatsBooked, int expectedResult)
        {
            var flight = new Flight(seatcapacity: numberOfSeats);
            flight.book("someone@outlook.pt", seatsBooked);
            flight.SeatsAvailable.Should().Be(expectedResult);

        }

        [Fact]
        public void Sum_of2_and_2_equals4_ExpressionBody() => new Calculator().Sum(2, 2).Should().Be(4);


        [Fact]
        public void RemembersBooking()
        {
            var flight = new Flight(seatcapacity: 150);
            flight.book("someone@okt.pt", 2);
            flight.Bookings.Should().ContainEquivalentOf(new Booking("someone@okt.pt", 2));
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(20, 2)]
        [InlineData(40, 5)]
        public void DeleteBooking(int startWithManySeats, int seatsToBook)
        {
            var flight = new Flight(startWithManySeats);
            flight.book("ac.com", seatsToBook);
            flight.Cancel("ac.com", seatsToBook);
            flight.SeatsAvailable.Should().Be(startWithManySeats);
        }


    }
}