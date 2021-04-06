Use [DataJuggler.Blazor.DataTier.Net]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Insert a new Comment
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_Insert >>>'

    End

GO

Create PROCEDURE Comment_Insert

    -- Add the parameters for the stored procedure here
    @Dislikes int,
    @Likes int,
    @Loves int,
    @MemberId int,
    @Removed bit,
    @ReplyToCommentId int,
    @Text nvarchar(2000),
    @Timestamp datetime,
    @VideoId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Comment]
    ([Dislikes],[Likes],[Loves],[MemberId],[Removed],[ReplyToCommentId],[Text],[Timestamp],[VideoId])

    -- Begin Values List
    Values(@Dislikes, @Likes, @Loves, @MemberId, @Removed, @ReplyToCommentId, @Text, @Timestamp, @VideoId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Update an existing Comment
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_Update >>>'

    End

GO

Create PROCEDURE Comment_Update

    -- Add the parameters for the stored procedure here
    @Dislikes int,
    @Id int,
    @Likes int,
    @Loves int,
    @MemberId int,
    @Removed bit,
    @ReplyToCommentId int,
    @Text nvarchar(2000),
    @Timestamp datetime,
    @VideoId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Comment]

    -- Update Each field
    Set [Dislikes] = @Dislikes,
    [Likes] = @Likes,
    [Loves] = @Loves,
    [MemberId] = @MemberId,
    [Removed] = @Removed,
    [ReplyToCommentId] = @ReplyToCommentId,
    [Text] = @Text,
    [Timestamp] = @Timestamp,
    [VideoId] = @VideoId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Comment
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_Find >>>'

    End

GO

Create PROCEDURE Comment_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Dislikes],[Id],[Likes],[Loves],[MemberId],[Removed],[ReplyToCommentId],[Text],[Timestamp],[VideoId]

    -- From tableName
    From [Comment]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Delete an existing Comment
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_Delete >>>'

    End

GO

Create PROCEDURE Comment_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Comment]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Comment objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_FetchAll >>>'

    End

GO

Create PROCEDURE Comment_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Dislikes],[Id],[Likes],[Loves],[MemberId],[Removed],[ReplyToCommentId],[Text],[Timestamp],[VideoId]

    -- From tableName
    From [Comment]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Insert a new Member
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_Insert >>>'

    End

GO

Create PROCEDURE Member_Insert

    -- Add the parameters for the stored procedure here
    @Active bit,
    @AdSpend float,
    @ChannelName nvarchar(256),
    @ChannelUrl nvarchar(80),
    @CreatedDate datetime,
    @Description nvarchar(2000),
    @Donations float,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @FirstName nvarchar(24),
    @IsAdmin bit,
    @LastLoginDate datetime,
    @LastName nvarchar(24),
    @Link1 nvarchar(256),
    @Link2 nvarchar(256),
    @Link3 nvarchar(256),
    @Location nvarchar(128),
    @PasswordHash nvarchar(255),
    @Premium bit,
    @PremiumExpires datetime,
    @ProfilePicture nvarchar(256),
    @PublicEmail bit,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Member]
    ([Active],[AdSpend],[ChannelName],[ChannelUrl],[CreatedDate],[Description],[Donations],[EmailAddress],[EmailVerified],[FirstName],[IsAdmin],[LastLoginDate],[LastName],[Link1],[Link2],[Link3],[Location],[PasswordHash],[Premium],[PremiumExpires],[ProfilePicture],[PublicEmail],[TotalLogins],[UserName])

    -- Begin Values List
    Values(@Active, @AdSpend, @ChannelName, @ChannelUrl, @CreatedDate, @Description, @Donations, @EmailAddress, @EmailVerified, @FirstName, @IsAdmin, @LastLoginDate, @LastName, @Link1, @Link2, @Link3, @Location, @PasswordHash, @Premium, @PremiumExpires, @ProfilePicture, @PublicEmail, @TotalLogins, @UserName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Update an existing Member
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_Update >>>'

    End

GO

Create PROCEDURE Member_Update

    -- Add the parameters for the stored procedure here
    @Active bit,
    @AdSpend float,
    @ChannelName nvarchar(256),
    @ChannelUrl nvarchar(80),
    @CreatedDate datetime,
    @Description nvarchar(2000),
    @Donations float,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @FirstName nvarchar(24),
    @Id int,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @LastName nvarchar(24),
    @Link1 nvarchar(256),
    @Link2 nvarchar(256),
    @Link3 nvarchar(256),
    @Location nvarchar(128),
    @PasswordHash nvarchar(255),
    @Premium bit,
    @PremiumExpires datetime,
    @ProfilePicture nvarchar(256),
    @PublicEmail bit,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Member]

    -- Update Each field
    Set [Active] = @Active,
    [AdSpend] = @AdSpend,
    [ChannelName] = @ChannelName,
    [ChannelUrl] = @ChannelUrl,
    [CreatedDate] = @CreatedDate,
    [Description] = @Description,
    [Donations] = @Donations,
    [EmailAddress] = @EmailAddress,
    [EmailVerified] = @EmailVerified,
    [FirstName] = @FirstName,
    [IsAdmin] = @IsAdmin,
    [LastLoginDate] = @LastLoginDate,
    [LastName] = @LastName,
    [Link1] = @Link1,
    [Link2] = @Link2,
    [Link3] = @Link3,
    [Location] = @Location,
    [PasswordHash] = @PasswordHash,
    [Premium] = @Premium,
    [PremiumExpires] = @PremiumExpires,
    [ProfilePicture] = @ProfilePicture,
    [PublicEmail] = @PublicEmail,
    [TotalLogins] = @TotalLogins,
    [UserName] = @UserName

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Member
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_Find >>>'

    End

GO

Create PROCEDURE Member_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[AdSpend],[ChannelName],[ChannelUrl],[CreatedDate],[Description],[Donations],[EmailAddress],[EmailVerified],[FirstName],[Id],[IsAdmin],[LastLoginDate],[LastName],[Link1],[Link2],[Link3],[Location],[PasswordHash],[Premium],[PremiumExpires],[ProfilePicture],[PublicEmail],[TotalLogins],[UserName]

    -- From tableName
    From [Member]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Delete an existing Member
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_Delete >>>'

    End

GO

Create PROCEDURE Member_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Member]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Member objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_FetchAll >>>'

    End

GO

Create PROCEDURE Member_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[AdSpend],[ChannelName],[ChannelUrl],[CreatedDate],[Description],[Donations],[EmailAddress],[EmailVerified],[FirstName],[Id],[IsAdmin],[LastLoginDate],[LastName],[Link1],[Link2],[Link3],[Location],[PasswordHash],[Premium],[PremiumExpires],[ProfilePicture],[PublicEmail],[TotalLogins],[UserName]

    -- From tableName
    From [Member]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Tags_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Insert a new Tags
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Tags_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Tags_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Tags_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Tags_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Tags_Insert >>>'

    End

GO

Create PROCEDURE Tags_Insert

    -- Add the parameters for the stored procedure here
    @Tag nvarchar(40),
    @VideoId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Tags]
    ([Tag],[VideoId])

    -- Begin Values List
    Values(@Tag, @VideoId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Tags_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Update an existing Tags
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Tags_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Tags_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Tags_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Tags_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Tags_Update >>>'

    End

GO

Create PROCEDURE Tags_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @Tag nvarchar(40),
    @VideoId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Tags]

    -- Update Each field
    Set [Tag] = @Tag,
    [VideoId] = @VideoId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Tags_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Tags
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Tags_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Tags_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Tags_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Tags_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Tags_Find >>>'

    End

GO

Create PROCEDURE Tags_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Tag],[VideoId]

    -- From tableName
    From [Tags]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Tags_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Delete an existing Tags
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Tags_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Tags_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Tags_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Tags_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Tags_Delete >>>'

    End

GO

Create PROCEDURE Tags_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Tags]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Tags_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Tags objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Tags_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Tags_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Tags_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Tags_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Tags_FetchAll >>>'

    End

GO

Create PROCEDURE Tags_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Tag],[VideoId]

    -- From tableName
    From [Tags]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Insert a new Video
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_Insert >>>'

    End

GO

Create PROCEDURE Video_Insert

    -- Add the parameters for the stored procedure here
    @Active bit,
    @Banned bit,
    @DateCreated datetime,
    @Dislikes int,
    @Flagged int,
    @Likes int,
    @MemberId int,
    @Name nvarchar(80),
    @VideoUrl nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Video]
    ([Active],[Banned],[DateCreated],[Dislikes],[Flagged],[Likes],[MemberId],[Name],[VideoUrl])

    -- Begin Values List
    Values(@Active, @Banned, @DateCreated, @Dislikes, @Flagged, @Likes, @MemberId, @Name, @VideoUrl)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Update an existing Video
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_Update >>>'

    End

GO

Create PROCEDURE Video_Update

    -- Add the parameters for the stored procedure here
    @Active bit,
    @Banned bit,
    @DateCreated datetime,
    @Dislikes int,
    @Flagged int,
    @Id int,
    @Likes int,
    @MemberId int,
    @Name nvarchar(80),
    @VideoUrl nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Video]

    -- Update Each field
    Set [Active] = @Active,
    [Banned] = @Banned,
    [DateCreated] = @DateCreated,
    [Dislikes] = @Dislikes,
    [Flagged] = @Flagged,
    [Likes] = @Likes,
    [MemberId] = @MemberId,
    [Name] = @Name,
    [VideoUrl] = @VideoUrl

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Video
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_Find >>>'

    End

GO

Create PROCEDURE Video_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[Banned],[DateCreated],[Dislikes],[Flagged],[Id],[Likes],[MemberId],[Name],[VideoUrl]

    -- From tableName
    From [Video]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Delete an existing Video
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_Delete >>>'

    End

GO

Create PROCEDURE Video_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Video]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Video objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_FetchAll >>>'

    End

GO

Create PROCEDURE Video_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[Banned],[DateCreated],[Dislikes],[Flagged],[Id],[Likes],[MemberId],[Name],[VideoUrl]

    -- From tableName
    From [Video]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_FindByEmailAddress
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Member for the EmailAddress given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_FindByEmailAddress'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_FindByEmailAddress

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_FindByEmailAddress') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_FindByEmailAddress >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_FindByEmailAddress >>>'

    End

GO

Create PROCEDURE Member_FindByEmailAddress

    -- Create @EmailAddress Paramater
    @EmailAddress nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[AdSpend],[ChannelName],[ChannelUrl],[CreatedDate],[Description],[Donations],[EmailAddress],[EmailVerified],[FirstName],[Id],[IsAdmin],[LastLoginDate],[LastName],[Link1],[Link2],[Link3],[Location],[PasswordHash],[Premium],[PremiumExpires],[ProfilePicture],[PublicEmail],[TotalLogins],[UserName]

    -- From tableName
    From [Member]

    -- Find Matching Record
    Where [EmailAddress] = @EmailAddress

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Member_FindByUserName
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Find an existing Member for the UserName given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Member_FindByUserName'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Member_FindByUserName

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Member_FindByUserName') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Member_FindByUserName >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Member_FindByUserName >>>'

    End

GO

Create PROCEDURE Member_FindByUserName

    -- Create @UserName Paramater
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[AdSpend],[ChannelName],[ChannelUrl],[CreatedDate],[Description],[Donations],[EmailAddress],[EmailVerified],[FirstName],[Id],[IsAdmin],[LastLoginDate],[LastName],[Link1],[Link2],[Link3],[Location],[PasswordHash],[Premium],[PremiumExpires],[ProfilePicture],[PublicEmail],[TotalLogins],[UserName]

    -- From tableName
    From [Member]

    -- Find Matching Record
    Where [UserName] = @UserName

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Comment_FetchAllForVideoId
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Comment objects for the VideoId given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Comment_FetchAllForVideoId'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Comment_FetchAllForVideoId

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Comment_FetchAllForVideoId') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Comment_FetchAllForVideoId >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Comment_FetchAllForVideoId >>>'

    End

GO

Create PROCEDURE Comment_FetchAllForVideoId

    -- Create @VideoId Paramater
    @VideoId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Dislikes],[Id],[Likes],[Loves],[MemberId],[Removed],[ReplyToCommentId],[Text],[Timestamp],[VideoId]

    -- From tableName
    From [Comment]

    -- Load Matching Records
    Where [VideoId] = @VideoId

    -- Order by Timestamp in descending order
    Order By [Timestamp] desc

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Video_FetchAllForMemberId
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   4/3/2021
-- Description:    Returns all Video objects for the MemberId given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Video_FetchAllForMemberId'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Video_FetchAllForMemberId

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Video_FetchAllForMemberId') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Video_FetchAllForMemberId >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Video_FetchAllForMemberId >>>'

    End

GO

Create PROCEDURE Video_FetchAllForMemberId

    -- Create @MemberId Paramater
    @MemberId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[Banned],[DateCreated],[Dislikes],[Flagged],[Id],[Likes],[MemberId],[Name],[VideoUrl]

    -- From tableName
    From [Video]

    -- Load Matching Records
    Where [MemberId] = @MemberId

    -- Order by DateCreated in descending order
    Order By [DateCreated] desc

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

