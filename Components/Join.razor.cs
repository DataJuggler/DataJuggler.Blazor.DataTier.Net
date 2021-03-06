

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using DataJuggler.Blazor.FileUpload;
using Microsoft.AspNetCore.Components.Web;
using System.Web;
using DataJuggler.Net5.Cryptography;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using ObjectLibrary.BusinessObjects;
using DataGateway.Services;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.Enumerations;

#endregion

namespace DataJuggler.Blazor.DataTier.Net.Components
{

    #region class Join
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    public partial class Join : IBlazorComponent, IBlazorComponentParent, ISpriteSubscriber
    {

        #region Private Variables
        private string userName;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string password;
        private string password2;
        private string validationMessage;
        private string name;
        private ValidationComponent userNameComponent;
        private ValidationComponent firstNameComponent;
        private ValidationComponent lastNameComponent;
        private ValidationComponent emailAddressComponent;
        private ValidationComponent passwordComponent;
        private ValidationComponent confirmPasswordComponent;
        private IBlazorComponentParent parent;
        private List<IBlazorComponent> children; 
        private bool showProgress;
        private int percent;
        private string percentString;
        private string progressStyle;
        private Sprite invisibleSprite;
        private bool loginInProcess;
        private int extraPercent;
        #endregion

        #region Consructor
        /// <summary>
        /// Create a new index of an Join page
        /// </summary>
        public Join()
        {
           // Perform initializations for this object
           Init();
        }
        #endregion

        #region Events

            
            
        #endregion

        #region Methods

            #region Cancel()
            /// <summary>
            /// This method Cancel
            /// </summary>
            public void Cancel()
            {
                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // Cancel signing up
                    ParentIndexPage.SetupScreen(ScreenTypeEnum.MainScreen);
                }
            }
            #endregion
            
            #region CaptureUser()
            /// <summary>
            /// This method Captures a Member
            /// </summary>
            public Member CaptureMember()
            {
                // Create a new instance of an 'User' object.
                Member member = new Member();

                // Set the properties
                member.UserName = UserName;
                member.EmailAddress = EmailAddress;
                member.FirstName = FirstName;                
                member.LastName = LastName;
                member.CreatedDate = DateTime.Now;
                member.LastLoginDate = DateTime.Now;
                member.Donations = 0;
                member.AdSpend = 0;
                member.EmailVerified = false;
                member.Premium = false;
                member.IsAdmin = false;
                member.Active = true;

                // return value
                return member;
            }
            #endregion
            
            #region CheckValidEmail(string emailAddress)
            /// <summary>
            /// This method returns the Valid Email
            /// </summary>
            public bool CheckValidEmail(string emailAddress)
            {
                // initial value
                bool isValidEmail = false;

                try
                {
                    // If the emailAddress string exists
                    if (TextHelper.Exists(emailAddress))
                    {
                        // find the at Sign
                        int atSignIndex = emailAddress.IndexOf("@");

                        // if found
                        if (atSignIndex > 0)
                        {
                            // get the wordBefore
                            string wordBefore = emailAddress.Substring(0, atSignIndex -1);

                            // get the words after
                            string wordsAfter = emailAddress.Substring(atSignIndex + 1);

                            // get the delimiters
                            char[] delimiters = { '.' };

                            // get the words
                            List<Word> words = WordParser.GetWords(wordsAfter, delimiters);

                            // if there are 2 or more words, this should be valid
                            isValidEmail = ((TextHelper.Exists(wordBefore)) && (ListHelper.HasXOrMoreItems(words, 2)));
                        } 
                    }
                } 
                catch (Exception error)
                {
                    // not valid
                    isValidEmail = false;

                    // for debugging only
                    DebugHelper.WriteDebugError("CheckValidEmail", "Join.razor.cs", error);
                }
                
                // return value
                return isValidEmail;
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

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent tempChild in Children)
                    {
                        // if this is the item being sought
                        if (TextHelper.IsEqual(tempChild.Name, name))
                        {
                            // set the return value
                            child = tempChild;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return child;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
            }
            #endregion

            #region ProcessNewMemberSignUp(object memberObject)
            /// <summary>
            /// This method Processes a New Member Sign Up
            /// </summary>
            public async void ProcessNewMemberSignUp(object memberObject)
            {
                // create the member
                Member member = memberObject as Member;

                // if the member exists
                if (NullHelper.Exists(member))
                {
                     // Get the KeyCode
                    string keyCode = EnvironmentVariableHelper.GetEnvironmentVariableValue("DataJuggler.Blazor.DataTier.Net");

                    // If the keyCode string exists
                    if (TextHelper.Exists(keyCode))
                    {
                        // Set the PasswordHash, this takes the longest time
                        member.PasswordHash = CryptographyHelper.GeneratePasswordHash(Password, keyCode, 3);  

                        // if the password hash was created
                        if (TextHelper.Exists(member.PasswordHash))
                        {
                             // save the user
                            bool saved = await MemberService.SaveMember(ref member);

                            // if saved
                            if ((saved) && (HasParentIndexPage))
                            {
                                // Force the user to login, see if they entered real data
                                ParentIndexPage.SetupScreen(ScreenTypeEnum.Login, member.EmailAddress);
                            }
                            else
                            {
                                // Show a messagge
                                ValidationMessage = "Oops, something went wrong. Please try again with a different password.";
                            }
                        }
                        else
                        {
                            // Show a messagge
                            ValidationMessage = "Oops, something went wrong. Please try again with a different password.";
                        }
                    }
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public async void ReceiveData(Message message)
            {
                // locals
                Member member = null;
                bool refreshRequired = false;

                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    // if this is a Check Unique request
                    if (TextHelper.IsEqual(message.Text, "Check Unique"))    
                    {
                        // if there are at least one parameter                        
                        if (ListHelper.HasOneOrMoreItems(message.Parameters))                        
                        {   
                            // if User Name
                            if ((TextHelper.IsEqual(message.Parameters[0].Name, "User Name")) && (NullHelper.Exists(message.Parameters[0].Value)))
                            {
                                // get the userName
                                string userName = message.Parameters[0].Value.ToString();

                                // attempt to find the UserName
                                member = await MemberService.FindMemberByUserName(userName);

                                // if the user exists
                                if (HasUserNameComponent)
                                {
                                    // create a response
                                    Message response = new Message();

                                    // if the member exists
                                    if (NullHelper.Exists(member))
                                    {
                                        // set to true
                                        refreshRequired = true;

                                        // Send a response of Taken
                                        response.Text = "Taken";

                                        // Create the parameters
                                        NamedParameter namedParameter = new NamedParameter();

                                        // Set the name
                                        namedParameter.Name = "Validation Message";

                                        // Set the value
                                        namedParameter.Value = "The User Name is already taken. Click the login button if this is you.";

                                        // Set the ValidationMessage
                                        this.ValidationMessage = namedParameter.Value.ToString();

                                        // Add the parameter
                                        response.Parameters.Add(namedParameter);

                                        // Not valid
                                        UserNameComponent.IsValid = false;
                                    }
                                    else
                                    {
                                        // Send a response of Taken
                                        response.Text = "Available";

                                        // valid
                                        UserNameComponent.IsValid = true;
                                    }

                                    // send a message to the user
                                    UserNameComponent.ReceiveData(response);

                                    
                                }
                            }   
                            //if EmailAddress
                            else if ((TextHelper.IsEqual(message.Parameters[0].Name, "Email Address")) && (NullHelper.Exists(message.Parameters[0].Value)))
                            {
                                // get the email
                                string email = message.Parameters[0].Value.ToString();

                                // attempt to find the UserName
                                member = await MemberService.FindMemberByEmailAddress(email);

                                // if the value for HasEmailAddressComponent is true
                                if (HasEmailAddressComponent)
                                {
                                    // create a response
                                    Message response = new Message();

                                    // if the member exists
                                    if (NullHelper.Exists(member))
                                    {
                                        // set to true
                                        refreshRequired = true; 

                                        // Send a response of Taken
                                        response.Text = "Taken";

                                        // Create the parameters
                                        NamedParameter namedParameter = new NamedParameter();

                                        // Set the name
                                        namedParameter.Name = "Validation Message";

                                        // Set the value
                                        namedParameter.Value = "This email address is already taken. Click the Login Button if this is you.";

                                        // set the ValidationMessage
                                        this.ValidationMessage = namedParameter.Value.ToString();

                                        // Add the parameter
                                        response.Parameters.Add(namedParameter);

                                        // Not valid
                                        EmailAddressComponent.IsValid = false;
                                    }
                                    else
                                    {
                                        // Send a response of Available
                                        response.Text = "Available";

                                        // Not valid
                                        EmailAddressComponent.IsValid = true;
                                    }

                                    // send a message to the user
                                    EmailAddressComponent.ReceiveData(response);
                                }
                            }   
                        }
                    }
                }

                if (refreshRequired)
                {
                    // update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // if the value for LoginInProcess is true
                if (LoginInProcess)
                {
                    // increment by 1
                    Percent += 1;

                    // go a little past 100 for effect
                    if (Percent >= 100)
                    {
                        // Increment
                        ExtraPercent++;
                    }

                    // if higher than 10
                    if (ExtraPercent >= 10)
                    {
                        // Stop the timer
                        InvisibleSprite.Stop();
                        ShowProgress = false;
                    }
                }

                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // If the component object exists
                if (NullHelper.Exists(component))
                {
                    // if this is the UserName component
                    if (component.Name == "UserNameComponent")
                    {
                        // Set the component
                        UserNameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "FirstNameComponent")
                    {
                        // Set the component
                        FirstNameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "LastNameComponent")
                    {
                        // Set the component
                        LastNameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "EmailAddressComponent")
                    {
                        // Set the component
                        EmailAddressComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "PasswordComponent")
                    {
                        // Set the component
                        PasswordComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "ConfirmPasswordComponent")
                    {
                        // Set the component
                        ConfirmPasswordComponent = component as ValidationComponent;
                    }

                    // if the Children collection exists
                    if (HasChildren)
                    {
                        // Add this item
                        Children.Add(component);
                    }
                }
            }
            #endregion

            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // Set the InvisibleSprite
                InvisibleSprite = sprite;
            }
            #endregion
            
            #region SignUp()
            /// <summary>
            /// This method Signs Up a User
            /// </summary>
            public void SignUp()
            {
                // validate the user
                bool isValid = ValidateUser();
                
                // if everything is valid
                if (isValid)
                {  
                    // Set to 0 percent
                    Percent = 0;

                    // Process the Login
                    bool started = StartProcessSignUp();
                    
                    // if the InvisiibleSprite exists
                    if (HasInvisibleSprite)
                    {
                        // A login in process is true
                        LoginInProcess = true;

                        // Start the Timer
                        InvisibleSprite.Start();
                    }

                    // Show the ProgressBar
                    ShowProgress = true;                    
                }
            }
            #endregion
            
            #region StartProcessSignUp()
            /// <summary>
            /// This method returns the Process Sign Up
            /// </summary>
            public bool StartProcessSignUp()
            {
                // initial value
                bool started = false;

                // Create a Thread to Process the Signup
                Thread thread = new Thread(ProcessNewMemberSignUp);

                // Set the value for the property 'IsBackground' to true                        
                thread.IsBackground = true;

                // Capture the current user
                Member member = CaptureMember();

                // Startup the thread and pass in the SignUp model
                thread.Start(member);

                // set to true
                started = true;
                
                // return value
                return started;
            }
            #endregion
            
            #region ValidateUser()
            /// <summary>
            /// This method returns the User
            /// </summary>
            public bool ValidateUser()
            {
                // initial value (default to true)
                bool isValid = true;

                // Erase by default
                ValidationMessage = "";

                // if there is a UserNameComponent
                if (HasUserNameComponent)
                {
                    // validate this control
                    isValid = UserNameComponent.Validate();

                    // if the value for isValid is false
                    if (!isValid)
                    {
                        // Set the Validation Message
                        ValidationMessage = UserNameComponent.InvalidReason;
                    }
                    else
                    {
                        // Set the UserName
                        UserName = UserNameComponent.Text;
                    }
                }

                // if the value for HasFirstNameComponent is true
                if (HasFirstNameComponent)
                {
                    // no validation is required, just capturing the value
                    this.FirstName = FirstNameComponent.Text;
                }

                // if the value for HasLastNameComponent is true
                if (HasLastNameComponent)
                {
                    // no validation is required, just capturing the value
                    this.LastName = LastNameComponent.Text;
                }

                // if still valid
                if ((isValid) && (HasEmailAddressComponent))
                {
                    // is this valid
                    isValid = EmailAddressComponent.Validate();

                    // if not valid
                    if (!isValid)
                    {
                        // Set the InvalidReason
                        ValidationMessage = EmailAddressComponent.InvalidReason;
                    }
                    else
                    {
                        // next we must check if this is a valid email
                        isValid = CheckValidEmail(EmailAddressComponent.Text);

                        // if not valid
                        if (!isValid)
                        {
                            // Set the text
                            ValidationMessage = "Please enter a valid email address";

                            // set to false
                            EmailAddressComponent.IsValid = false;
                        }
                        else
                        {
                            // Set the EmailAddress
                            EmailAddress = EmailAddressComponent.Text;
                        }
                    }

                    // if the Password exists
                    if ((isValid) && (HasPasswordComponent))
                    {
                        // for debugging only
                        string name = PasswordComponent.Name;

                         // validate this control
                        isValid = PasswordComponent.Validate();

                        // if the value for isValid is false
                        if (!isValid)
                        {
                            // Set the Validation Message
                            ValidationMessage = PasswordComponent.InvalidReason;
                        }
                        else
                        {
                            // Set Password
                            Password = PasswordComponent.Text;
                        }
                    }

                    // if the Confirm Password exists
                    if ((isValid) && (HasConfirmPasswordComponent))
                    {
                         // validate this control
                        isValid = ConfirmPasswordComponent.Validate();

                        // if the value for isValid is false
                        if (!isValid)
                        {
                            // Set the Validation Message
                            ValidationMessage = ConfirmPasswordComponent.InvalidReason;
                        }
                        else
                        {
                            // Set Password2
                            Password2 = ConfirmPasswordComponent.Text;
                        }
                    }

                    // if still valid
                    if (isValid)
                    {
                        // next we must check that the two passwords match
                        if (!TextHelper.IsEqual(Password, Password2, true, true))
                        {
                            // set to false
                            isValid = false;

                            // Set the failed reason
                            ValidationMessage = "The passwords do not match";

                            // verify both components exist
                            if ((HasPasswordComponent) && (HasConfirmPasswordComponent))
                            {
                                // set both to not valid
                                PasswordComponent.IsValid = false;
                                ConfirmPasswordComponent.IsValid = false;
                            }
                        }
                    }
                }
                
                // return value
                return isValid;
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
            
            #region ConfirmPasswordComponent
            /// <summary>
            /// This property gets or sets the value for 'ConfirmPasswordComponent'.
            /// </summary>
            public ValidationComponent ConfirmPasswordComponent
            {
                get { return confirmPasswordComponent; }
                set { confirmPasswordComponent = value; }
            }
            #endregion
            
            #region EmailAddress
            /// <summary>
            /// This property gets or sets the value for 'EmailAddress'.
            /// </summary>
            public string EmailAddress
            {
                get { return emailAddress; }
                set { emailAddress = value; }
            }
            #endregion
            
            #region EmailAddressComponent
            /// <summary>
            /// This property gets or sets the value for 'EmailAddressComponent'.
            /// </summary>
            public ValidationComponent EmailAddressComponent
            {
                get { return emailAddressComponent; }
                set { emailAddressComponent = value; }
            }
            #endregion
            
            #region ExtraPercent
            /// <summary>
            /// This property gets or sets the value for 'ExtraPercent'.
            /// </summary>
            public int ExtraPercent
            {
                get { return extraPercent; }
                set { extraPercent = value; }
            }
            #endregion
            
            #region FirstName
            /// <summary>
            /// This property gets or sets the value for 'FirstName'.
            /// </summary>
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            #endregion
            
            #region FirstNameComponent
            /// <summary>
            /// This property gets or sets the value for 'FirstNameComponent'.
            /// </summary>
            public ValidationComponent FirstNameComponent
            {
                get { return firstNameComponent; }
                set { firstNameComponent = value; }
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
            
            #region HasConfirmPasswordComponent
            /// <summary>
            /// This property returns true if this object has a 'ConfirmPasswordComponent'.
            /// </summary>
            public bool HasConfirmPasswordComponent
            {
                get
                {
                    // initial value
                    bool hasConfirmPasswordComponent = (this.ConfirmPasswordComponent != null);
                    
                    // return value
                    return hasConfirmPasswordComponent;
                }
            }
            #endregion
            
            #region HasEmailAddressComponent
            /// <summary>
            /// This property returns true if this object has an 'EmailAddressComponent'.
            /// </summary>
            public bool HasEmailAddressComponent
            {
                get
                {
                    // initial value
                    bool hasEmailAddressComponent = (this.EmailAddressComponent != null);
                    
                    // return value
                    return hasEmailAddressComponent;
                }
            }
            #endregion
            
            #region HasFirstNameComponent
            /// <summary>
            /// This property returns true if this object has a 'FirstNameComponent'.
            /// </summary>
            public bool HasFirstNameComponent
            {
                get
                {
                    // initial value
                    bool hasFirstNameComponent = (this.FirstNameComponent != null);
                    
                    // return value
                    return hasFirstNameComponent;
                }
            }
            #endregion
            
            #region HasInvisibleSprite
            /// <summary>
            /// This property returns true if this object has an 'InvisibleSprite'.
            /// </summary>
            public bool HasInvisibleSprite
            {
                get
                {
                    // initial value
                    bool hasInvisibleSprite = (this.InvisibleSprite != null);
                    
                    // return value
                    return hasInvisibleSprite;
                }
            }
            #endregion
            
            #region HasLastName
            /// <summary>
            /// This property returns true if the 'LastName' exists.
            /// </summary>
            public bool HasLastName
            {
                get
                {
                    // initial value
                    bool hasLastName = (!String.IsNullOrEmpty(this.LastName));
                    
                    // return value
                    return hasLastName;
                }
            }
            #endregion
            
            #region HasLastNameComponent
            /// <summary>
            /// This property returns true if this object has a 'LastNameComponent'.
            /// </summary>
            public bool HasLastNameComponent
            {
                get
                {
                    // initial value
                    bool hasLastNameComponent = (this.LastNameComponent != null);
                    
                    // return value
                    return hasLastNameComponent;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
                }
            }
            #endregion
            
            #region HasPasswordComponent
            /// <summary>
            /// This property returns true if this object has a 'PasswordComponent'.
            /// </summary>
            public bool HasPasswordComponent
            {
                get
                {
                    // initial value
                    bool hasPasswordComponent = (this.PasswordComponent != null);
                    
                    // return value
                    return hasPasswordComponent;
                }
            }
            #endregion
            
            #region HasUserNameComponent
            /// <summary>
            /// This property returns true if this object has an 'UserNameComponent'.
            /// </summary>
            public bool HasUserNameComponent
            {
                get
                {
                    // initial value
                    bool hasUserNameComponent = (this.UserNameComponent != null);
                    
                    // return value
                    return hasUserNameComponent;
                }
            }
            #endregion

            #region InvisibleSprite
            /// <summary>
            /// This property gets or sets the value for 'InvisibleSprite'.
            /// </summary>
            public Sprite InvisibleSprite
            {
                get { return invisibleSprite; }
                set { invisibleSprite = value; }
            }
            #endregion
            
            #region LastName
            /// <summary>
            /// This property gets or sets the value for 'LastName'.
            /// </summary>
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            #endregion
            
            #region LastNameComponent
            /// <summary>
            /// This property gets or sets the value for 'LastNameComponent'.
            /// </summary>
            public ValidationComponent LastNameComponent
            {
                get { return lastNameComponent; }
                set { lastNameComponent = value; }
            }
            #endregion
            
            #region LoginInProcess
            /// <summary>
            /// This property gets or sets the value for 'LoginInProcess'.
            /// </summary>
            public bool LoginInProcess
            {
                get { return loginInProcess; }
                set { loginInProcess = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                { 
                    // set the value
                    parent = value;

                    // if the Parent exists
                    if (HasParent)
                    {
                        // Register with the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion

            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value for 'ParentIndexPage'.
            /// </summary>
            public DataJuggler.Blazor.DataTier.Net.Pages.Index ParentIndexPage
            {
                get
                {
                    // cast the parent as an Index page
                    return this.Parent as DataJuggler.Blazor.DataTier.Net.Pages.Index;
                }
            }
            #endregion
            
            #region Password
            /// <summary>
            /// This property gets or sets the value for 'Password'.
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            #endregion
            
            #region Password2
            /// <summary>
            /// This property gets or sets the value for 'Password2'.
            /// </summary>
            public string Password2
            {
                get { return password2; }
                set { password2 = value; }
            }
            #endregion
            
            #region PasswordComponent
            /// <summary>
            /// This property gets or sets the value for 'PasswordComponent'.
            /// </summary>
            public ValidationComponent PasswordComponent
            {
                get { return passwordComponent; }
                set { passwordComponent = value; }
            }
            #endregion

            #region Percent
            /// <summary>
            /// This property gets or sets the value for 'Percent'.
            /// </summary>
            public int Percent
            {
                get { return percent; }
                set 
                {
                    // if less than zero
                    if (value < 0)
                    {
                        // set to 0
                        value = 0;
                    }

                    // if greater than 100
                    if (value > 100)
                    {
                        // set to 100
                        value = 100;
                    }

                    // set the value
                    percent = value;

                    // Now set ProgressStyle
                    ProgressStyle = "c100 p[Percent] dark small orange".Replace("[Percent]", percent.ToString());

                    // Set the percentString value
                    PercentString = percent.ToString() + "%";
                }
            }
            #endregion
            
            #region PercentString
            /// <summary>
            /// This property gets or sets the value for 'PercentString'.
            /// </summary>
            public string PercentString
            {
                get { return percentString; }
                set { percentString = value; }
            }
            #endregion
            
            #region ProgressStyle
            /// <summary>
            /// This property gets or sets the value for 'ProgressStyle'.
            /// </summary>
            public string ProgressStyle
            {
                get { return progressStyle; }
                set { progressStyle = value; }
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
            
            #region UserName
            /// <summary>
            /// This property gets or sets the value for 'UserName'.
            /// </summary>
            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }
            #endregion
            
            #region UserNameComponent
            /// <summary>
            /// This property gets or sets the value for 'UserNameComponent'.
            /// </summary>
            public ValidationComponent UserNameComponent
            {
                get { return userNameComponent; }
                set { userNameComponent = value; }
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

        #endregion

    }
    #endregion

}
