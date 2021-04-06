

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Video
    public partial class Video
    {

        #region Private Variables
        private bool active;
        private bool banned;
        private DateTime dateCreated;
        private int dislikes;
        private int flagged;
        private int id;
        private int likes;
        private int memberId;
        private string name;
        private string videoUrl;
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

            #region bool Active
            public bool Active
            {
                get
                {
                    return active;
                }
                set
                {
                    active = value;
                }
            }
            #endregion

            #region bool Banned
            public bool Banned
            {
                get
                {
                    return banned;
                }
                set
                {
                    banned = value;
                }
            }
            #endregion

            #region DateTime DateCreated
            public DateTime DateCreated
            {
                get
                {
                    return dateCreated;
                }
                set
                {
                    dateCreated = value;
                }
            }
            #endregion

            #region int Dislikes
            public int Dislikes
            {
                get
                {
                    return dislikes;
                }
                set
                {
                    dislikes = value;
                }
            }
            #endregion

            #region int Flagged
            public int Flagged
            {
                get
                {
                    return flagged;
                }
                set
                {
                    flagged = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region int Likes
            public int Likes
            {
                get
                {
                    return likes;
                }
                set
                {
                    likes = value;
                }
            }
            #endregion

            #region int MemberId
            public int MemberId
            {
                get
                {
                    return memberId;
                }
                set
                {
                    memberId = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region string VideoUrl
            public string VideoUrl
            {
                get
                {
                    return videoUrl;
                }
                set
                {
                    videoUrl = value;
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
