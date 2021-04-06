

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataGateway;
using DataGateway.Services;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataJuggler.UltimateHelper;
using DataJuggler.Blazor.DataTier.Net.Components;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Net5.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#endregion

namespace DataJuggler.Blazor.DataTier.Net.Pages
{

    #region class Index
    /// <summary>
    /// This is the code behind for the Gateway
    /// </summary>
    public partial class Index : IBlazorComponentParent, IProgressSubscriber
    {
        
        #region Private Variables
        private Member loggedInMember;
        private ScreenTypeEnum screenType;
        private Login loginComponent;
        private string welcomeMessage;
        private string validationMessage;
        private Join signUpComponent;
        private bool showProgress;
        private ProgressBar progressBar;
        private List<IBlazorComponent> children;
        #endregion


        #region Events

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // if ther is not a logged in member
                if (!HasLoggedInMember)
                {
                    // locals
                    string emailAddress = "";
                    string storedPasswordHash = "";
                        
                    try
                    {
                        // get the values from local storage if present
                        var remember = await ProtectedLocalStore.GetAsync<bool>("RememberLogin");

                        // get the value for rememberLogin
                        bool rememberLogin = remember.Value;

                        // if rememberLogin is true
                        if (rememberLogin)
                        {
                            var email = await ProtectedLocalStore.GetAsync<string>("EmailAddress");
                            var hash =await ProtectedLocalStore.GetAsync<string>("PasswordHash");

                            // If the emailAddress string exists
                            if (TextHelper.Exists(email.Value, hash.Value))
                            {
                                // set the value for email
                                emailAddress = email.Value;

                                // get the storedPasswordHash
                                storedPasswordHash = hash.Value;

                                // Attempt to find this user
                                Member member = await MemberService.FindMemberByEmailAddress(emailAddress);

                                // If the member object exists
                                if (NullHelper.Exists(member))
                                {
                                    // get the key
                                    string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("DataJuggler.Blazor.DataTier.Net");

                                    // if the key was found
                                    if (TextHelper.Exists(key))
                                    {
                                        // can this artist be verified
                                        bool isVerified = CryptographyHelper.VerifyHash(storedPasswordHash, key, member.PasswordHash, true);

                                        // if the value for isVerified is true
                                        if (isVerified)
                                        {
                                            // Set the LoggedInuser
                                            LoggedInMember = member;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("OnAfterRenderAsync", "Login.cs", error);
                    }
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);

                // if the value for HasLoggedInMember is true
                if ((HasLoggedInMember) && (firstRender))
                {
                    // Refresh the UI
                    Refresh();
                }
            }
            #endregion

            #region LoginButton_Click()
            /// <summary>
            /// This method Login Button _ Click
            /// </summary>
            public void LoginButton_Click()
            {
                // Setup the Screen to Login
                ScreenType = ScreenTypeEnum.Login;
            }
            #endregion

            #region SignOutButton_Click()
            /// <summary>
            /// This method Sign Out Button _ Click
            /// </summary>
            public async void SignOutButton_Click()
            {
                // Log Out The User
                LoggedInMember = null;

                // Remove the items in Local Storage
                await RemovedLocalStoreItems();

                // update the UI
                Refresh();
            }
            #endregion
            
            #region SignUpButton_Click()
            /// <summary>
            /// This method Sign Up Button _ Click
            /// </summary>
            public void SignUpButton_Click()
            {
                // Setup the Screen
                ScreenType = ScreenTypeEnum.SignUp;
            }
            #endregion

        #endregion

        #region Methods

            #region IDisposable.Dispose()
            /// <summary>
            /// method I Disposable . Dispose
            /// </summary>
            void IDisposable.Dispose()
            {
                // destroy
                JSRuntime = null;
            }
            #endregion

            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // initial value
                IBlazorComponent child = null;

                // return value
                return child;
            }
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {  
                // if this is the Login component
                if (component is Login)
                {
                    // Store the LoginComponent
                    LoginComponent = component as Login;
                }
                else if (component is Join)
                {
                    // Store the compoent
                    SignUpComponent = component as Join;
                }
            }
            #endregion
            
            #region Register(ProgressBar progressBar)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(ProgressBar progressBar)
            {
                // store it
                this.ProgressBar = progressBar;
            }
            #endregion
            
            #region Refresh(string message)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Refresh(string message)
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // not implemented
            }
            #endregion
            
            #region LoadVideos()
            /// <summary>
            /// This method Load Videos
            /// </summary>
            public void LoadVideos()
            {
                Gateway gateway = new Gateway();

                // load the videos
                List<Video> videos = gateway.LoadVideos();
            }
        #endregion

            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion

            #region RemovedLocalStoreItems()
            /// <summary>
            /// This method Removed Local Store Items
            /// </summary>
            public async Task<bool> RemovedLocalStoreItems()
            {
                // initial value
                bool removed = false;

                try
                {
                    // if the ProtectedLocalStore exists
                    if (ProtectedLocalStore != null)
                    {
                        // delete doesn't seem to work, so I am setting to false
                        await ProtectedLocalStore.SetAsync("RememberLogin", false);

                        // Remove all items
                        await ProtectedLocalStore.DeleteAsync("RememberPassword");
                        await ProtectedLocalStore.DeleteAsync("EmailAddress");
                        await ProtectedLocalStore.DeleteAsync("PasswordHash");
                    }

                    // set to true
                    removed = true;
                }
                catch (Exception error)
                {   
                    // for debugging only
                    DebugHelper.WriteDebugError("RemoveLocalStoreItems", "Login.cs", error);
                }

                // return value
                return removed;
            }
            #endregion

            #region SetupScreen(ScreenTypeEnum screenType, string emailAddress = "")
            /// <summary>
            /// This method Setup Screen
            /// </summary>
            public void SetupScreen(ScreenTypeEnum screenType, string emailAddress = "")
            {
                // set the ScreenType
                ScreenType = screenType;

                if ((ScreenType == ScreenTypeEnum.Login) && (TextHelper.Exists(emailAddress)) && (HasLoginComponent))
                {
                    // Set the email address
                    LoginComponent.EmailAddress = emailAddress;
                }

                // Update the UI
                Refresh();
            }
            #endregion

            #region StoreLocalStoreItems(string emailAddress, string passwordHash)
            /// <summary>
            /// This method Store Local Store Items
            /// </summary>
            public async Task<bool> StoreLocalStoreItems(string emailAddress, string passwordHash)
            {
                // initial value
                bool saved = false;

                try
                {
                    
                    
                    // try saving
                    await ProtectedLocalStore.SetAsync("RememberLogin", true);
                    await ProtectedLocalStore.SetAsync("EmailAddress", emailAddress);
                    await ProtectedLocalStore.SetAsync("PasswordHash", passwordHash);

                    // presumption
                    saved = true;
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("StoreLocalStoreItems", "Index.razor.cs", error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasLoggedInMember
            /// <summary>
            /// This property returns true if this object has a 'LoggedInMember'.
            /// </summary>
            public bool HasLoggedInMember
            {
                get
                {
                    // initial value
                    bool hasLoggedInMember = (this.LoggedInMember != null);
                    
                    // return value
                    return hasLoggedInMember;
                }
            }
            #endregion
            
            #region HasLoginComponent
            /// <summary>
            /// This property returns true if this object has a 'LoginComponent'.
            /// </summary>
            public bool HasLoginComponent
            {
                get
                {
                    // initial value
                    bool hasLoginComponent = (this.LoginComponent != null);
                    
                    // return value
                    return hasLoginComponent;
                }
            }
            #endregion
            
            #region LoggedInMember
            /// <summary>
            /// This property gets or sets the value for 'LoggedInMember'.
            /// </summary>
            public Member LoggedInMember
            {
                get { return loggedInMember; }
                set { loggedInMember = value; }
            }
            #endregion
            
            #region LoginComponent
            /// <summary>
            /// This property gets or sets the value for 'LoginComponent'.
            /// </summary>
            public Login LoginComponent
            {
                get { return loginComponent; }
                set { loginComponent = value; }
            }
            #endregion
            
            #region ProgressBar
            /// <summary>
            /// This property gets or sets the value for 'ProgressBar'.
            /// </summary>
            public ProgressBar ProgressBar
            {
                get { return progressBar; }
                set { progressBar = value; }
            }
            #endregion
            
            #region ScreenType
            /// <summary>
            /// This property gets or sets the value for 'ScreenType'.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                get { return screenType; }
                set { screenType = value; }
            }
            #endregion
            
            #region ShowProgress
            /// <summary>
            /// This property gets or sets the value for 'ShowProgress'.
            /// </summary>
            public bool ShowProgress
            {
                get { return showProgress; }
                set { showProgress = value; }
            }
            #endregion
            
            #region SignUpComponent
            /// <summary>
            /// This property gets or sets the value for 'SignUpComponent'.
            /// </summary>
            public Join SignUpComponent
            {
                get { return signUpComponent; }
                set { signUpComponent = value; }
            }
            #endregion
            
            #region ValidationMessage
            /// <summary>
            /// This property gets or sets the value for 'ValidationMessage'.
            /// </summary>
            public string ValidationMessage
            {
                get { return validationMessage; }
                set { validationMessage = value; }
            }
            #endregion
            
            #region WelcomeMessage
            /// <summary>
            /// This property gets or sets the value for 'WelcomeMessage'.
            /// </summary>
            public string WelcomeMessage
            {
                get { return welcomeMessage; }
                set { welcomeMessage = value; }
            }        
            #endregion

        #endregion

    }
    #endregion

}
