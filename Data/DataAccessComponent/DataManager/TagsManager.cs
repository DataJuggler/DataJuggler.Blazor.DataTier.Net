

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

    #region class TagsManager
    /// <summary>
    /// This class is used to manage a 'Tags' object.
    /// </summary>
    public class TagsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'TagsManager' object.
        /// </summary>
        public TagsManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteTags()
            /// <summary>
            /// This method deletes a 'Tags' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteTags(DeleteTagsStoredProcedure deleteTagsProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteTagsProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllTags()
            /// <summary>
            /// This method fetches a  'List<Tags>' object.
            /// This method uses the 'Tags_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Tags>'</returns>
            /// </summary>
            public List<Tags> FetchAllTags(FetchAllTagsStoredProcedure fetchAllTagsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Tags> tagsCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allTagsDataSet = this.DataHelper.LoadDataSet(fetchAllTagsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allTagsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allTagsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            tagsCollection = TagsReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return tagsCollection;
            }
            #endregion

            #region FindTags()
            /// <summary>
            /// This method finds a  'Tags' object.
            /// This method uses the 'Tags_Find' procedure.
            /// </summary>
            /// <returns>A 'Tags' object.</returns>
            /// </summary>
            public Tags FindTags(FindTagsStoredProcedure findTagsProc, DataConnector databaseConnector)
            {
                // Initial Value
                Tags tags = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet tagsDataSet = this.DataHelper.LoadDataSet(findTagsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(tagsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(tagsDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Tags
                            tags = TagsReader.Load(row);
                        }
                    }
                }

                // return value
                return tags;
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

            #region InsertTags()
            /// <summary>
            /// This method inserts a 'Tags' object.
            /// This method uses the 'Tags_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertTags(InsertTagsStoredProcedure insertTagsProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertTagsProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateTags()
            /// <summary>
            /// This method updates a 'Tags'.
            /// This method uses the 'Tags_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateTags(UpdateTagsStoredProcedure updateTagsProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateTagsProc, databaseConnector);
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
