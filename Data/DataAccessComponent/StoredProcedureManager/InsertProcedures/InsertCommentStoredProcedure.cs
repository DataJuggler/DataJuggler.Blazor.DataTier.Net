

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertCommentStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Comment' object.
    /// </summary>
    public class InsertCommentStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertCommentStoredProcedure' object.
        /// </summary>
        public InsertCommentStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Comment_Insert";

                // Set tableName
                this.TableName = "Comment";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
