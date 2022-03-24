using Entities.IdentityUsers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Controllers.HelperClasses
{
    public static class ApplicationUserHelper
    {
        #region SubOfTheMonth
        public static ApplicationUser GetSubOfTheMonth(this IEnumerable<ApplicationUser> users, IEnumerable<IdentityRole> roles)
        {
            var subs = GetSubscribers(users,roles);
            var count = subs.Count();
            if (IsLastDay(DateTime.Now) && !IsSubCountZero(count))
            {
                var randomIndex = GetRandomIndex(count);
                var winner = GetWinner(subs, randomIndex);
                return winner;
            }
            return null;
        }

        public static bool IsLastDay(DateTime date) => date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        public static bool IsSubCountZero(int count) => count == 0;
        public static ApplicationUser GetWinner(IEnumerable<ApplicationUser> subs, int randomIndex)
        {
            return subs.Where((x, i) => i == randomIndex).FirstOrDefault();
        }
        public static int GetRandomIndex(int count)
        {
            Random random = new Random();
            return random.Next(count);
        }
        //this requires finding the roles name to string in order to work
        public static IEnumerable<ApplicationUser> GetSubscribers(IEnumerable<ApplicationUser> users,IEnumerable<IdentityRole> roles)
        {
            var subs = roles.Select(x => x.Name == "Subscriber"?x.Id:null).Where(x=>x!=null);
            return users.Where(x=>x.Roles.Any(s=>subs.Contains(s.RoleId)));
        }
        #endregion

        #region AuthorOfTheMonth
        public static ApplicationUser GetAuthorOfTheMonth(this IEnumerable<ApplicationUser> users, IEnumerable<IdentityRole> roles)
        {
            var authors = GetAuthors(users,roles);
            if (IsLastDay(DateTime.Now)&&IsSubCountZero(authors.Count()))
            {
                return GetAuthorWithMostLikes(authors);
            }
            return null;
        }
        //this requires finding the roles name to string in order to work
        public static IEnumerable<ApplicationUser> GetAuthors(IEnumerable<ApplicationUser> users,IEnumerable<IdentityRole> roles)
        {
            var authors = roles.Select(x => x.Name == "Author" ? x.Id : null).Where(x => x != null);
            return users.Where(x => x.Roles.Any(s =>authors.Contains(s.RoleId)));
        }
        public static ApplicationUser GetAuthorWithMostLikes(IEnumerable<ApplicationUser> authors)
        {
            return authors
                .Where(x=>x.UserPosts.Count()>0)
                .Select(x=>new {auth=x, likes=x.UserPosts.OrderByDescending(p=>p.PostLikes).First().PostLikes})
                .OrderByDescending(x=>x.likes).First().auth;
        }
        #endregion
    }
}