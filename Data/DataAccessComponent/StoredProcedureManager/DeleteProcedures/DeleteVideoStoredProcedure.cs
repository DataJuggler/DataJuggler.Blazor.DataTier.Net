

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteVideoStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Video' object.
    /// </summary>
    public class DeleteVideoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteVideoStoredProcedure' object.
        /// </summary>
        public DeleteVideoStoredProcedure()
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
                this.ProcedureName = "Video_Delete";

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
