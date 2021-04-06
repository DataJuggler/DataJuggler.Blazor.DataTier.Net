

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

    #region class CommentController
    /// <summary>
    /// This class controls a(n) 'Comment' object.
    /// </summary>
    public class CommentController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'CommentController' object.
        /// </summary>
        public CommentController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateCommentParameter
            /// <summary>
            /// This method creates the parameter for a 'Comment' data operation.
            /// </summary>
            /// <param name='comment'>The 'Comment' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateCommentParameter(Comment comment)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = comment;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Comment tempComment)
            /// <summary>
            /// Deletes a 'Comment' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Comment_Delete'.
            /// </summary>
            /// <param name='comment'>The 'Comment' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Comment tempComment)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteComment";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcomment exists before attemptintg to delete
                    if(tempComment != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteCommentMethod = this.AppController.DataBridge.DataOperations.CommentMethods.DeleteComment;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCommentParameter(tempComment);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteCommentMethod, parameters);

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

            #region FetchAll(Comment tempComment)
            /// <summary>
            /// This method fetches a collection of 'Comment' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Comment_FetchAll'.</summary>
            /// <param name='tempComment'>A temporary Comment for passing values.</param>
            /// <returns>A collection of 'Comment' objects.</returns>
            public List<Comment> FetchAll(Comment tempComment)
            {
                // Initial value
                List<Comment> commentList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.CommentMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateCommentParameter(tempComment);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Comment> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        commentList = (List<Comment>) returnObject.ObjectValue;
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
                return commentList;
            }
            #endregion

            #region Find(Comment tempComment)
            /// <summary>
            /// Finds a 'Comment' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Comment_Find'</param>
            /// </summary>
            /// <param name='tempComment'>A temporary Comment for passing values.</param>
            /// <returns>A 'Comment' object if found else a null 'Comment'.</returns>
            public Comment Find(Comment tempComment)
            {
                // Initial values
                Comment comment = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempComment != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.CommentMethods.FindComment;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCommentParameter(tempComment);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Comment != null))
                        {
                            // Get ReturnObject
                            comment = (Comment) returnObject.ObjectValue;
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
                return comment;
            }
            #endregion

            #region Insert(Comment comment)
            /// <summary>
            /// Insert a 'Comment' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Comment_Insert'.</param>
            /// </summary>
            /// <param name='comment'>The 'Comment' object to insert.</param>
            /// <returns>The id (int) of the new  'Comment' object that was inserted.</returns>
            public int Insert(Comment comment)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Commentexists
                    if(comment != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.CommentMethods.InsertComment;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCommentParameter(comment);

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

            #region Save(ref Comment comment)
            /// <summary>
            /// Saves a 'Comment' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='comment'>The 'Comment' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Comment comment)
            {
                // Initial value
                bool saved = false;

                // If the comment exists.
                if(comment != null)
                {
                    // Is this a new Comment
                    if(comment.IsNew)
                    {
                        // Insert new Comment
                        int newIdentity = this.Insert(comment);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            comment.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Comment
                        saved = this.Update(comment);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Comment comment)
            /// <summary>
            /// This method Updates a 'Comment' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Comment_Update'.</param>
            /// </summary>
            /// <param name='comment'>The 'Comment' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Comment comment)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(comment != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.CommentMethods.UpdateComment;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCommentParameter(comment);
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
