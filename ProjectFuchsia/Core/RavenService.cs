using ProjectFuchsia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Raven.Client;

namespace ProjectFuchsia.Core
{
    public static class RavenService
    {
        public static void SaveChallenge(IDocumentSession session, Challenge challenge) {
           
           session.Store(challenge);
           session.SaveChanges();

        }

        public static List<Challenge> GetAllChallenges(IDocumentSession session)
        {
            return session.Query<Challenge>().OrderByDescending(m => m.Text).ToList();

        }

        public static User GetUser(IDocumentSession session, string name)
        {
            return session.Query<User>().Where(m => m.UserName == name.ToLower()).FirstOrDefault();
        }

        public static User CreateUser(IDocumentSession session, string name)
        {
            var user = new User { 
                UserName = name.ToLower()
            };

            session.Store(user);
            session.SaveChanges();

            return user;
        }

        public static User UpdateUser(IDocumentSession session, string name)
        {
            User user = session.Load<User>("users/" + name);
            if (user.CompletedChallenges == null)
            {
                user.CompletedChallenges = new List<string>();
            }

            //user.Score = user.Score + 7;
            session.SaveChanges();

            return user;
        }
    }
}