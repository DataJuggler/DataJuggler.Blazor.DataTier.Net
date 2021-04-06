

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class VideoController
    /// <summary>
    /// This class controls a(n) 'Video' object.
    /// </summary>
    public class VideoController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'VideoController' object.
        /// </summary>
        public VideoController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateVideoParameter
            /// <summary>
            /// This method creates the parameter for a 'Video' data operation.
            /// </summary>
            /// <param name='video'>The 'Video' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateVideoParameter(Video video)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = video;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Video tempVideo)
            /// <summary>
            /// Deletes a 'Video' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Video_Delete'.
            /// </summary>
            /// <param name='video'>The 'Video' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Video tempVideo)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteVideo";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempvideo exists before attemptintg to delete
                    if(tempVideo != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteVideoMethod = this.AppController.DataBridge.DataOperations.VideoMethods.DeleteVideo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVideoParameter(tempVideo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteVideoMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Video tempVideo)
            /// <summary>
            /// This method fetches a collection of 'Video' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Video_FetchAll'.</summary>
            /// <param name='tempVideo'>A temporary Video for passing values.</param>
            /// <returns>A collection of 'Video' objects.</returns>
            public List<Video> FetchAll(Video tempVideo)
            {
                // Initial value
                List<Video> videoList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.VideoMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateVideoParameter(tempVideo);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Video> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        videoList = (List<Video>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return videoList;
            }
            #endregion

            #region Find(Video tempVideo)
            /// <summary>
            /// Finds a 'Video' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Video_Find'</param>
            /// </summary>
            /// <param name='tempVideo'>A temporary Video for passing values.</param>
            /// <returns>A 'Video' object if found else a null 'Video'.</returns>
            public Video Find(Video tempVideo)
            {
                // Initial values
                Video video = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempVideo != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.VideoMethods.FindVideo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVideoParameter(tempVideo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Video != null))
                        {
                            // Get ReturnObject
                            video = (Video) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return video;
            }
            #endregion

            #region Insert(Video video)
            /// <summary>
            /// Insert a 'Video' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Video_Insert'.</param>
            /// </summary>
            /// <param name='video'>The 'Video' object to insert.</param>
            /// <returns>The id (int) of the new  'Video' object that was inserted.</returns>
            public int Insert(Video video)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Videoexists
                    if(video != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.VideoMethods.InsertVideo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVideoParameter(video);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Video video)
            /// <summary>
            /// Saves a 'Video' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='video'>The 'Video' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Video video)
            {
                // Initial value
                bool saved = false;

                // If the video exists.
                if(video != null)
                {
                    // Is this a new Video
                    if(video.IsNew)
                    {
                        // Insert new Video
                        int newIdentity = this.Insert(video);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            video.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Video
                        saved = this.Update(video);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Video video)
            /// <summary>
            /// This method Updates a 'Video' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Video_Update'.</param>
            /// </summary>
            /// <param name='video'>The 'Video' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Video video)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(video != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.VideoMethods.UpdateVideo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVideoParameter(video);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
