

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateCommentStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Comment' object.
    /// </summary>
    public class UpdateCommentStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateCommentStoredProcedure' object.
        /// </summary>
        public UpdateCommentStoredProcedure()
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
                this.ProcedureName = "Comment_Update";

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
