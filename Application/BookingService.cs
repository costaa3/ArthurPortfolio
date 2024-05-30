using Data;
using Domain;

namespace Application
{
    public class BookingService
    {
        private Entities entities;

        public BookingService(Entities entities)
        {
            this.entities = entities;
        }

        public void Book(BookDto bookingDto)
        {
            Flight flight = entities.Flights.Find(bookingDto.FlightId);
            flight.book(bookingDto.PassengerEmail, bookingDto.BookedSeats);
            entities.SaveChanges();
        }
        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return entities.Flights.Find(flightId).Bookings.Select(book => new BookingRm(book.PassengerEmail, book.bookedSeats));
        }

        public object GetRemainingNumberOfSeatsFor(Guid flightId)
        {
            return entities.Flights.Find(flightId).SeatsAvailable;
        }

        public void RemoveBooking(CancelBookingDto cancelBookingDto)
        {
            Flight flight = entities.Flights.Find(cancelBookingDto.FlightId);
            flight.Cancel(cancelBookingDto.PassengerEmail, cancelBookingDto.BookedSeats);
            entities.SaveChanges();
        }
    }
}