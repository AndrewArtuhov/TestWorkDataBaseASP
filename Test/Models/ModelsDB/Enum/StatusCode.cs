using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.ModelsDB.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,

        CarNotFound = 10,

        OK = 200,
        InternalServerError = 500
    }
}
