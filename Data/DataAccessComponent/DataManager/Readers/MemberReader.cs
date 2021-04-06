

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class MemberReader
    /// <summary>
    /// This class loads a single 'Member' object or a list of type <Member>.
    /// </summary>
    public class MemberReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Member' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Member' DataObject.</returns>
            public static Member Load(DataRow dataRow)
            {
                // Initial Value
                Member member = new Member();

                // Create field Integers
                int activefield = 0;
                int adSpendfield = 1;
                int channelNamefield = 2;
                int channelUrlfield = 3;
                int createdDatefield = 4;
                int descriptionfield = 5;
                int donationsfield = 6;
                int emailAddressfield = 7;
                int emailVerifiedfield = 8;
                int firstNamefield = 9;
                int idfield = 10;
                int isAdminfield = 11;
                int lastLoginDatefield = 12;
                int lastNamefield = 13;
                int link1field = 14;
                int link2field = 15;
                int link3field = 16;
                int locationfield = 17;
                int passwordHashfield = 18;
                int premiumfield = 19;
                int premiumExpiresfield = 20;
                int profilePicturefield = 21;
                int publicEmailfield = 22;
                int totalLoginsfield = 23;
                int userNamefield = 24;

                try
                {
                    // Load Each field
                    member.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    member.AdSpend = DataHelper.ParseDouble(dataRow.ItemArray[adSpendfield], 0);
                    member.ChannelName = DataHelper.ParseString(dataRow.ItemArray[channelNamefield]);
                    member.ChannelUrl = DataHelper.ParseString(dataRow.ItemArray[channelUrlfield]);
                    member.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    member.Description = DataHelper.ParseString(dataRow.ItemArray[descriptionfield]);
                    member.Donations = DataHelper.ParseDouble(dataRow.ItemArray[donationsfield], 0);
                    member.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    member.EmailVerified = DataHelper.ParseBoolean(dataRow.ItemArray[emailVerifiedfield], false);
                    member.FirstName = DataHelper.ParseString(dataRow.ItemArray[firstNamefield]);
                    member.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    member.IsAdmin = DataHelper.ParseBoolean(dataRow.ItemArray[isAdminfield], false);
                    member.LastLoginDate = DataHelper.ParseDate(dataRow.ItemArray[lastLoginDatefield]);
                    member.LastName = DataHelper.ParseString(dataRow.ItemArray[lastNamefield]);
                    member.Link1 = DataHelper.ParseString(dataRow.ItemArray[link1field]);
                    member.Link2 = DataHelper.ParseString(dataRow.ItemArray[link2field]);
                    member.Link3 = DataHelper.ParseString(dataRow.ItemArray[link3field]);
                    member.Location = DataHelper.ParseString(dataRow.ItemArray[locationfield]);
                    member.PasswordHash = DataHelper.ParseString(dataRow.ItemArray[passwordHashfield]);
                    member.Premium = DataHelper.ParseBoolean(dataRow.ItemArray[premiumfield], false);
                    member.PremiumExpires = DataHelper.ParseDate(dataRow.ItemArray[premiumExpiresfield]);
                    member.ProfilePicture = DataHelper.ParseString(dataRow.ItemArray[profilePicturefield]);
                    member.PublicEmail = DataHelper.ParseBoolean(dataRow.ItemArray[publicEmailfield], false);
                    member.TotalLogins = DataHelper.ParseInteger(dataRow.ItemArray[totalLoginsfield], 0);
                    member.UserName = DataHelper.ParseString(dataRow.ItemArray[userNamefield]);
                }
                catch
                {
                }

                // return value
                return member;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Member' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Member Collection.</returns>
            public static List<Member> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Member> members = new List<Member>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Member' from rows
                        Member member = Load(row);

                        // Add this object to collection
                        members.Add(member);
                    }
                }
                catch
                {
                }

                // return value
                return members;
            }
            #endregion

        #endregion

    }
    #endregion

}
