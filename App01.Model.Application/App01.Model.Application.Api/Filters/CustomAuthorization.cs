using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App01.Model.Application.Api.Filters {
    public class CustomAuthorization {
        public static bool ValidateUserClaims (HttpContext context, string claimName, string claimValue) {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any (c => c.Type.Equals (claimName) && c.Value.Split (',').Contains (claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute {
        public ClaimsAuthorizeAttribute (string claimName, string claimValue) : base (typeof (RequestClaimFilter)) {
            Arguments = new object[] { new Claim (claimName, claimValue) };
        }
    }

    public class RequestClaimFilter : IAuthorizationFilter {
        private readonly Claim _claim;
        public RequestClaimFilter (Claim claim) {
            _claim = claim;

        }
        public void OnAuthorization (AuthorizationFilterContext context) {
            if(!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if(!CustomAuthorization.ValidateUserClaims(context.HttpContext, _claim.Type,_claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }

        }
    }
}