

#region using statements

using System;
using DataJuggler.Net5.Delegates;
using DataJuggler.Net5.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Member
    public partial class Member
    {

        #region Private Variables
        private bool active;
        private double adSpend;
        private string channelName;
        private string channelUrl;
        private DateTime createdDate;
        private string description;
        private double donations;
        private string emailAddress;
        private bool emailVerified;
        private string firstName;
        private int id;
        private bool isAdmin;
        private DateTime lastLoginDate;
        private string lastName;
        private string link1;
        private string link2;
        private string link3;
        private string location;
        private string passwordHash;
        private bool premium;
        private DateTime premiumExpires;
        private string profilePicture;
        private bool publicEmail;
        private int totalLogins;
        private string userName;
        private ItemChangedCallback callback;
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
                    // local
                    bool hasChanges = (Active != value);

                    // Set the value
                    active = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region double AdSpend
            public double AdSpend
            {
                get
                {
                    return adSpend;
                }
                set
                {
                    // local
                    bool hasChanges = (AdSpend != value);

                    // Set the value
                    adSpend = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string ChannelName
            public string ChannelName
            {
                get
                {
                    return channelName;
                }
                set
                {
                    // local
                    bool hasChanges = (ChannelName != value);

                    // Set the value
                    channelName = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string ChannelUrl
            public string ChannelUrl
            {
                get
                {
                    return channelUrl;
                }
                set
                {
                    // local
                    bool hasChanges = (ChannelUrl != value);

                    // Set the value
                    channelUrl = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region DateTime CreatedDate
            public DateTime CreatedDate
            {
                get
                {
                    return createdDate;
                }
                set
                {
                    // local
                    bool hasChanges = (CreatedDate != value);

                    // Set the value
                    createdDate = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Description
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    // local
                    bool hasChanges = (Description != value);

                    // Set the value
                    description = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region double Donations
            public double Donations
            {
                get
                {
                    return donations;
                }
                set
                {
                    // local
                    bool hasChanges = (Donations != value);

                    // Set the value
                    donations = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string EmailAddress
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    // local
                    bool hasChanges = (EmailAddress != value);

                    // Set the value
                    emailAddress = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region bool EmailVerified
            public bool EmailVerified
            {
                get
                {
                    return emailVerified;
                }
                set
                {
                    // local
                    bool hasChanges = (EmailVerified != value);

                    // Set the value
                    emailVerified = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string FirstName
            public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    // local
                    bool hasChanges = (FirstName != value);

                    // Set the value
                    firstName = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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

            #region bool IsAdmin
            public bool IsAdmin
            {
                get
                {
                    return isAdmin;
                }
                set
                {
                    // local
                    bool hasChanges = (IsAdmin != value);

                    // Set the value
                    isAdmin = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region DateTime LastLoginDate
            public DateTime LastLoginDate
            {
                get
                {
                    return lastLoginDate;
                }
                set
                {
                    // local
                    bool hasChanges = (LastLoginDate != value);

                    // Set the value
                    lastLoginDate = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string LastName
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    // local
                    bool hasChanges = (LastName != value);

                    // Set the value
                    lastName = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Link1
            public string Link1
            {
                get
                {
                    return link1;
                }
                set
                {
                    // local
                    bool hasChanges = (Link1 != value);

                    // Set the value
                    link1 = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Link2
            public string Link2
            {
                get
                {
                    return link2;
                }
                set
                {
                    // local
                    bool hasChanges = (Link2 != value);

                    // Set the value
                    link2 = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Link3
            public string Link3
            {
                get
                {
                    return link3;
                }
                set
                {
                    // local
                    bool hasChanges = (Link3 != value);

                    // Set the value
                    link3 = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Location
            public string Location
            {
                get
                {
                    return location;
                }
                set
                {
                    // local
                    bool hasChanges = (Location != value);

                    // Set the value
                    location = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string PasswordHash
            public string PasswordHash
            {
                get
                {
                    return passwordHash;
                }
                set
                {
                    // local
                    bool hasChanges = (PasswordHash != value);

                    // Set the value
                    passwordHash = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region bool Premium
            public bool Premium
            {
                get
                {
                    return premium;
                }
                set
                {
                    // local
                    bool hasChanges = (Premium != value);

                    // Set the value
                    premium = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region DateTime PremiumExpires
            public DateTime PremiumExpires
            {
                get
                {
                    return premiumExpires;
                }
                set
                {
                    // local
                    bool hasChanges = (PremiumExpires != value);

                    // Set the value
                    premiumExpires = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string ProfilePicture
            public string ProfilePicture
            {
                get
                {
                    return profilePicture;
                }
                set
                {
                    // local
                    bool hasChanges = (ProfilePicture != value);

                    // Set the value
                    profilePicture = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region bool PublicEmail
            public bool PublicEmail
            {
                get
                {
                    return publicEmail;
                }
                set
                {
                    // local
                    bool hasChanges = (PublicEmail != value);

                    // Set the value
                    publicEmail = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region int TotalLogins
            public int TotalLogins
            {
                get
                {
                    return totalLogins;
                }
                set
                {
                    // local
                    bool hasChanges = (TotalLogins != value);

                    // Set the value
                    totalLogins = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string UserName
            public string UserName
            {
                get
                {
                    return userName;
                }
                set
                {
                    // local
                    bool hasChanges = (UserName != value);

                    // Set the value
                    userName = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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

            #region ItemChangedCallback Callback
            public ItemChangedCallback Callback
            {
                get
                {
                    return callback;
                }
                set
                {
                    callback = value;
                }
            }
            #endregion

            #region bool HasCallback
            public bool HasCallback
            {
                get
                {
                    // Initial Value
                    bool hasCallback = (this.Callback != null);

                    // return value
                    return hasCallback;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
