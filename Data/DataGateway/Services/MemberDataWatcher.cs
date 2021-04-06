
#region using statements

using DataJuggler.Net5.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class MemberDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// Member item, the delegate is notified so the values are saved.
    /// </summary>
    public class MemberDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                Member member = itemChanged as Member;

                // If the member object exists
                if (NullHelper.Exists(member))
                {
                    // perform the saved
                    bool saved = await MemberService.SaveMember(ref member);
                }
            }
            #endregion

            #region Watch(List<Member> member)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="members">The list of Member objects to set a delegate on.</param>
            public void Watch(List<Member> members)
            {
                // If the members collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(members))
                {
                    // Iterate the collection of Member objects
                    foreach (Member member in members)
                    {
                        // Setup the Callback for each item
                       member.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
