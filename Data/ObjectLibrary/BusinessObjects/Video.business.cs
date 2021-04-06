
#region using statements

using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Video
    [Serializable]
    public partial class Video
    {

        #region Private Variables
        private bool loadByMemberId;
        #endregion

        #region Constructor
        public Video()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Video Clone()
            {
                // Create New Object
                Video newVideo = (Video) this.MemberwiseClone();

                // Return Cloned Object
                return newVideo;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadByMemberId
            /// <summary>
            /// This property gets or sets the value for 'LoadByMemberId'.
            /// </summary>
            public bool LoadByMemberId
            {
                get { return loadByMemberId; }
                set { loadByMemberId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
