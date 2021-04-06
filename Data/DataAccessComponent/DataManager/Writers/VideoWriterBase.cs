

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

    #region class VideoWriterBase
    /// <summary>
    /// This class is used for converting a 'Video' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class VideoWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Video video)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='video'>The 'Video' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Video video)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (video != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", video.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteVideoStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteVideo'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_Delete'.
            /// </summary>
            /// <param name="video">The 'Video' to Delete.</param>
            /// <returns>An instance of a 'DeleteVideoStoredProcedure' object.</returns>
            public static DeleteVideoStoredProcedure CreateDeleteVideoStoredProcedure(Video video)
            {
                // Initial Value
                DeleteVideoStoredProcedure deleteVideoStoredProcedure = new DeleteVideoStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteVideoStoredProcedure.Parameters = CreatePrimaryKeyParameter(video);

                // return value
                return deleteVideoStoredProcedure;
            }
            #endregion

            #region CreateFindVideoStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindVideoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_Find'.
            /// </summary>
            /// <param name="video">The 'Video' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindVideoStoredProcedure CreateFindVideoStoredProcedure(Video video)
            {
                // Initial Value
                FindVideoStoredProcedure findVideoStoredProcedure = null;

                // verify video exists
                if(video != null)
                {
                    // Instanciate findVideoStoredProcedure
                    findVideoStoredProcedure = new FindVideoStoredProcedure();

                    // Now create parameters for this procedure
                    findVideoStoredProcedure.Parameters = CreatePrimaryKeyParameter(video);
                }

                // return value
                return findVideoStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Video video)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new video.
            /// </summary>
            /// <param name="video">The 'Video' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Video video)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify videoexists
                if(video != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", video.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Banned] parameter
                    param = new SqlParameter("@Banned", video.Banned);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DateCreated] Parameter
                    param = new SqlParameter("@DateCreated", SqlDbType.DateTime);

                    // If video.DateCreated does not exist.
                    if (video.DateCreated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = video.DateCreated;
                    }
                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Dislikes] parameter
                    param = new SqlParameter("@Dislikes", video.Dislikes);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Flagged] parameter
                    param = new SqlParameter("@Flagged", video.Flagged);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Likes] parameter
                    param = new SqlParameter("@Likes", video.Likes);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [MemberId] parameter
                    param = new SqlParameter("@MemberId", video.MemberId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", video.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [VideoUrl] parameter
                    param = new SqlParameter("@VideoUrl", video.VideoUrl);

                    // set parameters[8]
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertVideoStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertVideoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_Insert'.
            /// </summary>
            /// <param name="video"The 'Video' object to insert</param>
            /// <returns>An instance of a 'InsertVideoStoredProcedure' object.</returns>
            public static InsertVideoStoredProcedure CreateInsertVideoStoredProcedure(Video video)
            {
                // Initial Value
                InsertVideoStoredProcedure insertVideoStoredProcedure = null;

                // verify video exists
                if(video != null)
                {
                    // Instanciate insertVideoStoredProcedure
                    insertVideoStoredProcedure = new InsertVideoStoredProcedure();

                    // Now create parameters for this procedure
                    insertVideoStoredProcedure.Parameters = CreateInsertParameters(video);
                }

                // return value
                return insertVideoStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Video video)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing video.
            /// </summary>
            /// <param name="video">The 'Video' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Video video)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[10];
                SqlParameter param = null;

                // verify videoexists
                if(video != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", video.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Banned]
                    param = new SqlParameter("@Banned", video.Banned);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DateCreated]
                    // Create [DateCreated] Parameter
                    param = new SqlParameter("@DateCreated", SqlDbType.DateTime);

                    // If video.DateCreated does not exist.
                    if (video.DateCreated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = video.DateCreated;
                    }

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Dislikes]
                    param = new SqlParameter("@Dislikes", video.Dislikes);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Flagged]
                    param = new SqlParameter("@Flagged", video.Flagged);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Likes]
                    param = new SqlParameter("@Likes", video.Likes);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [MemberId]
                    param = new SqlParameter("@MemberId", video.MemberId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", video.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [VideoUrl]
                    param = new SqlParameter("@VideoUrl", video.VideoUrl);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", video.Id);
                    parameters[9] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateVideoStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateVideoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_Update'.
            /// </summary>
            /// <param name="video"The 'Video' object to update</param>
            /// <returns>An instance of a 'UpdateVideoStoredProcedure</returns>
            public static UpdateVideoStoredProcedure CreateUpdateVideoStoredProcedure(Video video)
            {
                // Initial Value
                UpdateVideoStoredProcedure updateVideoStoredProcedure = null;

                // verify video exists
                if(video != null)
                {
                    // Instanciate updateVideoStoredProcedure
                    updateVideoStoredProcedure = new UpdateVideoStoredProcedure();

                    // Now create parameters for this procedure
                    updateVideoStoredProcedure.Parameters = CreateUpdateParameters(video);
                }

                // return value
                return updateVideoStoredProcedure;
            }
            #endregion

            #region CreateFetchAllVideosStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllVideosStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllVideosStoredProcedure' object.</returns>
            public static FetchAllVideosStoredProcedure CreateFetchAllVideosStoredProcedure(Video video)
            {
                // Initial value
                FetchAllVideosStoredProcedure fetchAllVideosStoredProcedure = new FetchAllVideosStoredProcedure();

                // return value
                return fetchAllVideosStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
