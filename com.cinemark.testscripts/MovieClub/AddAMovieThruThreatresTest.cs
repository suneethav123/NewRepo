using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;

// This test is to add tickets when navigated thru Theatres

namespace Cinemark.com.cinemark.testscripts
{
    class AddAMovieThruThreatresTest :BaseTest
    {
        
        private HomePage HP;
        private ChooseTheatre CT;
        private TheatreFeaturedMovies TF;
        private TimeSlots TS;
        private SelectTickets ST;

        
        
        [Test]
        [Obsolete]
        public void TicketTest()
        {
            HP = new HomePage(driver);
            CT = new ChooseTheatre(driver);
            TF = new TheatreFeaturedMovies(driver);
            TS = new TimeSlots(driver);
            ST = new SelectTickets(driver);

            HP.GoToTheatres();
            CT.LocationDropDown();
            CT.TheatreSelection();
            TF.MoviePick();
            TS.VirtualRealityMovieTimeSelection();
            ST.AddOneTicket();
            ST.AddTicketsToCart();
        }

        

    }
}

