

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private CommentMethods commentMethods;
        private MemberMethods memberMethods;
        private TagsMethods tagsMethods;
        private VideoMethods videoMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.CommentMethods = new CommentMethods(this.DataManager);
                this.MemberMethods = new MemberMethods(this.DataManager);
                this.TagsMethods = new TagsMethods(this.DataManager);
                this.VideoMethods = new VideoMethods(this.DataManager);
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager
            public DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region CommentMethods
            public CommentMethods CommentMethods
            {
                get { return commentMethods; }
                set { commentMethods = value; }
            }
            #endregion

            #region MemberMethods
            public MemberMethods MemberMethods
            {
                get { return memberMethods; }
                set { memberMethods = value; }
            }
            #endregion

            #region TagsMethods
            public TagsMethods TagsMethods
            {
                get { return tagsMethods; }
                set { tagsMethods = value; }
            }
            #endregion

            #region VideoMethods
            public VideoMethods VideoMethods
            {
                get { return videoMethods; }
                set { videoMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
