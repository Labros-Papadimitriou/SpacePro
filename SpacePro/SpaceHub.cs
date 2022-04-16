using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace SpacePro
{
    public class SpaceHub : Hub
    {
        private readonly Timer timer;
        public SpaceHub()
        {
            timer = new Timer(500);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ShowISSLocation();
        }

        public void ShowPeopleInSpace()
        {
            Clients.All.getPeopleInSpace();
        }

        private void ShowISSLocation()
        {
            Clients.All.issLocation();
        }

    }
}