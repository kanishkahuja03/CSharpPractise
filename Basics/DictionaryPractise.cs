using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractise
{
    public class Session
    {
        public string SessionId { get; }
        public string UserId { get; }
        public DateTime LoginTime { get; }
        public DateTime LastActivityTime { get; private set; }

        public Session(string sessionId, string userId)
        {
            SessionId = sessionId;
            UserId = userId;
            LoginTime = DateTime.Now;
            LastActivityTime = LoginTime;
        }

        public void UpdateActivity()
        {
            LastActivityTime = DateTime.Now;
        }
    }

    public class SessionManager
    {
        private readonly Dictionary<string, Session> Sessions =
            new Dictionary<string, Session>();

        public void AddSession(string sessionId, string userId)
        {
            if (Sessions.ContainsKey(sessionId))
                throw new InvalidOperationException("Session already exists.");

            Sessions[sessionId] = new Session(sessionId, userId);
        }

        public bool RemoveSession(string sessionId)
        {
            return Sessions.Remove(sessionId);
        }

        public bool UpdateLastActivity(string sessionId)
        {
            if (Sessions.TryGetValue(sessionId, out var session))
            {
                session.UpdateActivity();
                return true;
            }
            return false;
        }

        public void PrintTotalActiveSessions()
        {
            Console.WriteLine($"Total active sessions: {Sessions.Count}");
        }

        public void PrintSessionDetails(string sessionId)
        {
            if (Sessions.TryGetValue(sessionId, out var session))
            {
                Console.WriteLine($"SessionId: {session.SessionId}");
                Console.WriteLine($"UserId: {session.UserId}");
                Console.WriteLine($"LoginTime: {session.LoginTime}");
                Console.WriteLine($"LastActivityTime: {session.LastActivityTime}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var manager = new SessionManager();

            manager.AddSession("S1", "UserA");
            manager.AddSession("S2", "UserB");

            Console.ReadLine();    // Pause to see different timestamps
            manager.UpdateLastActivity("S1");

            manager.PrintTotalActiveSessions();
            manager.PrintSessionDetails("S1");

            manager.RemoveSession("S2");
            manager.PrintTotalActiveSessions();
        }
    }

}