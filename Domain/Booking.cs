namespace Domain
{
    public class Booking
    {
        public string PassengerEmail { get; set; }
        public int bookedSeats { get; set; }
        [Obsolete("ef core")]
        public Booking()
        {
            
        }

        public Booking(string email, int bookedSeats)
        {
            this.PassengerEmail = email;
            this.bookedSeats = bookedSeats;
        }
    }
}