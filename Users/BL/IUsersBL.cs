using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagement.Users.BL
{
    public interface IUsersBL
    {
        UserDTO CheckIfUserExists(string phoneNumber);
        bool DeleteUser(int userId);
        List<UserDTO> GetUsers(int? userId, string phoneNumber, bool? active, bool? isAdmin, int? top, bool bringAll);
        int InserUser(string phoneNumber, string firstName, string lastName);
        bool UpdateAdminState(int userId, bool isAdmin);
        bool UpdateUser(string phoneNumber, string firstName, string lastName);
        bool UpdateUserActivationState(int userId, bool active);
    }
}
