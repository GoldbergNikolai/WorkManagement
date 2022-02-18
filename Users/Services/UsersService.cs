using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Models;
using WorkManagement.Models.Shared;
using WorkManagement.Users.BL;
using WorkManagement.Users.Models;

namespace WorkManagement.Users.Services
{
    public class UsersService : IUsersService
    {
        #region Private Members

        private IUsersBL m_userBL;

        #endregion


        #region Constructors

        public UsersService()
        {
            m_userBL = new UsersBL();
        }

        #endregion


        #region Public Methods

        public ResponseViewModel<UserViewModel> CheckIfUserExists(string phoneNumber)
        {
            var response = new ResponseViewModel<UserViewModel>();

            var userDTO = m_userBL.CheckIfUserExists(phoneNumber);

            if (userDTO.UserId > 0)
            {
                response.Data = new UserViewModel
                {
                    UserId = userDTO.UserId,
                    PhoneNumber = userDTO.PhoneNumber,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Active = userDTO.Active,
                    IsAdmin = userDTO.IsAdmin
                };
                response.ErrorDesc = response.Data.Active ? string.Empty : $"משתמש עם טלפון {phoneNumber} קיים במעכרת, אך לא פעיל. פנה לשירות לקוחות להפעלה.";
            }
            else
            {
                response.Data = null;
                response.ErrorDesc = $"משתמש עם טלפון {phoneNumber} לא קיים במעכרת";
            }
            

            return response;
        }

        public ResponseViewModel<bool> DeleteUser(int userId)
        {
            var response = new ResponseViewModel<bool>();

            response.Data = m_userBL.DeleteUser(userId);
            response.ErrorDesc = response.Data ? string.Empty : "מחיקת משתמש לא הצליחה.";
           
            return response;
        }

        public ResponseViewModel<List<UserViewModel>> GetUsers(int? userId, string phoneNumber, bool? active, bool? isAdmin, int? top, bool bringAll)
        {
            var response = new ResponseViewModel<List<UserViewModel>> { Data = new List<UserViewModel>() };

            var userDTOList = m_userBL.GetUsers(userId, phoneNumber, active, isAdmin, top, bringAll);

            try
            {
                if (userDTOList != null && userDTOList.Any())
                {
                    response.Data.AddRange(userDTOList.Select(userDTO =>
                    {
                        return new UserViewModel
                        {
                            UserId = userDTO.UserId,
                            PhoneNumber = userDTO.PhoneNumber,
                            FirstName = userDTO.FirstName,
                            LastName = userDTO.LastName,
                            Active = userDTO.Active,
                            IsAdmin = userDTO.IsAdmin
                        };
                    }));
                }
                else
                {
                    response.ErrorDesc = "לא נמאו משתמשים לפי נתוני חיפוש.";
                }
            }
            catch(Exception)
            {
                response.ErrorDesc = "קרתה תקלה בחיפוש משתמשים.";
            }

            return response;
        }

        public ResponseViewModel<int> InserUser(string phoneNumber, string firstName, string lastName)
        {
            var response = new ResponseViewModel<int>();

            response.Data = m_userBL.InserUser(phoneNumber, firstName, lastName);
            response.ErrorDesc = response.Data > 0 ? string.Empty : $"משתמש עם טלפון {phoneNumber} כבר קיים במעכרת";

            return response;
        }

        public ResponseViewModel<bool> UpdateAdminState(int userId, bool isAdmin)
        {
            var response = new ResponseViewModel<bool>();

            response.Data = m_userBL.UpdateAdminState(userId, isAdmin);
            response.ErrorDesc = response.Data ? string.Empty : "הפיכת משתמש לאדמיניסטרטור לא הצליחה.";

            return response;
        }

        public ResponseViewModel<bool> UpdateUser(string phoneNumber, string firstName, string lastName)
        {
            var response = new ResponseViewModel<bool>();

            response.Data = m_userBL.UpdateUser(phoneNumber, firstName, lastName);
            response.ErrorDesc = response.Data ? string.Empty : $"עדכון משתמש עם טלפון {phoneNumber} נכשל.";

            return response;
        }

        public ResponseViewModel<bool> UpdateUserActivationState(int userId, bool active)
        {
            var response = new ResponseViewModel<bool>();

            response.Data = m_userBL.UpdateUserActivationState(userId, active);
            response.ErrorDesc = response.Data ? string.Empty : "הפעלת משתמש לא הצליחה.";

            return response;
        }

        #endregion
    }
}
