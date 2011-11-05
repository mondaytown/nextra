using System.Web.Security;
using NExtra.Web.Security.Abstractions;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class implements IAuthenticationFacade and can be
    /// used as a facade for the static FormsAuthentication class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class FormsAuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Sign in a user.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="createPersistentCookie">Whether or not the login should be persisted.</param>
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        /// <summary>
        /// Sign out the currently logged in user.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}