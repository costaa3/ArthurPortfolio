namespace Application
{
    public class CancelBookingDto
    {
        public CancelBookingDto()
        {
        }
        public CancelBookingDto(Guid flightId,string passengerEmail, int bookedSeats)
        {
            PassengerEmail = passengerEmail;
            BookedSeats = bookedSeats;
            FlightId = flightId;
        }

        public string PassengerEmail { get; set; }
        public int BookedSeats { get; set; }
        public Guid FlightId { get; internal set; }

    
    }
}