
#region using statements

using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Comment
    [Serializable]
    public partial class Comment
    {

        #region Private Variables
        private bool loadByVideoId;
        #endregion

        #region Constructor
        public Comment()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Comment Clone()
            {
                // Create New Object
                Comment newComment = (Comment) this.MemberwiseClone();

                // Return Cloned Object
                return newComment;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadByVideoId
            /// <summary>
            /// This property gets or sets the value for 'LoadByVideoId'.
            /// </summary>
            public bool LoadByVideoId
            {
                get { return loadByVideoId; }
                set { loadByVideoId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
