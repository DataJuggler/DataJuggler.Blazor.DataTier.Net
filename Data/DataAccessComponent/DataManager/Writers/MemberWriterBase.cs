

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class MemberWriterBase
    /// <summary>
    /// This class is used for converting a 'Member' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MemberWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Member member)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='member'>The 'Member' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Member member)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (member != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", member.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteMemberStoredProcedure(Member member)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteMember'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Member_Delete'.
            /// </summary>
            /// <param name="member">The 'Member' to Delete.</param>
            /// <returns>An instance of a 'DeleteMemberStoredProcedure' object.</returns>
            public static DeleteMemberStoredProcedure CreateDeleteMemberStoredProcedure(Member member)
            {
                // Initial Value
                DeleteMemberStoredProcedure deleteMemberStoredProcedure = new DeleteMemberStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteMemberStoredProcedure.Parameters = CreatePrimaryKeyParameter(member);

                // return value
                return deleteMemberStoredProcedure;
            }
            #endregion

            #region CreateFindMemberStoredProcedure(Member member)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindMemberStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Member_Find'.
            /// </summary>
            /// <param name="member">The 'Member' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindMemberStoredProcedure CreateFindMemberStoredProcedure(Member member)
            {
                // Initial Value
                FindMemberStoredProcedure findMemberStoredProcedure = null;

                // verify member exists
                if(member != null)
                {
                    // Instanciate findMemberStoredProcedure
                    findMemberStoredProcedure = new FindMemberStoredProcedure();

                    // Now create parameters for this procedure
                    findMemberStoredProcedure.Parameters = CreatePrimaryKeyParameter(member);
                }

                // return value
                return findMemberStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Member member)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new member.
            /// </summary>
            /// <param name="member">The 'Member' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Member member)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[24];
                SqlParameter param = null;

                // verify memberexists
                if(member != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", member.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [AdSpend] parameter
                    param = new SqlParameter("@AdSpend", member.AdSpend);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [ChannelName] parameter
                    param = new SqlParameter("@ChannelName", member.ChannelName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [ChannelUrl] parameter
                    param = new SqlParameter("@ChannelUrl", member.ChannelUrl);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If member.CreatedDate does not exist.
                    if (member.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.CreatedDate;
                    }
                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Description] parameter
                    param = new SqlParameter("@Description", member.Description);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Donations] parameter
                    param = new SqlParameter("@Donations", member.Donations);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [EmailAddress] parameter
                    param = new SqlParameter("@EmailAddress", member.EmailAddress);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [EmailVerified] parameter
                    param = new SqlParameter("@EmailVerified", member.EmailVerified);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [FirstName] parameter
                    param = new SqlParameter("@FirstName", member.FirstName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [IsAdmin] parameter
                    param = new SqlParameter("@IsAdmin", member.IsAdmin);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [LastLoginDate] Parameter
                    param = new SqlParameter("@LastLoginDate", SqlDbType.DateTime);

                    // If member.LastLoginDate does not exist.
                    if (member.LastLoginDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.LastLoginDate;
                    }
                    // set parameters[11]
                    parameters[11] = param;

                    // Create [LastName] parameter
                    param = new SqlParameter("@LastName", member.LastName);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [Link1] parameter
                    param = new SqlParameter("@Link1", member.Link1);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create [Link2] parameter
                    param = new SqlParameter("@Link2", member.Link2);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create [Link3] parameter
                    param = new SqlParameter("@Link3", member.Link3);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create [Location] parameter
                    param = new SqlParameter("@Location", member.Location);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create [PasswordHash] parameter
                    param = new SqlParameter("@PasswordHash", member.PasswordHash);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create [Premium] parameter
                    param = new SqlParameter("@Premium", member.Premium);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create [PremiumExpires] Parameter
                    param = new SqlParameter("@PremiumExpires", SqlDbType.DateTime);

                    // If member.PremiumExpires does not exist.
                    if (member.PremiumExpires.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.PremiumExpires;
                    }
                    // set parameters[19]
                    parameters[19] = param;

                    // Create [ProfilePicture] parameter
                    param = new SqlParameter("@ProfilePicture", member.ProfilePicture);

                    // set parameters[20]
                    parameters[20] = param;

                    // Create [PublicEmail] parameter
                    param = new SqlParameter("@PublicEmail", member.PublicEmail);

                    // set parameters[21]
                    parameters[21] = param;

                    // Create [TotalLogins] parameter
                    param = new SqlParameter("@TotalLogins", member.TotalLogins);

                    // set parameters[22]
                    parameters[22] = param;

                    // Create [UserName] parameter
                    param = new SqlParameter("@UserName", member.UserName);

                    // set parameters[23]
                    parameters[23] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertMemberStoredProcedure(Member member)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertMemberStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Member_Insert'.
            /// </summary>
            /// <param name="member"The 'Member' object to insert</param>
            /// <returns>An instance of a 'InsertMemberStoredProcedure' object.</returns>
            public static InsertMemberStoredProcedure CreateInsertMemberStoredProcedure(Member member)
            {
                // Initial Value
                InsertMemberStoredProcedure insertMemberStoredProcedure = null;

                // verify member exists
                if(member != null)
                {
                    // Instanciate insertMemberStoredProcedure
                    insertMemberStoredProcedure = new InsertMemberStoredProcedure();

                    // Now create parameters for this procedure
                    insertMemberStoredProcedure.Parameters = CreateInsertParameters(member);
                }

                // return value
                return insertMemberStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Member member)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing member.
            /// </summary>
            /// <param name="member">The 'Member' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Member member)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[25];
                SqlParameter param = null;

                // verify memberexists
                if(member != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", member.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [AdSpend]
                    param = new SqlParameter("@AdSpend", member.AdSpend);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ChannelName]
                    param = new SqlParameter("@ChannelName", member.ChannelName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [ChannelUrl]
                    param = new SqlParameter("@ChannelUrl", member.ChannelUrl);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If member.CreatedDate does not exist.
                    if (member.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.CreatedDate;
                    }

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Description]
                    param = new SqlParameter("@Description", member.Description);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Donations]
                    param = new SqlParameter("@Donations", member.Donations);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [EmailAddress]
                    param = new SqlParameter("@EmailAddress", member.EmailAddress);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [EmailVerified]
                    param = new SqlParameter("@EmailVerified", member.EmailVerified);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [FirstName]
                    param = new SqlParameter("@FirstName", member.FirstName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [IsAdmin]
                    param = new SqlParameter("@IsAdmin", member.IsAdmin);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [LastLoginDate]
                    // Create [LastLoginDate] Parameter
                    param = new SqlParameter("@LastLoginDate", SqlDbType.DateTime);

                    // If member.LastLoginDate does not exist.
                    if (member.LastLoginDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.LastLoginDate;
                    }

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [LastName]
                    param = new SqlParameter("@LastName", member.LastName);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [Link1]
                    param = new SqlParameter("@Link1", member.Link1);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [Link2]
                    param = new SqlParameter("@Link2", member.Link2);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create parameter for [Link3]
                    param = new SqlParameter("@Link3", member.Link3);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create parameter for [Location]
                    param = new SqlParameter("@Location", member.Location);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create parameter for [PasswordHash]
                    param = new SqlParameter("@PasswordHash", member.PasswordHash);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create parameter for [Premium]
                    param = new SqlParameter("@Premium", member.Premium);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create parameter for [PremiumExpires]
                    // Create [PremiumExpires] Parameter
                    param = new SqlParameter("@PremiumExpires", SqlDbType.DateTime);

                    // If member.PremiumExpires does not exist.
                    if (member.PremiumExpires.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = member.PremiumExpires;
                    }

                    // set parameters[19]
                    parameters[19] = param;

                    // Create parameter for [ProfilePicture]
                    param = new SqlParameter("@ProfilePicture", member.ProfilePicture);

                    // set parameters[20]
                    parameters[20] = param;

                    // Create parameter for [PublicEmail]
                    param = new SqlParameter("@PublicEmail", member.PublicEmail);

                    // set parameters[21]
                    parameters[21] = param;

                    // Create parameter for [TotalLogins]
                    param = new SqlParameter("@TotalLogins", member.TotalLogins);

                    // set parameters[22]
                    parameters[22] = param;

                    // Create parameter for [UserName]
                    param = new SqlParameter("@UserName", member.UserName);

                    // set parameters[23]
                    parameters[23] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", member.Id);
                    parameters[24] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateMemberStoredProcedure(Member member)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateMemberStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Member_Update'.
            /// </summary>
            /// <param name="member"The 'Member' object to update</param>
            /// <returns>An instance of a 'UpdateMemberStoredProcedure</returns>
            public static UpdateMemberStoredProcedure CreateUpdateMemberStoredProcedure(Member member)
            {
                // Initial Value
                UpdateMemberStoredProcedure updateMemberStoredProcedure = null;

                // verify member exists
                if(member != null)
                {
                    // Instanciate updateMemberStoredProcedure
                    updateMemberStoredProcedure = new UpdateMemberStoredProcedure();

                    // Now create parameters for this procedure
                    updateMemberStoredProcedure.Parameters = CreateUpdateParameters(member);
                }

                // return value
                return updateMemberStoredProcedure;
            }
            #endregion

            #region CreateFetchAllMembersStoredProcedure(Member member)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMembersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Member_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMembersStoredProcedure' object.</returns>
            public static FetchAllMembersStoredProcedure CreateFetchAllMembersStoredProcedure(Member member)
            {
                // Initial value
                FetchAllMembersStoredProcedure fetchAllMembersStoredProcedure = new FetchAllMembersStoredProcedure();

                // return value
                return fetchAllMembersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
