

#region using statements

using ApplicationLogicComponent.Connection;
using DataJuggler.UltimateHelper;
using DataGateway;
using System;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace DataGateway.Services
{

    #region class MemberService
    /// <summary>
    /// This is the Service class for managing Member objects.
    /// </summary>
    public class MemberService
    {

        #region Methods

            #region FindMember(int id)
            /// <summary>
            /// This method is used to find a Member object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<Member> FindMember(int id)
            {
                // initial value
                Member member = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the member
                    member = gateway.FindMember(id);
                }
                
                // return value
                return Task.FromResult(member);
            }
            #endregion

            #region FindMemberByEmailAddress(string emailAddress)
            /// <summary>
            /// This method is used to find a member by EmailAddress to see if it is unique or not.
            /// </summary>
            /// <returns></returns>
            public static Task<Member> FindMemberByEmailAddress(string emailAddress)
            {
                // initial value
                Member member = null;
                
                // If the emailAddress string exists
                if (TextHelper.Exists(emailAddress))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    member = gateway.FindMemberByEmailAddress(emailAddress);
                }
                
                // return the value of deleted
                return Task.FromResult(member);
            }
            #endregion
            
            #region FindMemberByUserName(string userName)
            /// <summary>
            /// This method is used to find a member by UserName to see if it is unique or not.
            /// </summary>
            /// <returns></returns>
            public static Task<Member> FindMemberByUserName(string userName)
            {
                // initial value
                Member member = null;
                
                // If the userName string exists
                if (TextHelper.Exists(userName))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    member = gateway.FindMemberByUserName(userName);
                }
                
                // return the value of deleted
                return Task.FromResult(member);
            }
        #endregion
            
            #region GetMemberList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Member>> GetMemberList()
            {
                // initial value
                List<Member> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadMembers();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveMember(Member member)
            /// <summary>
            /// This method is used to delete a Member
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveMember(Member member)
            {
                // initial value
                bool deleted = false;
                
                // if the member object exists
                if (NullHelper.Exists(member))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteMember(member.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveMember(ref Member member)
            /// <summary>
            /// This method is used to create Member objects
            /// </summary>
            /// <param name="member">Pass in an object of type Member to save</param>
            /// <returns></returns>
            public static Task<bool> SaveMember(ref Member member)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveMember(ref member);

                // for debugging only
                if (!saved)
                {
                    // get the last exception
                    Exception exception = gateway.GetLastException();

                    // if the exception exists
                    if (NullHelper.Exists(exception))
                    {
                        // get the message
                        string message = exception.Message;
                    }
                }
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
