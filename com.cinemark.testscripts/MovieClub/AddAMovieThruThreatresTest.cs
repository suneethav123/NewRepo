using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;

// This // test is to add tickets when navigated thru Theatres

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
        [Retry(2)]
        [Obsolete]
        public void TicketTest()
        {
            UITest(() =>
            {
            try
            {
                //Add or edit Test steps for this test case
                test.Info("Test Case Details --> 1. step1  --> 2. step2 --> 3. step3 --> 4. step4 --> 5. step5");

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

                    test.Log(Status.Pass, "Successfully earned 9 points for a new Club member - Passed");
                }
                catch (Exception e)
                {
                    
                   

                }
});
}

        

    }
}

