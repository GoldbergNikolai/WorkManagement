using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagement.Users.DAL
{
    public class UsersDAL : IUsersDAL
    {
        #region Private Members

        private readonly string _dbName = @"(localdb)\MSSQLLocalDB";
        private string _connString;

        #endregion


        #region Constructors

        public UsersDAL()
        {
            //For Sql server Auth:
            //ConnString = $@"Data Source={_dbName};Initial Catalog=WorkManagement;User ID=ServerName;Password=Password";
            _connString = $@"Data Source={_dbName};Initial Catalog=WorkManagement;Integrated Security=True";
        }

        #endregion


        #region Public Methods

        public UserDTO CheckIfUserExists(string phoneNumber)
        {
            var userDTO = new UserDTO();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("CheckIfUserExists", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        conn.Open();

                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.HasRows)
                                    {
                                        int userIdIndex = reader.GetOrdinal("UserId");
                                        int phoneNumberIndex = reader.GetOrdinal("PhoneNumber");
                                        int firstNameIndex = reader.GetOrdinal("FirstName");
                                        int lastNameIndex = reader.GetOrdinal("LastName");
                                        int activeIndex = reader.GetOrdinal("Active");
                                        int isAdminIndex = reader.GetOrdinal("IsAdmin");


                                        userDTO.UserId = reader.IsDBNull(userIdIndex) ? 0 : reader.GetInt32(userIdIndex);
                                        userDTO.PhoneNumber = reader.IsDBNull(phoneNumberIndex) ? string.Empty : reader.GetString(phoneNumberIndex);
                                        userDTO.FirstName = reader.IsDBNull(firstNameIndex) ? string.Empty : reader.GetString(firstNameIndex);
                                        userDTO.LastName = reader.IsDBNull(lastNameIndex) ? string.Empty : reader.GetString(lastNameIndex);
                                        userDTO.Active = reader.IsDBNull(activeIndex) ? false : reader.GetBoolean(activeIndex);
                                        userDTO.IsAdmin = reader.IsDBNull(isAdminIndex) ? false : reader.GetBoolean(isAdminIndex);
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            userDTO = new UserDTO();
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                userDTO = new UserDTO();
            }

            return userDTO;
        }

        public bool DeleteUser(int userId)
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("DeleteUser", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();

                        try
                        {
                            success = command.ExecuteNonQuery() > 0;
                        }
                        catch (Exception)
                        {
                            success = false;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public List<UserDTO> GetUsers(int? userId, string phoneNumber, bool? active, bool? isAdmin, int? top, bool bringAll)
        {
            var userDTOList = new List<UserDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("GetUsers", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Active", active);
                        command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                        command.Parameters.AddWithValue("@Top", top);
                        command.Parameters.AddWithValue("@BringAll", bringAll);
                        conn.Open();

                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    int userIdIndex = reader.GetOrdinal("UserId");
                                    int phoneNumberIndex = reader.GetOrdinal("PhoneNumber");
                                    int firstNameIndex = reader.GetOrdinal("FirstName");
                                    int lastNameIndex = reader.GetOrdinal("LastName");
                                    int activeIndex = reader.GetOrdinal("Active");
                                    int isAdminIndex = reader.GetOrdinal("IsAdmin");

                                    while (reader.Read())
                                    {
                                        var userDTO = new UserDTO();

                                        userDTO.UserId = reader.IsDBNull(userIdIndex) ? 0 : reader.GetInt32(userIdIndex);
                                        userDTO.PhoneNumber = reader.IsDBNull(phoneNumberIndex) ? string.Empty : reader.GetString(phoneNumberIndex);
                                        userDTO.FirstName = reader.IsDBNull(firstNameIndex) ? string.Empty : reader.GetString(firstNameIndex);
                                        userDTO.LastName = reader.IsDBNull(lastNameIndex) ? string.Empty : reader.GetString(lastNameIndex);
                                        userDTO.Active = reader.IsDBNull(activeIndex) ? false : reader.GetBoolean(activeIndex);
                                        userDTO.IsAdmin = reader.IsDBNull(isAdminIndex) ? false : reader.GetBoolean(isAdminIndex);

                                        userDTOList.Add(userDTO);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            userDTOList = new List<UserDTO>();
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                userDTOList = new List<UserDTO>();
            }

            return userDTOList;
        }

        public int InserUser(string phoneNumber, string firstName, string lastName)
        {
            int userId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("InsertUser", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        conn.Open();

                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    int userIdIndex = reader.GetOrdinal("UserId");

                                    while (reader.Read())
                                    {
                                        userId = reader.IsDBNull(userIdIndex) ? 0 : reader.GetInt32(userIdIndex);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            userId = 0;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                userId = 0;
            }

            return userId;
        }

        public bool UpdateAdminState(int userId, bool isAdmin)
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateAdminState", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                        conn.Open();

                        try
                        {
                            success = command.ExecuteNonQuery() > 0;
                        }
                        catch (Exception)
                        {
                            success = false;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public bool UpdateUser(string phoneNumber, string firstName, string lastName)
        {
            bool success = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateUser", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        conn.Open();

                        try
                        {
                            success = command.ExecuteNonQuery() > 0;
                        }
                        catch (Exception)
                        {
                            success = false;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public bool UpdateUserActivationState(int userId, bool active)
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateUserActivationState", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Active", active);
                        conn.Open();

                        try
                        {
                            success = command.ExecuteNonQuery() > 0;
                        }
                        catch (Exception)
                        {
                            success = false;
                        }
                        finally
                        {
                            if (conn.State != ConnectionState.Closed)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        #endregion
    }
}
