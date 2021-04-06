

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindCommentStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Comment' object.
    /// </summary>
    public class FindCommentStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindCommentStoredProcedure' object.
        /// </summary>
        public FindCommentStoredProcedure()
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
                this.ProcedureName = "Comment_Find";

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
