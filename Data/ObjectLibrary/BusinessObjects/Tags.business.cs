

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Tags
    [Serializable]
    public partial class Tags
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Tags()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Tags Clone()
            {
                // Create New Object
                Tags newTags = (Tags) this.MemberwiseClone();

                // Return Cloned Object
                return newTags;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
