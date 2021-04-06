

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class VideoManager
    /// <summary>
    /// This class is used to manage a 'Video' object.
    /// </summary>
    public class VideoManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'VideoManager' object.
        /// </summary>
        public VideoManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteVideo()
            /// <summary>
            /// This method deletes a 'Video' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteVideo(DeleteVideoStoredProcedure deleteVideoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteVideoProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllVideos()
            /// <summary>
            /// This method fetches a  'List<Video>' object.
            /// This method uses the 'Videos_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Video>'</returns>
            /// </summary>
            public List<Video> FetchAllVideos(FetchAllVideosStoredProcedure fetchAllVideosProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Video> videoCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allVideosDataSet = this.DataHelper.LoadDataSet(fetchAllVideosProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allVideosDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allVideosDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            videoCollection = VideoReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return videoCollection;
            }
            #endregion

            #region FindVideo()
            /// <summary>
            /// This method finds a  'Video' object.
            /// This method uses the 'Video_Find' procedure.
            /// </summary>
            /// <returns>A 'Video' object.</returns>
            /// </summary>
            public Video FindVideo(FindVideoStoredProcedure findVideoProc, DataConnector databaseConnector)
            {
                // Initial Value
                Video video = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet videoDataSet = this.DataHelper.LoadDataSet(findVideoProc, databaseConnector);

                    // Verify DataSet Exists
                    if(videoDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(videoDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Video
                            video = VideoReader.Load(row);
                        }
                    }
                }

                // return value
                return video;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertVideo()
            /// <summary>
            /// This method inserts a 'Video' object.
            /// This method uses the 'Video_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertVideo(InsertVideoStoredProcedure insertVideoProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertVideoProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateVideo()
            /// <summary>
            /// This method updates a 'Video'.
            /// This method uses the 'Video_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateVideo(UpdateVideoStoredProcedure updateVideoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateVideoProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
