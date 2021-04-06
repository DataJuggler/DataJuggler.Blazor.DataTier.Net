

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllCommentsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Comment' objects.
    /// </summary>
    public class FetchAllCommentsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllCommentsStoredProcedure' object.
        /// </summary>
        public FetchAllCommentsStoredProcedure()
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
                this.ProcedureName = "Comment_FetchAll";

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
