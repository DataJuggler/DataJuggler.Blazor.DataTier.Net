

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindVideoStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Video' object.
    /// </summary>
    public class FindVideoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindVideoStoredProcedure' object.
        /// </summary>
        public FindVideoStoredProcedure()
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
                this.ProcedureName = "Video_Find";

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
