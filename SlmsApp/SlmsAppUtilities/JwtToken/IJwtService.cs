using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppUtilities.JwtToken
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
