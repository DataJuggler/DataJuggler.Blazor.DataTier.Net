

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteCommentStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Comment' object.
    /// </summary>
    public class DeleteCommentStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteCommentStoredProcedure' object.
        /// </summary>
        public DeleteCommentStoredProcedure()
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
                this.ProcedureName = "Comment_Delete";

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
