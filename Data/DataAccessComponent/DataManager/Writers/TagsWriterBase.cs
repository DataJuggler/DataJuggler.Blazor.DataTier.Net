

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

    #region class TagsWriterBase
    /// <summary>
    /// This class is used for converting a 'Tags' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class TagsWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Tags tags)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='tags'>The 'Tags' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Tags tags)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (tags != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", tags.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteTagsStoredProcedure(Tags tags)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteTags'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Tags_Delete'.
            /// </summary>
            /// <param name="tags">The 'Tags' to Delete.</param>
            /// <returns>An instance of a 'DeleteTagsStoredProcedure' object.</returns>
            public static DeleteTagsStoredProcedure CreateDeleteTagsStoredProcedure(Tags tags)
            {
                // Initial Value
                DeleteTagsStoredProcedure deleteTagsStoredProcedure = new DeleteTagsStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteTagsStoredProcedure.Parameters = CreatePrimaryKeyParameter(tags);

                // return value
                return deleteTagsStoredProcedure;
            }
            #endregion

            #region CreateFindTagsStoredProcedure(Tags tags)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindTagsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Tags_Find'.
            /// </summary>
            /// <param name="tags">The 'Tags' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindTagsStoredProcedure CreateFindTagsStoredProcedure(Tags tags)
            {
                // Initial Value
                FindTagsStoredProcedure findTagsStoredProcedure = null;

                // verify tags exists
                if(tags != null)
                {
                    // Instanciate findTagsStoredProcedure
                    findTagsStoredProcedure = new FindTagsStoredProcedure();

                    // Now create parameters for this procedure
                    findTagsStoredProcedure.Parameters = CreatePrimaryKeyParameter(tags);
                }

                // return value
                return findTagsStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Tags tags)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new tags.
            /// </summary>
            /// <param name="tags">The 'Tags' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Tags tags)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify tagsexists
                if(tags != null)
                {
                    // Create [Tag] parameter
                    param = new SqlParameter("@Tag", tags.Tag);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [VideoId] parameter
                    param = new SqlParameter("@VideoId", tags.VideoId);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertTagsStoredProcedure(Tags tags)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertTagsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Tags_Insert'.
            /// </summary>
            /// <param name="tags"The 'Tags' object to insert</param>
            /// <returns>An instance of a 'InsertTagsStoredProcedure' object.</returns>
            public static InsertTagsStoredProcedure CreateInsertTagsStoredProcedure(Tags tags)
            {
                // Initial Value
                InsertTagsStoredProcedure insertTagsStoredProcedure = null;

                // verify tags exists
                if(tags != null)
                {
                    // Instanciate insertTagsStoredProcedure
                    insertTagsStoredProcedure = new InsertTagsStoredProcedure();

                    // Now create parameters for this procedure
                    insertTagsStoredProcedure.Parameters = CreateInsertParameters(tags);
                }

                // return value
                return insertTagsStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Tags tags)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing tags.
            /// </summary>
            /// <param name="tags">The 'Tags' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Tags tags)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify tagsexists
                if(tags != null)
                {
                    // Create parameter for [Tag]
                    param = new SqlParameter("@Tag", tags.Tag);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [VideoId]
                    param = new SqlParameter("@VideoId", tags.VideoId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", tags.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateTagsStoredProcedure(Tags tags)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateTagsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Tags_Update'.
            /// </summary>
            /// <param name="tags"The 'Tags' object to update</param>
            /// <returns>An instance of a 'UpdateTagsStoredProcedure</returns>
            public static UpdateTagsStoredProcedure CreateUpdateTagsStoredProcedure(Tags tags)
            {
                // Initial Value
                UpdateTagsStoredProcedure updateTagsStoredProcedure = null;

                // verify tags exists
                if(tags != null)
                {
                    // Instanciate updateTagsStoredProcedure
                    updateTagsStoredProcedure = new UpdateTagsStoredProcedure();

                    // Now create parameters for this procedure
                    updateTagsStoredProcedure.Parameters = CreateUpdateParameters(tags);
                }

                // return value
                return updateTagsStoredProcedure;
            }
            #endregion

            #region CreateFetchAllTagsStoredProcedure(Tags tags)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllTagsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Tags_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllTagsStoredProcedure' object.</returns>
            public static FetchAllTagsStoredProcedure CreateFetchAllTagsStoredProcedure(Tags tags)
            {
                // Initial value
                FetchAllTagsStoredProcedure fetchAllTagsStoredProcedure = new FetchAllTagsStoredProcedure();

                // return value
                return fetchAllTagsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
