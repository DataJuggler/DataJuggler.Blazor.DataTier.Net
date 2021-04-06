
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

    #region class MemberWriter
    /// <summary>
    /// This class is used for converting a 'Member' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MemberWriter : MemberWriterBase
    {

        #region Static Methods

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
            public static new FindMemberStoredProcedure CreateFindMemberStoredProcedure(Member member)
            {
                // Initial Value
                FindMemberStoredProcedure findMemberStoredProcedure = null;

                // verify member exists
                if(member != null)
                {
                    // Instanciate findMemberStoredProcedure
                    findMemberStoredProcedure = new FindMemberStoredProcedure();

                    // if member.FindByEmailAddress is true
                    if (member.FindByEmailAddress)
                    {
                        // Change the procedure name
                        findMemberStoredProcedure.ProcedureName = "Member_FindByEmailAddress";
                        
                        // Create the @EmailAddress parameter
                        findMemberStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@EmailAddress", member.EmailAddress);
                    }
                    // if member.FindByUserName is true
                    else if (member.FindByUserName)
                    {
                        // Change the procedure name
                        findMemberStoredProcedure.ProcedureName = "Member_FindByUserName";
                        
                        // Create the @UserName parameter
                        findMemberStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserName", member.UserName);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findMemberStoredProcedure.Parameters = CreatePrimaryKeyParameter(member);
                    }
                }

                // return value
                return findMemberStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
