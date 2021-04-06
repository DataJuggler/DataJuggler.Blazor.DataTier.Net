
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

    #region class CommentWriter
    /// <summary>
    /// This class is used for converting a 'Comment' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CommentWriter : CommentWriterBase
    {

        #region Static Methods

            #region CreateFetchAllCommentsStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllCommentsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllCommentsStoredProcedure' object.</returns>
            public static new FetchAllCommentsStoredProcedure CreateFetchAllCommentsStoredProcedure(Comment comment)
            {
                // Initial value
                FetchAllCommentsStoredProcedure fetchAllCommentsStoredProcedure = new FetchAllCommentsStoredProcedure();

                // if the comment object exists
                if (comment != null)
                {
                    // if LoadByVideoId is true
                    if (comment.LoadByVideoId)
                    {
                        // Change the procedure name
                        fetchAllCommentsStoredProcedure.ProcedureName = "Comment_FetchAllForVideoId";
                        
                        // Create the @VideoId parameter
                        fetchAllCommentsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@VideoId", comment.VideoId);
                    }
                }
                
                // return value
                return fetchAllCommentsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
