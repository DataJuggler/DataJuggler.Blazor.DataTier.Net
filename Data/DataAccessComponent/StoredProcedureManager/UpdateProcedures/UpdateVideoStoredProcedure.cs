

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateVideoStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Video' object.
    /// </summary>
    public class UpdateVideoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateVideoStoredProcedure' object.
        /// </summary>
        public UpdateVideoStoredProcedure()
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
                this.ProcedureName = "Video_Update";

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
