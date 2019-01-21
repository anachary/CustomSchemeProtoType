using Microsoft.AspNetCore.Authorization;
using CustomSchemeProtoType.Services.Requirements;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace CustomSchemeProtoType.Services.Handlers
{
    public class Saml2AuthorizationHandler : AuthorizationHandler<Saml2Requirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       Saml2Requirement requirement)
        {

            if (!context.User.HasClaim(c => c.Type == "saml2"))
            {
                return Task.CompletedTask;
            }

            var isSmal2 = Convert.ToBoolean(context.User.Claims.FirstOrDefault(c => c.Type == "saml2").Value);

            if (isSmal2)
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}