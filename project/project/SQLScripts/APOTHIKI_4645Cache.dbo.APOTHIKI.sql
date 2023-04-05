IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[APOTHIKI]')) 
   ALTER TABLE [dbo].[APOTHIKI] 
   ENABLE  CHANGE_TRACKING
GO
