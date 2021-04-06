

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindTagsStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Tags' object.
    /// </summary>
    public class FindTagsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindTagsStoredProcedure' object.
        /// </summary>
        public FindTagsStoredProcedure()
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
                this.ProcedureName = "Tags_Find";

                // Set tableName
                this.TableName = "Tags";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
