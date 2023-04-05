IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[PARAGELIA]')) 
   ALTER TABLE [dbo].[PARAGELIA] 
   ENABLE  CHANGE_TRACKING
GO
