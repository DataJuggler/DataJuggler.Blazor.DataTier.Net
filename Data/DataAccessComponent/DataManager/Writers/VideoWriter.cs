
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

    #region class VideoWriter
    /// <summary>
    /// This class is used for converting a 'Video' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class VideoWriter : VideoWriterBase
    {

        #region Static Methods

            #region CreateFetchAllVideosStoredProcedure(Video video)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllVideosStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Video_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllVideosStoredProcedure' object.</returns>
            public static new FetchAllVideosStoredProcedure CreateFetchAllVideosStoredProcedure(Video video)
            {
                // Initial value
                FetchAllVideosStoredProcedure fetchAllVideosStoredProcedure = new FetchAllVideosStoredProcedure();

                // if the video object exists
                if (video != null)
                {
                    // if LoadByMemberId is true
                    if (video.LoadByMemberId)
                    {
                        // Change the procedure name
                        fetchAllVideosStoredProcedure.ProcedureName = "Video_FetchAllForMemberId";
                        
                        // Create the @MemberId parameter
                        fetchAllVideosStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@MemberId", video.MemberId);
                    }
                }
                
                // return value
                return fetchAllVideosStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
