namespace Application
{
    public class BookDto
    {
        public string PassengerEmail { get; set; }
        public int BookedSeats { get; set; }
        public Guid FlightId { get; internal set; }


        public BookDto(Guid fligthId, string passengerEmail, int numberOfSeats)
        {
            FlightId = fligthId;
            BookedSeats = numberOfSeats;
            PassengerEmail = passengerEmail;
        }


    }
}
