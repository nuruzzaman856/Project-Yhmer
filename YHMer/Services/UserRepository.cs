using Microsoft.AspNetCore.Http;


namespace YHmer.Services
{
    public class UserRepository
    { 
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public UserRepository(IHttpContextAccessor httpContextAccessor) 
        { 
            _httpContextAccessor = httpContextAccessor; 
        } 
        public void LogCurrentUser() 
        { 
            var username = _httpContextAccessor.HttpContext.User.Identity.Name; 
            //service.LogAccessRequest(username); 
        } 
    }
}
