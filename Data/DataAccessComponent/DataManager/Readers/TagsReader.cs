

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class TagsReader
    /// <summary>
    /// This class loads a single 'Tags' object or a list of type <Tags>.
    /// </summary>
    public class TagsReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Tags' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Tags' DataObject.</returns>
            public static Tags Load(DataRow dataRow)
            {
                // Initial Value
                Tags tags = new Tags();

                // Create field Integers
                int idfield = 0;
                int tagfield = 1;
                int videoIdfield = 2;

                try
                {
                    // Load Each field
                    tags.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    tags.Tag = DataHelper.ParseString(dataRow.ItemArray[tagfield]);
                    tags.VideoId = DataHelper.ParseInteger(dataRow.ItemArray[videoIdfield], 0);
                }
                catch
                {
                }

                // return value
                return tags;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Tags' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Tags Collection.</returns>
            public static List<Tags> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Tags> tags = new List<Tags>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Tags' from rows
                        Tags tag = Load(row);

                        // Add this object to collection
                        tags.Add(tag);
                    }
                }
                catch
                {
                }

                // return value
                return tags;
            }
            #endregion

        #endregion

    }
    #endregion

}
