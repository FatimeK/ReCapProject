using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Encyripting
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey secururityKey)
        {
            return new SigningCredentials(secururityKey, SecurityAlgorithms.HmacSha512);        
        }
    }
}
