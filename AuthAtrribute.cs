namespace AlfredHospital.AuthData
{
    public class AuthAttribute : ActionFilterAttribute,
    IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContextfilterContext)
        {
            //Logic for authenticating a user    
            _auth = (filterContext.ActionDescripter.GetCustomAttributes(
                typeof(OverrideAuthenticationAttribute), true).Length == 0);
        }

        //Runs after the OnAuthentication method    
        public void OnAuthenticationChallenge(AuthenticationChallengeContextfilterContext)
        {
            //TODO: Additional tasks on the request    
        }
    }
}