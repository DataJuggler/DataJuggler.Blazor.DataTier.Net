

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

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private string connectionName;
        private CommentManager commentManager;
        private MemberManager memberManager;
        private TagsManager tagsManager;
        private VideoManager videoManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.CommentManager = new CommentManager(this);
                this.MemberManager = new MemberManager(this);
                this.TagsManager = new TagsManager(this);
                this.VideoManager = new VideoManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region CommentManager
            public CommentManager CommentManager
            {
                get { return commentManager; }
                set { commentManager = value; }
            }
            #endregion

            #region MemberManager
            public MemberManager MemberManager
            {
                get { return memberManager; }
                set { memberManager = value; }
            }
            #endregion

            #region TagsManager
            public TagsManager TagsManager
            {
                get { return tagsManager; }
                set { tagsManager = value; }
            }
            #endregion

            #region VideoManager
            public VideoManager VideoManager
            {
                get { return videoManager; }
                set { videoManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
