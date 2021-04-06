

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

    #region class TagsController
    /// <summary>
    /// This class controls a(n) 'Tags' object.
    /// </summary>
    public class TagsController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'TagsController' object.
        /// </summary>
        public TagsController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateTagsParameter
            /// <summary>
            /// This method creates the parameter for a 'Tags' data operation.
            /// </summary>
            /// <param name='tags'>The 'Tags' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateTagsParameter(Tags tags)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = tags;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Tags tempTags)
            /// <summary>
            /// Deletes a 'Tags' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Tags_Delete'.
            /// </summary>
            /// <param name='tags'>The 'Tags' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Tags tempTags)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteTags";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temptags exists before attemptintg to delete
                    if(tempTags != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteTagsMethod = this.AppController.DataBridge.DataOperations.TagsMethods.DeleteTags;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateTagsParameter(tempTags);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteTagsMethod, parameters);

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

            #region FetchAll(Tags tempTags)
            /// <summary>
            /// This method fetches a collection of 'Tags' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Tags_FetchAll'.</summary>
            /// <param name='tempTags'>A temporary Tags for passing values.</param>
            /// <returns>A collection of 'Tags' objects.</returns>
            public List<Tags> FetchAll(Tags tempTags)
            {
                // Initial value
                List<Tags> tagsList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.TagsMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateTagsParameter(tempTags);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Tags> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        tagsList = (List<Tags>) returnObject.ObjectValue;
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
                return tagsList;
            }
            #endregion

            #region Find(Tags tempTags)
            /// <summary>
            /// Finds a 'Tags' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Tags_Find'</param>
            /// </summary>
            /// <param name='tempTags'>A temporary Tags for passing values.</param>
            /// <returns>A 'Tags' object if found else a null 'Tags'.</returns>
            public Tags Find(Tags tempTags)
            {
                // Initial values
                Tags tags = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempTags != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.TagsMethods.FindTags;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateTagsParameter(tempTags);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Tags != null))
                        {
                            // Get ReturnObject
                            tags = (Tags) returnObject.ObjectValue;
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
                return tags;
            }
            #endregion

            #region Insert(Tags tags)
            /// <summary>
            /// Insert a 'Tags' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Tags_Insert'.</param>
            /// </summary>
            /// <param name='tags'>The 'Tags' object to insert.</param>
            /// <returns>The id (int) of the new  'Tags' object that was inserted.</returns>
            public int Insert(Tags tags)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Tagsexists
                    if(tags != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.TagsMethods.InsertTags;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateTagsParameter(tags);

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

            #region Save(ref Tags tags)
            /// <summary>
            /// Saves a 'Tags' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='tags'>The 'Tags' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Tags tags)
            {
                // Initial value
                bool saved = false;

                // If the tags exists.
                if(tags != null)
                {
                    // Is this a new Tags
                    if(tags.IsNew)
                    {
                        // Insert new Tags
                        int newIdentity = this.Insert(tags);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            tags.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Tags
                        saved = this.Update(tags);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Tags tags)
            /// <summary>
            /// This method Updates a 'Tags' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Tags_Update'.</param>
            /// </summary>
            /// <param name='tags'>The 'Tags' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Tags tags)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(tags != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.TagsMethods.UpdateTags;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateTagsParameter(tags);
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
