

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Comment
    public partial class Comment
    {

        #region Private Variables
        private int dislikes;
        private int id;
        private int likes;
        private int loves;
        private int memberId;
        private bool removed;
        private int replyToCommentId;
        private string text;
        private DateTime timestamp;
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

            #region int Loves
            public int Loves
            {
                get
                {
                    return loves;
                }
                set
                {
                    loves = value;
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

            #region bool Removed
            public bool Removed
            {
                get
                {
                    return removed;
                }
                set
                {
                    removed = value;
                }
            }
            #endregion

            #region int ReplyToCommentId
            public int ReplyToCommentId
            {
                get
                {
                    return replyToCommentId;
                }
                set
                {
                    replyToCommentId = value;
                }
            }
            #endregion

            #region string Text
            public string Text
            {
                get
                {
                    return text;
                }
                set
                {
                    text = value;
                }
            }
            #endregion

            #region DateTime Timestamp
            public DateTime Timestamp
            {
                get
                {
                    return timestamp;
                }
                set
                {
                    timestamp = value;
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
