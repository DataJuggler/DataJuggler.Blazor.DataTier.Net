

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertVideoStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Video' object.
    /// </summary>
    public class InsertVideoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertVideoStoredProcedure' object.
        /// </summary>
        public InsertVideoStoredProcedure()
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
                this.ProcedureName = "Video_Insert";

                // Set tableName
                this.TableName = "Video";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
