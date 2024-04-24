namespace Domain
{
    public class Booking 
    {
        public string email { get; set; }
        public int bookedSeats { get; set; }


        public Booking(string email, int bookedSeats)
        {
            this.email = email;
            this.bookedSeats = bookedSeats;
        }
    }
}