

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertTagsStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Tags' object.
    /// </summary>
    public class InsertTagsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertTagsStoredProcedure' object.
        /// </summary>
        public InsertTagsStoredProcedure()
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
                this.ProcedureName = "Tags_Insert";

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
