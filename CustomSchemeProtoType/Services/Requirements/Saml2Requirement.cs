using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSchemeProtoType.Services.Requirements
{
    public class Saml2Requirement : IAuthorizationRequirement
    {
        public bool IsSaml { get; private set; }

        public Saml2Requirement(bool isSaml)
        {
            IsSaml = isSaml;
        }
    }
}
