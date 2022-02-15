using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Models;
using WorkManagement.Users.Models;

namespace WorkManagement.Users.Services
{
    public interface IUsersService
    {
        ResponseViewModel<UserViewModel> CheckIfUserExists(string phoneNumber);
        ResponseViewModel<bool> DeleteUser(int userId);
        ResponseViewModel<List<UserViewModel>> GetUsers(int? userId, string phoneNumber, bool? active, bool? isAdmin, int? top, bool bringAll);
        ResponseViewModel<int> InserUser(string phoneNumber, string firstName, string lastName);
        bool UpdateAdminState(int userId, bool isAdmin);
        ResponseViewModel<bool> UpdateUser(string phoneNumber, string firstName, string lastName);
        bool UpdateUserActivationState(int userId, bool active);
    }
}
