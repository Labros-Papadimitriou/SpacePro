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
            timer = new Timer(10000);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ShowPeopleInSpace();
            ShowISSLocation();
        }

        private void ShowPeopleInSpace()
        {
            Clients.All.getPeopleInSpace();
        }

        private void ShowISSLocation()
        {
            Clients.All.issLocation();
        }

    }
}