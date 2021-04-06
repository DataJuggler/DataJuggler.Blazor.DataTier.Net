

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllVideosStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Video' objects.
    /// </summary>
    public class FetchAllVideosStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllVideosStoredProcedure' object.
        /// </summary>
        public FetchAllVideosStoredProcedure()
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
                this.ProcedureName = "Video_FetchAll";

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
