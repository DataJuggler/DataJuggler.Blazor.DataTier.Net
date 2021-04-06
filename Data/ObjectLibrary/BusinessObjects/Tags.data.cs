

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Tags
    public partial class Tags
    {

        #region Private Variables
        private int id;
        private string tag;
        private int videoId;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region string Tag
            public string Tag
            {
                get
                {
                    return tag;
                }
                set
                {
                    tag = value;
                }
            }
            #endregion

            #region int VideoId
            public int VideoId
            {
                get
                {
                    return videoId;
                }
                set
                {
                    videoId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
