using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Users.DAL;

namespace WorkManagement.Users.BL
{
    public class UsersBL : IUsersBL
    {
        #region Private Members

        private IUsersDAL m_userDAL;

        #endregion


        #region Constructors

        public UsersBL()
        {
            m_userDAL = new UsersDAL();
        }

        #endregion


        #region Public Methods

        public UserDTO CheckIfUserExists(string phoneNumber) => m_userDAL.CheckIfUserExists(phoneNumber);
        public bool DeleteUser(int userId) => m_userDAL.DeleteUser(userId);
        public List<UserDTO> GetUsers(int? userId, string phoneNumber, bool? active, bool? isAdmin, int? top, bool bringAll) => m_userDAL.GetUsers(userId, phoneNumber, active, isAdmin, top, bringAll);
        public int InserUser(string phoneNumber, string firstName, string lastName) => m_userDAL.InserUser(phoneNumber, firstName, lastName);
        public bool UpdateAdminState(int userId, bool isAdmin) => m_userDAL.UpdateAdminState(userId, isAdmin);
        public bool UpdateUser(string phoneNumber, string firstName, string lastName) => m_userDAL.UpdateUser(phoneNumber, firstName, lastName);
        public bool UpdateUserActivationState(int userId, bool active) => m_userDAL.UpdateUserActivationState(userId, active);

        #endregion
    }
}
