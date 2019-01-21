using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CustomSchemeProtoType.Controllers
{
    [Authorize(Policy = "Saml2Policy", AuthenticationSchemes = "Saml2Scheme")]
    public class SamlController:Controller
    {
        public IActionResult Test()
        {
            return Json("saml");
        }
    }
}
