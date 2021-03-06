using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //AccessToken ımızın 2 tane bilgisi var. jwthelperda 2 bilgiyi yazcan o yüzden CreateToken içinde bi AccessToken dönerken
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
