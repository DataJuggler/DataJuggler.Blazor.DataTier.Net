
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteComment(int id, Comment tempComment = null)
            /// <summary>
            /// This method is used to delete Comment objects.
            /// </summary>
            /// <param name="id">Delete the Comment with this id</param>
            /// <param name="tempComment">Pass in a tempComment to perform a custom delete.</param>
            public bool DeleteComment(int id, Comment tempComment = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempComment does not exist
                    if (tempComment == null)
                    {
                        // create a temp Comment
                        tempComment = new Comment();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempComment.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.CommentController.Delete(tempComment);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteMember(int id, Member tempMember = null)
            /// <summary>
            /// This method is used to delete Member objects.
            /// </summary>
            /// <param name="id">Delete the Member with this id</param>
            /// <param name="tempMember">Pass in a tempMember to perform a custom delete.</param>
            public bool DeleteMember(int id, Member tempMember = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempMember does not exist
                    if (tempMember == null)
                    {
                        // create a temp Member
                        tempMember = new Member();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempMember.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.MemberController.Delete(tempMember);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteTags(int id, Tags tempTags = null)
            /// <summary>
            /// This method is used to delete Tags objects.
            /// </summary>
            /// <param name="id">Delete the Tags with this id</param>
            /// <param name="tempTags">Pass in a tempTags to perform a custom delete.</param>
            public bool DeleteTags(int id, Tags tempTags = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempTags does not exist
                    if (tempTags == null)
                    {
                        // create a temp Tags
                        tempTags = new Tags();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempTags.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.TagsController.Delete(tempTags);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteVideo(int id, Video tempVideo = null)
            /// <summary>
            /// This method is used to delete Video objects.
            /// </summary>
            /// <param name="id">Delete the Video with this id</param>
            /// <param name="tempVideo">Pass in a tempVideo to perform a custom delete.</param>
            public bool DeleteVideo(int id, Video tempVideo = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempVideo does not exist
                    if (tempVideo == null)
                    {
                        // create a temp Video
                        tempVideo = new Video();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempVideo.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.VideoController.Delete(tempVideo);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindComment(int id, Comment tempComment = null)
            /// <summary>
            /// This method is used to find 'Comment' objects.
            /// </summary>
            /// <param name="id">Find the Comment with this id</param>
            /// <param name="tempComment">Pass in a tempComment to perform a custom find.</param>
            public Comment FindComment(int id, Comment tempComment = null)
            {
                // initial value
                Comment comment = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempComment does not exist
                    if (tempComment == null)
                    {
                        // create a temp Comment
                        tempComment = new Comment();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempComment.UpdateIdentity(id);
                    }

                    // perform the find
                    comment = this.AppController.ControllerManager.CommentController.Find(tempComment);
                }

                // return value
                return comment;
            }
            #endregion

            #region FindMember(int id, Member tempMember = null)
            /// <summary>
            /// This method is used to find 'Member' objects.
            /// </summary>
            /// <param name="id">Find the Member with this id</param>
            /// <param name="tempMember">Pass in a tempMember to perform a custom find.</param>
            public Member FindMember(int id, Member tempMember = null)
            {
                // initial value
                Member member = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempMember does not exist
                    if (tempMember == null)
                    {
                        // create a temp Member
                        tempMember = new Member();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempMember.UpdateIdentity(id);
                    }

                    // perform the find
                    member = this.AppController.ControllerManager.MemberController.Find(tempMember);
                }

                // return value
                return member;
            }
            #endregion

            #region FindMemberByEmailAddress(string emailAddress)
            /// <summary>
            /// This method is used to find 'Member' objects for the EmailAddress given.
            /// </summary>
            public Member FindMemberByEmailAddress(string emailAddress)
            {
                // initial value
                Member member = null;
                
                // Create a temp Member object
                Member tempMember = new Member();
                
                // Set the value for FindByEmailAddress to true
                tempMember.FindByEmailAddress = true;
                
                // Set the value for EmailAddress
                tempMember.EmailAddress = emailAddress;
                
                // Perform the find
                member = FindMember(0, tempMember);
                
                // return value
                return member;
            }
            #endregion
            
            #region FindMemberByUserName(string userName)
            /// <summary>
            /// This method is used to find 'Member' objects for the UserName given.
            /// </summary>
            public Member FindMemberByUserName(string userName)
            {
                // initial value
                Member member = null;
                
                // Create a temp Member object
                Member tempMember = new Member();
                
                // Set the value for FindByUserName to true
                tempMember.FindByUserName = true;
                
                // Set the value for UserName
                tempMember.UserName = userName;
                
                // Perform the find
                member = FindMember(0, tempMember);
                
                // return value
                return member;
            }
            #endregion
            
            #region FindTags(int id, Tags tempTags = null)
            /// <summary>
            /// This method is used to find 'Tags' objects.
            /// </summary>
            /// <param name="id">Find the Tags with this id</param>
            /// <param name="tempTags">Pass in a tempTags to perform a custom find.</param>
            public Tags FindTags(int id, Tags tempTags = null)
            {
                // initial value
                Tags tags = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempTags does not exist
                    if (tempTags == null)
                    {
                        // create a temp Tags
                        tempTags = new Tags();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempTags.UpdateIdentity(id);
                    }

                    // perform the find
                    tags = this.AppController.ControllerManager.TagsController.Find(tempTags);
                }

                // return value
                return tags;
            }
            #endregion

            #region FindVideo(int id, Video tempVideo = null)
            /// <summary>
            /// This method is used to find 'Video' objects.
            /// </summary>
            /// <param name="id">Find the Video with this id</param>
            /// <param name="tempVideo">Pass in a tempVideo to perform a custom find.</param>
            public Video FindVideo(int id, Video tempVideo = null)
            {
                // initial value
                Video video = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempVideo does not exist
                    if (tempVideo == null)
                    {
                        // create a temp Video
                        tempVideo = new Video();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempVideo.UpdateIdentity(id);
                    }

                    // perform the find
                    video = this.AppController.ControllerManager.VideoController.Find(tempVideo);
                }

                // return value
                return video;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadComments(Comment tempComment = null)
            /// <summary>
            /// This method loads a collection of 'Comment' objects.
            /// </summary>
            public List<Comment> LoadComments(Comment tempComment = null)
            {
                // initial value
                List<Comment> comments = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    comments = this.AppController.ControllerManager.CommentController.FetchAll(tempComment);
                }

                // return value
                return comments;
            }
            #endregion

            #region LoadCommentsForVideoId(int videoId)
            /// <summary>
            /// This method is used to load 'Comment' objects for the VideoId given.
            /// </summary>
            public List<Comment> LoadCommentsForVideoId(int videoId)
            {
                // initial value
                List<Comment> comments = null;
                
                // Create a temp Comment object
                Comment tempComment = new Comment();
                
                // Set the value for LoadByVideoId to true
                tempComment.LoadByVideoId = true;
                
                // Set the value for VideoId
                tempComment.VideoId = videoId;
                
                // Perform the load
                comments = LoadComments(tempComment);
                
                // return value
                return comments;
            }
            #endregion
            
            #region LoadMembers(Member tempMember = null)
            /// <summary>
            /// This method loads a collection of 'Member' objects.
            /// </summary>
            public List<Member> LoadMembers(Member tempMember = null)
            {
                // initial value
                List<Member> members = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    members = this.AppController.ControllerManager.MemberController.FetchAll(tempMember);
                }

                // return value
                return members;
            }
            #endregion

            #region LoadTags(Tags tempTags = null)
            /// <summary>
            /// This method loads a collection of 'Tags' objects.
            /// </summary>
            public List<Tags> LoadTags(Tags tempTags = null)
            {
                // initial value
                List<Tags> tags = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    tags = this.AppController.ControllerManager.TagsController.FetchAll(tempTags);
                }

                // return value
                return tags;
            }
            #endregion

            #region LoadVideos(Video tempVideo = null)
            /// <summary>
            /// This method loads a collection of 'Video' objects.
            /// </summary>
            public List<Video> LoadVideos(Video tempVideo = null)
            {
                // initial value
                List<Video> videos = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    videos = this.AppController.ControllerManager.VideoController.FetchAll(tempVideo);
                }

                // return value
                return videos;
            }
            #endregion

            #region LoadVideosForMemberId(int memberId)
            /// <summary>
            /// This method is used to load 'Video' objects for the MemberId given.
            /// </summary>
            public List<Video> LoadVideosForMemberId(int memberId)
            {
                // initial value
                List<Video> videos = null;
                
                // Create a temp Video object
                Video tempVideo = new Video();
                
                // Set the value for LoadByMemberId to true
                tempVideo.LoadByMemberId = true;
                
                // Set the value for MemberId
                tempVideo.MemberId = memberId;
                
                // Perform the load
                videos = LoadVideos(tempVideo);
                
                // return value
                return videos;
            }
            #endregion
            
            #region SaveComment(ref Comment comment)
            /// <summary>
            /// This method is used to save 'Comment' objects.
            /// </summary>
            /// <param name="comment">The Comment to save.</param>
            public bool SaveComment(ref Comment comment)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.CommentController.Save(ref comment);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveMember(ref Member member)
            /// <summary>
            /// This method is used to save 'Member' objects.
            /// </summary>
            /// <param name="member">The Member to save.</param>
            public bool SaveMember(ref Member member)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.MemberController.Save(ref member);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveTags(ref Tags tags)
            /// <summary>
            /// This method is used to save 'Tags' objects.
            /// </summary>
            /// <param name="tags">The Tags to save.</param>
            public bool SaveTags(ref Tags tags)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.TagsController.Save(ref tags);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveVideo(ref Video video)
            /// <summary>
            /// This method is used to save 'Video' objects.
            /// </summary>
            /// <param name="video">The Video to save.</param>
            public bool SaveVideo(ref Video video)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.VideoController.Save(ref video);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

