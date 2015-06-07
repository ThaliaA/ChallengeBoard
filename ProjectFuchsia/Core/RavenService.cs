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

        public static List<Challenge> GetAllChallenges(Raven.Client.IDocumentSession session)
        {
            return session.Query<Challenge>().OrderByDescending(m => m.Text).ToList();

        }
    }
}