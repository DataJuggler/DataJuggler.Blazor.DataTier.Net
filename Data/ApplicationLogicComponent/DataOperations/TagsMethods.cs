

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

    #region class TagsMethods
    /// <summary>
    /// This class contains methods for modifying a 'Tags' object.
    /// </summary>
    public class TagsMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'TagsMethods' object.
        /// </summary>
        public TagsMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteTags(Tags)
            /// <summary>
            /// This method deletes a 'Tags' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Tags' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteTags(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteTagsStoredProcedure deleteTagsProc = null;

                    // verify the first parameters is a(n) 'Tags'.
                    if (parameters[0].ObjectValue as Tags != null)
                    {
                        // Create Tags
                        Tags tags = (Tags) parameters[0].ObjectValue;

                        // verify tags exists
                        if(tags != null)
                        {
                            // Now create deleteTagsProc from TagsWriter
                            // The DataWriter converts the 'Tags'
                            // to the SqlParameter[] array needed to delete a 'Tags'.
                            deleteTagsProc = TagsWriter.CreateDeleteTagsStoredProcedure(tags);
                        }
                    }

                    // Verify deleteTagsProc exists
                    if(deleteTagsProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.TagsManager.DeleteTags(deleteTagsProc, dataConnector);

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
            /// This method fetches all 'Tags' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Tags' to delete.
            /// <returns>A PolymorphicObject object with all  'Tags' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Tags> tagsListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllTagsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get TagsParameter
                    // Declare Parameter
                    Tags paramTags = null;

                    // verify the first parameters is a(n) 'Tags'.
                    if (parameters[0].ObjectValue as Tags != null)
                    {
                        // Get TagsParameter
                        paramTags = (Tags) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllTagsProc from TagsWriter
                    fetchAllProc = TagsWriter.CreateFetchAllTagsStoredProcedure(paramTags);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    tagsListCollection = this.DataManager.TagsManager.FetchAllTags(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(tagsListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = tagsListCollection;
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

            #region FindTags(Tags)
            /// <summary>
            /// This method finds a 'Tags' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Tags' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindTags(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Tags tags = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindTagsStoredProcedure findTagsProc = null;

                    // verify the first parameters is a 'Tags'.
                    if (parameters[0].ObjectValue as Tags != null)
                    {
                        // Get TagsParameter
                        Tags paramTags = (Tags) parameters[0].ObjectValue;

                        // verify paramTags exists
                        if(paramTags != null)
                        {
                            // Now create findTagsProc from TagsWriter
                            // The DataWriter converts the 'Tags'
                            // to the SqlParameter[] array needed to find a 'Tags'.
                            findTagsProc = TagsWriter.CreateFindTagsStoredProcedure(paramTags);
                        }

                        // Verify findTagsProc exists
                        if(findTagsProc != null)
                        {
                            // Execute Find Stored Procedure
                            tags = this.DataManager.TagsManager.FindTags(findTagsProc, dataConnector);

                            // if dataObject exists
                            if(tags != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = tags;
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

            #region InsertTags (Tags)
            /// <summary>
            /// This method inserts a 'Tags' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Tags' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertTags(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Tags tags = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertTagsStoredProcedure insertTagsProc = null;

                    // verify the first parameters is a(n) 'Tags'.
                    if (parameters[0].ObjectValue as Tags != null)
                    {
                        // Create Tags Parameter
                        tags = (Tags) parameters[0].ObjectValue;

                        // verify tags exists
                        if(tags != null)
                        {
                            // Now create insertTagsProc from TagsWriter
                            // The DataWriter converts the 'Tags'
                            // to the SqlParameter[] array needed to insert a 'Tags'.
                            insertTagsProc = TagsWriter.CreateInsertTagsStoredProcedure(tags);
                        }

                        // Verify insertTagsProc exists
                        if(insertTagsProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.TagsManager.InsertTags(insertTagsProc, dataConnector);
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

            #region UpdateTags (Tags)
            /// <summary>
            /// This method updates a 'Tags' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Tags' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateTags(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Tags tags = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateTagsStoredProcedure updateTagsProc = null;

                    // verify the first parameters is a(n) 'Tags'.
                    if (parameters[0].ObjectValue as Tags != null)
                    {
                        // Create Tags Parameter
                        tags = (Tags) parameters[0].ObjectValue;

                        // verify tags exists
                        if(tags != null)
                        {
                            // Now create updateTagsProc from TagsWriter
                            // The DataWriter converts the 'Tags'
                            // to the SqlParameter[] array needed to update a 'Tags'.
                            updateTagsProc = TagsWriter.CreateUpdateTagsStoredProcedure(tags);
                        }

                        // Verify updateTagsProc exists
                        if(updateTagsProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.TagsManager.UpdateTags(updateTagsProc, dataConnector);

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
