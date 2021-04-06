

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

    #region class CommentWriterBase
    /// <summary>
    /// This class is used for converting a 'Comment' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CommentWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Comment comment)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='comment'>The 'Comment' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Comment comment)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (comment != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", comment.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteCommentStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteComment'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_Delete'.
            /// </summary>
            /// <param name="comment">The 'Comment' to Delete.</param>
            /// <returns>An instance of a 'DeleteCommentStoredProcedure' object.</returns>
            public static DeleteCommentStoredProcedure CreateDeleteCommentStoredProcedure(Comment comment)
            {
                // Initial Value
                DeleteCommentStoredProcedure deleteCommentStoredProcedure = new DeleteCommentStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteCommentStoredProcedure.Parameters = CreatePrimaryKeyParameter(comment);

                // return value
                return deleteCommentStoredProcedure;
            }
            #endregion

            #region CreateFindCommentStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindCommentStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_Find'.
            /// </summary>
            /// <param name="comment">The 'Comment' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindCommentStoredProcedure CreateFindCommentStoredProcedure(Comment comment)
            {
                // Initial Value
                FindCommentStoredProcedure findCommentStoredProcedure = null;

                // verify comment exists
                if(comment != null)
                {
                    // Instanciate findCommentStoredProcedure
                    findCommentStoredProcedure = new FindCommentStoredProcedure();

                    // Now create parameters for this procedure
                    findCommentStoredProcedure.Parameters = CreatePrimaryKeyParameter(comment);
                }

                // return value
                return findCommentStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Comment comment)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new comment.
            /// </summary>
            /// <param name="comment">The 'Comment' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Comment comment)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify commentexists
                if(comment != null)
                {
                    // Create [Dislikes] parameter
                    param = new SqlParameter("@Dislikes", comment.Dislikes);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Likes] parameter
                    param = new SqlParameter("@Likes", comment.Likes);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Loves] parameter
                    param = new SqlParameter("@Loves", comment.Loves);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [MemberId] parameter
                    param = new SqlParameter("@MemberId", comment.MemberId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Removed] parameter
                    param = new SqlParameter("@Removed", comment.Removed);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [ReplyToCommentId] parameter
                    param = new SqlParameter("@ReplyToCommentId", comment.ReplyToCommentId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Text] parameter
                    param = new SqlParameter("@Text", comment.Text);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Timestamp] Parameter
                    param = new SqlParameter("@Timestamp", SqlDbType.DateTime);

                    // If comment.Timestamp does not exist.
                    if (comment.Timestamp.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = comment.Timestamp;
                    }
                    // set parameters[7]
                    parameters[7] = param;

                    // Create [VideoId] parameter
                    param = new SqlParameter("@VideoId", comment.VideoId);

                    // set parameters[8]
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertCommentStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertCommentStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_Insert'.
            /// </summary>
            /// <param name="comment"The 'Comment' object to insert</param>
            /// <returns>An instance of a 'InsertCommentStoredProcedure' object.</returns>
            public static InsertCommentStoredProcedure CreateInsertCommentStoredProcedure(Comment comment)
            {
                // Initial Value
                InsertCommentStoredProcedure insertCommentStoredProcedure = null;

                // verify comment exists
                if(comment != null)
                {
                    // Instanciate insertCommentStoredProcedure
                    insertCommentStoredProcedure = new InsertCommentStoredProcedure();

                    // Now create parameters for this procedure
                    insertCommentStoredProcedure.Parameters = CreateInsertParameters(comment);
                }

                // return value
                return insertCommentStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Comment comment)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing comment.
            /// </summary>
            /// <param name="comment">The 'Comment' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Comment comment)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[10];
                SqlParameter param = null;

                // verify commentexists
                if(comment != null)
                {
                    // Create parameter for [Dislikes]
                    param = new SqlParameter("@Dislikes", comment.Dislikes);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Likes]
                    param = new SqlParameter("@Likes", comment.Likes);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Loves]
                    param = new SqlParameter("@Loves", comment.Loves);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [MemberId]
                    param = new SqlParameter("@MemberId", comment.MemberId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Removed]
                    param = new SqlParameter("@Removed", comment.Removed);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [ReplyToCommentId]
                    param = new SqlParameter("@ReplyToCommentId", comment.ReplyToCommentId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Text]
                    param = new SqlParameter("@Text", comment.Text);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Timestamp]
                    // Create [Timestamp] Parameter
                    param = new SqlParameter("@Timestamp", SqlDbType.DateTime);

                    // If comment.Timestamp does not exist.
                    if (comment.Timestamp.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = comment.Timestamp;
                    }

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [VideoId]
                    param = new SqlParameter("@VideoId", comment.VideoId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", comment.Id);
                    parameters[9] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateCommentStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateCommentStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_Update'.
            /// </summary>
            /// <param name="comment"The 'Comment' object to update</param>
            /// <returns>An instance of a 'UpdateCommentStoredProcedure</returns>
            public static UpdateCommentStoredProcedure CreateUpdateCommentStoredProcedure(Comment comment)
            {
                // Initial Value
                UpdateCommentStoredProcedure updateCommentStoredProcedure = null;

                // verify comment exists
                if(comment != null)
                {
                    // Instanciate updateCommentStoredProcedure
                    updateCommentStoredProcedure = new UpdateCommentStoredProcedure();

                    // Now create parameters for this procedure
                    updateCommentStoredProcedure.Parameters = CreateUpdateParameters(comment);
                }

                // return value
                return updateCommentStoredProcedure;
            }
            #endregion

            #region CreateFetchAllCommentsStoredProcedure(Comment comment)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllCommentsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Comment_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllCommentsStoredProcedure' object.</returns>
            public static FetchAllCommentsStoredProcedure CreateFetchAllCommentsStoredProcedure(Comment comment)
            {
                // Initial value
                FetchAllCommentsStoredProcedure fetchAllCommentsStoredProcedure = new FetchAllCommentsStoredProcedure();

                // return value
                return fetchAllCommentsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
