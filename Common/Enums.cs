using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public enum enumfinalStatus
    {
        Active = 1,
        Closed = 2,
        Deleted = 3
    }    
    public enum enumPermissions
    {
        Create = 1,
        View = 2,
        Edit = 3,
        Delete = 4,
        Export = 5,
        ActionMenu = 6
    }
    public enum enumUserStatus
    {
        Locked = 0,
        Active = 1,
        // Suspended = 2,
        InActive = 2,
        MultipleLoginAttempt = 4

    }
    public enum LoginErrorType
    {
        UsernameNotExist = 1,
        UsernamePasswordNotMatching = 2,
        UserStatusError = 3,
    }
    
}
