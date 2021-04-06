

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllTagsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Tags' objects.
    /// </summary>
    public class FetchAllTagsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllTagsStoredProcedure' object.
        /// </summary>
        public FetchAllTagsStoredProcedure()
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
                this.ProcedureName = "Tags_FetchAll";

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
