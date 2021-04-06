

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class VideoReader
    /// <summary>
    /// This class loads a single 'Video' object or a list of type <Video>.
    /// </summary>
    public class VideoReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Video' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Video' DataObject.</returns>
            public static Video Load(DataRow dataRow)
            {
                // Initial Value
                Video video = new Video();

                // Create field Integers
                int activefield = 0;
                int bannedfield = 1;
                int dateCreatedfield = 2;
                int dislikesfield = 3;
                int flaggedfield = 4;
                int idfield = 5;
                int likesfield = 6;
                int memberIdfield = 7;
                int namefield = 8;
                int videoUrlfield = 9;

                try
                {
                    // Load Each field
                    video.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    video.Banned = DataHelper.ParseBoolean(dataRow.ItemArray[bannedfield], false);
                    video.DateCreated = DataHelper.ParseDate(dataRow.ItemArray[dateCreatedfield]);
                    video.Dislikes = DataHelper.ParseInteger(dataRow.ItemArray[dislikesfield], 0);
                    video.Flagged = DataHelper.ParseInteger(dataRow.ItemArray[flaggedfield], 0);
                    video.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    video.Likes = DataHelper.ParseInteger(dataRow.ItemArray[likesfield], 0);
                    video.MemberId = DataHelper.ParseInteger(dataRow.ItemArray[memberIdfield], 0);
                    video.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    video.VideoUrl = DataHelper.ParseString(dataRow.ItemArray[videoUrlfield]);
                }
                catch
                {
                }

                // return value
                return video;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Video' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Video Collection.</returns>
            public static List<Video> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Video> videos = new List<Video>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Video' from rows
                        Video video = Load(row);

                        // Add this object to collection
                        videos.Add(video);
                    }
                }
                catch
                {
                }

                // return value
                return videos;
            }
            #endregion

        #endregion

    }
    #endregion

}
