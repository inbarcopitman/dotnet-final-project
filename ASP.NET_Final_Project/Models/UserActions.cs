using Microsoft.AspNetCore.Http;

namespace ASP.NET_Final_Project.Models
{
    public class UserActions
    {
        private static ISession _session;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserActions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public static bool DecreaseActions()
        {
            var numOfActions = _session.GetInt32("NumOfActionAllowed");
            var newActionNum = numOfActions - 1;
            if (newActionNum != 0)
            {
                var userId = _session.GetInt32("Id");
                // var User = _db.Users.First(x => x.Id == userId);
                // User.NumOfActions = newActionNum;
                // _db.SaveChanges();   
                // _session.SetInt32("NumOfActionAllowed", User.NumOfActions);
                return true;
            }

            return false;
        }
    }
}