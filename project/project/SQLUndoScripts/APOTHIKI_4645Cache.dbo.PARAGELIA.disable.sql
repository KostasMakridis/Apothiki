IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[PARAGELIA]')) 
   ALTER TABLE [dbo].[PARAGELIA] 
   DISABLE  CHANGE_TRACKING
GO
