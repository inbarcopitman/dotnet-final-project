using System.Linq;
using ASP.NET_Final_Project.Data;

namespace ASP.NET_Final_Project.Models
{
    public class Auth
    {
        private static ApplicationDbContext _db;

        public Auth(ApplicationDbContext db)
        {
            _db = db;
        }

        public static User CheckCredentials(User userObj)
        {
            return _db.Users.First(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
        }

        public void CheckAndAddActions()
        {
            var userId = 1;
            var numOfActions = 1;
            var User = _db.Users.First(x => x.Id == userId);
            User.NumOfActions = numOfActions + 1;
            // increase actions in session.
            _db.SaveChanges();
        }
    }
}