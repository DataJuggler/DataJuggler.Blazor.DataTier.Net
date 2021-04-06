

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

    #region class CommentMethods
    /// <summary>
    /// This class contains methods for modifying a 'Comment' object.
    /// </summary>
    public class CommentMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'CommentMethods' object.
        /// </summary>
        public CommentMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteComment(Comment)
            /// <summary>
            /// This method deletes a 'Comment' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Comment' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteComment(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteCommentStoredProcedure deleteCommentProc = null;

                    // verify the first parameters is a(n) 'Comment'.
                    if (parameters[0].ObjectValue as Comment != null)
                    {
                        // Create Comment
                        Comment comment = (Comment) parameters[0].ObjectValue;

                        // verify comment exists
                        if(comment != null)
                        {
                            // Now create deleteCommentProc from CommentWriter
                            // The DataWriter converts the 'Comment'
                            // to the SqlParameter[] array needed to delete a 'Comment'.
                            deleteCommentProc = CommentWriter.CreateDeleteCommentStoredProcedure(comment);
                        }
                    }

                    // Verify deleteCommentProc exists
                    if(deleteCommentProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.CommentManager.DeleteComment(deleteCommentProc, dataConnector);

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
            /// This method fetches all 'Comment' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Comment' to delete.
            /// <returns>A PolymorphicObject object with all  'Comments' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Comment> commentListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllCommentsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get CommentParameter
                    // Declare Parameter
                    Comment paramComment = null;

                    // verify the first parameters is a(n) 'Comment'.
                    if (parameters[0].ObjectValue as Comment != null)
                    {
                        // Get CommentParameter
                        paramComment = (Comment) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllCommentsProc from CommentWriter
                    fetchAllProc = CommentWriter.CreateFetchAllCommentsStoredProcedure(paramComment);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    commentListCollection = this.DataManager.CommentManager.FetchAllComments(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(commentListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = commentListCollection;
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

            #region FindComment(Comment)
            /// <summary>
            /// This method finds a 'Comment' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Comment' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindComment(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Comment comment = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindCommentStoredProcedure findCommentProc = null;

                    // verify the first parameters is a 'Comment'.
                    if (parameters[0].ObjectValue as Comment != null)
                    {
                        // Get CommentParameter
                        Comment paramComment = (Comment) parameters[0].ObjectValue;

                        // verify paramComment exists
                        if(paramComment != null)
                        {
                            // Now create findCommentProc from CommentWriter
                            // The DataWriter converts the 'Comment'
                            // to the SqlParameter[] array needed to find a 'Comment'.
                            findCommentProc = CommentWriter.CreateFindCommentStoredProcedure(paramComment);
                        }

                        // Verify findCommentProc exists
                        if(findCommentProc != null)
                        {
                            // Execute Find Stored Procedure
                            comment = this.DataManager.CommentManager.FindComment(findCommentProc, dataConnector);

                            // if dataObject exists
                            if(comment != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = comment;
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

            #region InsertComment (Comment)
            /// <summary>
            /// This method inserts a 'Comment' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Comment' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertComment(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Comment comment = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertCommentStoredProcedure insertCommentProc = null;

                    // verify the first parameters is a(n) 'Comment'.
                    if (parameters[0].ObjectValue as Comment != null)
                    {
                        // Create Comment Parameter
                        comment = (Comment) parameters[0].ObjectValue;

                        // verify comment exists
                        if(comment != null)
                        {
                            // Now create insertCommentProc from CommentWriter
                            // The DataWriter converts the 'Comment'
                            // to the SqlParameter[] array needed to insert a 'Comment'.
                            insertCommentProc = CommentWriter.CreateInsertCommentStoredProcedure(comment);
                        }

                        // Verify insertCommentProc exists
                        if(insertCommentProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.CommentManager.InsertComment(insertCommentProc, dataConnector);
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

            #region UpdateComment (Comment)
            /// <summary>
            /// This method updates a 'Comment' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Comment' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateComment(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Comment comment = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateCommentStoredProcedure updateCommentProc = null;

                    // verify the first parameters is a(n) 'Comment'.
                    if (parameters[0].ObjectValue as Comment != null)
                    {
                        // Create Comment Parameter
                        comment = (Comment) parameters[0].ObjectValue;

                        // verify comment exists
                        if(comment != null)
                        {
                            // Now create updateCommentProc from CommentWriter
                            // The DataWriter converts the 'Comment'
                            // to the SqlParameter[] array needed to update a 'Comment'.
                            updateCommentProc = CommentWriter.CreateUpdateCommentStoredProcedure(comment);
                        }

                        // Verify updateCommentProc exists
                        if(updateCommentProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.CommentManager.UpdateComment(updateCommentProc, dataConnector);

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
