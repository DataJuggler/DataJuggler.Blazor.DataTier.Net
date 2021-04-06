
#region using statements

using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Member
    [Serializable]
    public partial class Member
    {

        #region Private Variables
        private bool findByEmailAddress;
        private bool findByUserName;
        #endregion

        #region Constructor
        public Member()
        {
            this.IsAdmin = false;
            this.Active = true;
            this.AdSpend = 0;
            this.Donations = 0;
            this.Premium = false;
        }
        #endregion

        #region Methods

            #region Clone()
            public Member Clone()
            {
                // Create New Object
                Member newMember = (Member) this.MemberwiseClone();

                // Return Cloned Object
                return newMember;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByEmailAddress
            /// <summary>
            /// This property gets or sets the value for 'FindByEmailAddress'.
            /// </summary>
            public bool FindByEmailAddress
            {
                get { return findByEmailAddress; }
                set { findByEmailAddress = value; }
            }
            #endregion

            #region FindByUserName
            /// <summary>
            /// This property gets or sets the value for 'FindByUserName'.
            /// </summary>
            public bool FindByUserName
            {
                get { return findByUserName; }
                set { findByUserName = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
