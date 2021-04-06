

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateTagsStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Tags' object.
    /// </summary>
    public class UpdateTagsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateTagsStoredProcedure' object.
        /// </summary>
        public UpdateTagsStoredProcedure()
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
                this.ProcedureName = "Tags_Update";

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
