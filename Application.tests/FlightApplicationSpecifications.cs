using Application.tests;
using Data;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Application;
using System.Security.Cryptography;

namespace Application.tests
{
    public class FlightApplicationSpecifications
    {
       readonly Entities entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options);
        readonly  BookingService bookingService ;

        public FlightApplicationSpecifications()
        {
            bookingService = new BookingService(entities);
        }
        [Theory]
        [InlineData(3, "a@b.com", 2)]
        [InlineData(5, "add@b.com", 1)]
        public void Books_Flights(int flightSeatsAvailable, string bookingEmail, int bookedSeats)
        {
          

            var flight = new Flight(flightSeatsAvailable);

            entities.Flights.Add(flight);



            
            bookingService.Book(new BookDto(flight.Id, bookingEmail, bookedSeats));
            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(new BookingRm(bookingEmail, bookedSeats));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(8)]
        public void Cancels_Flights(int remainingSeats)
        {
            //given
            var flight = new Flight(remainingSeats);
            entities.Flights.Add(flight); 
            bookingService.Book(new BookDto(flight.Id, "ac@outlook.pt", 2));

            //when
            bookingService.RemoveBooking(new CancelBookingDto(flight.Id, "ac@outlook.pt", 2));
            entities.SaveChanges();
            //then 
            bookingService.GetRemainingNumberOfSeatsFor(flight.Id).Should().Be(remainingSeats);
        }

    }

}



