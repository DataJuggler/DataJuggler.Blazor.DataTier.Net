

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteTagsStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Tags' object.
    /// </summary>
    public class DeleteTagsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteTagsStoredProcedure' object.
        /// </summary>
        public DeleteTagsStoredProcedure()
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
                this.ProcedureName = "Tags_Delete";

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
