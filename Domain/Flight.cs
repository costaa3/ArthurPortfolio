
namespace Domain
{
    public class Flight
    {
        private readonly int seatcapacity;
        public List<Booking> Bookings = new List<Booking>();

        public int SeatsAvailable { get; set; }

        public Flight(int seatcapacity)
        {
            SeatsAvailable = this.seatcapacity = seatcapacity;
        }

        public object? book(string passengerEmail, int seatsBooked)
        {
            if (seatsBooked > SeatsAvailable) return new OverbookingError();
            Bookings.Add(new Booking(passengerEmail, seatsBooked));
            SeatsAvailable -= seatsBooked;
            return null;
        }

        public object? Cancel(string email, int numberOfSeats)
        {
            var BookingsMatch = Bookings.Where(it => it.email.Equals(email));
            if(!BookingsMatch.Any()) {
                return new BookingNotFoundError();
            }
            SeatsAvailable += numberOfSeats;
            return null;
        }
    }

    public class OverbookingError
    {

    }
}
