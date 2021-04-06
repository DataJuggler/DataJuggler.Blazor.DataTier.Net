

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class VideoMethods
    /// <summary>
    /// This class contains methods for modifying a 'Video' object.
    /// </summary>
    public class VideoMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'VideoMethods' object.
        /// </summary>
        public VideoMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteVideo(Video)
            /// <summary>
            /// This method deletes a 'Video' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Video' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteVideo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteVideoStoredProcedure deleteVideoProc = null;

                    // verify the first parameters is a(n) 'Video'.
                    if (parameters[0].ObjectValue as Video != null)
                    {
                        // Create Video
                        Video video = (Video) parameters[0].ObjectValue;

                        // verify video exists
                        if(video != null)
                        {
                            // Now create deleteVideoProc from VideoWriter
                            // The DataWriter converts the 'Video'
                            // to the SqlParameter[] array needed to delete a 'Video'.
                            deleteVideoProc = VideoWriter.CreateDeleteVideoStoredProcedure(video);
                        }
                    }

                    // Verify deleteVideoProc exists
                    if(deleteVideoProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.VideoManager.DeleteVideo(deleteVideoProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Video' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Video' to delete.
            /// <returns>A PolymorphicObject object with all  'Videos' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Video> videoListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllVideosStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get VideoParameter
                    // Declare Parameter
                    Video paramVideo = null;

                    // verify the first parameters is a(n) 'Video'.
                    if (parameters[0].ObjectValue as Video != null)
                    {
                        // Get VideoParameter
                        paramVideo = (Video) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllVideosProc from VideoWriter
                    fetchAllProc = VideoWriter.CreateFetchAllVideosStoredProcedure(paramVideo);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    videoListCollection = this.DataManager.VideoManager.FetchAllVideos(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(videoListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = videoListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindVideo(Video)
            /// <summary>
            /// This method finds a 'Video' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Video' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindVideo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Video video = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindVideoStoredProcedure findVideoProc = null;

                    // verify the first parameters is a 'Video'.
                    if (parameters[0].ObjectValue as Video != null)
                    {
                        // Get VideoParameter
                        Video paramVideo = (Video) parameters[0].ObjectValue;

                        // verify paramVideo exists
                        if(paramVideo != null)
                        {
                            // Now create findVideoProc from VideoWriter
                            // The DataWriter converts the 'Video'
                            // to the SqlParameter[] array needed to find a 'Video'.
                            findVideoProc = VideoWriter.CreateFindVideoStoredProcedure(paramVideo);
                        }

                        // Verify findVideoProc exists
                        if(findVideoProc != null)
                        {
                            // Execute Find Stored Procedure
                            video = this.DataManager.VideoManager.FindVideo(findVideoProc, dataConnector);

                            // if dataObject exists
                            if(video != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = video;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertVideo (Video)
            /// <summary>
            /// This method inserts a 'Video' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Video' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertVideo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Video video = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertVideoStoredProcedure insertVideoProc = null;

                    // verify the first parameters is a(n) 'Video'.
                    if (parameters[0].ObjectValue as Video != null)
                    {
                        // Create Video Parameter
                        video = (Video) parameters[0].ObjectValue;

                        // verify video exists
                        if(video != null)
                        {
                            // Now create insertVideoProc from VideoWriter
                            // The DataWriter converts the 'Video'
                            // to the SqlParameter[] array needed to insert a 'Video'.
                            insertVideoProc = VideoWriter.CreateInsertVideoStoredProcedure(video);
                        }

                        // Verify insertVideoProc exists
                        if(insertVideoProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.VideoManager.InsertVideo(insertVideoProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateVideo (Video)
            /// <summary>
            /// This method updates a 'Video' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Video' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateVideo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Video video = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateVideoStoredProcedure updateVideoProc = null;

                    // verify the first parameters is a(n) 'Video'.
                    if (parameters[0].ObjectValue as Video != null)
                    {
                        // Create Video Parameter
                        video = (Video) parameters[0].ObjectValue;

                        // verify video exists
                        if(video != null)
                        {
                            // Now create updateVideoProc from VideoWriter
                            // The DataWriter converts the 'Video'
                            // to the SqlParameter[] array needed to update a 'Video'.
                            updateVideoProc = VideoWriter.CreateUpdateVideoStoredProcedure(video);
                        }

                        // Verify updateVideoProc exists
                        if(updateVideoProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.VideoManager.UpdateVideo(updateVideoProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
