

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

    #region class CommentManager
    /// <summary>
    /// This class is used to manage a 'Comment' object.
    /// </summary>
    public class CommentManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CommentManager' object.
        /// </summary>
        public CommentManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteComment()
            /// <summary>
            /// This method deletes a 'Comment' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteComment(DeleteCommentStoredProcedure deleteCommentProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteCommentProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllComments()
            /// <summary>
            /// This method fetches a  'List<Comment>' object.
            /// This method uses the 'Comments_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Comment>'</returns>
            /// </summary>
            public List<Comment> FetchAllComments(FetchAllCommentsStoredProcedure fetchAllCommentsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Comment> commentCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allCommentsDataSet = this.DataHelper.LoadDataSet(fetchAllCommentsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allCommentsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allCommentsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            commentCollection = CommentReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return commentCollection;
            }
            #endregion

            #region FindComment()
            /// <summary>
            /// This method finds a  'Comment' object.
            /// This method uses the 'Comment_Find' procedure.
            /// </summary>
            /// <returns>A 'Comment' object.</returns>
            /// </summary>
            public Comment FindComment(FindCommentStoredProcedure findCommentProc, DataConnector databaseConnector)
            {
                // Initial Value
                Comment comment = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet commentDataSet = this.DataHelper.LoadDataSet(findCommentProc, databaseConnector);

                    // Verify DataSet Exists
                    if(commentDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(commentDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Comment
                            comment = CommentReader.Load(row);
                        }
                    }
                }

                // return value
                return comment;
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

            #region InsertComment()
            /// <summary>
            /// This method inserts a 'Comment' object.
            /// This method uses the 'Comment_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertComment(InsertCommentStoredProcedure insertCommentProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertCommentProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateComment()
            /// <summary>
            /// This method updates a 'Comment'.
            /// This method uses the 'Comment_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateComment(UpdateCommentStoredProcedure updateCommentProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateCommentProc, databaseConnector);
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
