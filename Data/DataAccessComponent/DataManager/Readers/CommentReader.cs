

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class CommentReader
    /// <summary>
    /// This class loads a single 'Comment' object or a list of type <Comment>.
    /// </summary>
    public class CommentReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Comment' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Comment' DataObject.</returns>
            public static Comment Load(DataRow dataRow)
            {
                // Initial Value
                Comment comment = new Comment();

                // Create field Integers
                int dislikesfield = 0;
                int idfield = 1;
                int likesfield = 2;
                int lovesfield = 3;
                int memberIdfield = 4;
                int removedfield = 5;
                int replyToCommentIdfield = 6;
                int textfield = 7;
                int timestampfield = 8;
                int videoIdfield = 9;

                try
                {
                    // Load Each field
                    comment.Dislikes = DataHelper.ParseInteger(dataRow.ItemArray[dislikesfield], 0);
                    comment.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    comment.Likes = DataHelper.ParseInteger(dataRow.ItemArray[likesfield], 0);
                    comment.Loves = DataHelper.ParseInteger(dataRow.ItemArray[lovesfield], 0);
                    comment.MemberId = DataHelper.ParseInteger(dataRow.ItemArray[memberIdfield], 0);
                    comment.Removed = DataHelper.ParseBoolean(dataRow.ItemArray[removedfield], false);
                    comment.ReplyToCommentId = DataHelper.ParseInteger(dataRow.ItemArray[replyToCommentIdfield], 0);
                    comment.Text = DataHelper.ParseString(dataRow.ItemArray[textfield]);
                    comment.Timestamp = DataHelper.ParseDate(dataRow.ItemArray[timestampfield]);
                    comment.VideoId = DataHelper.ParseInteger(dataRow.ItemArray[videoIdfield], 0);
                }
                catch
                {
                }

                // return value
                return comment;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Comment' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Comment Collection.</returns>
            public static List<Comment> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Comment> comments = new List<Comment>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Comment' from rows
                        Comment comment = Load(row);

                        // Add this object to collection
                        comments.Add(comment);
                    }
                }
                catch
                {
                }

                // return value
                return comments;
            }
            #endregion

        #endregion

    }
    #endregion

}
