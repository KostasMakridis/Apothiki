IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[PELATHS]')) 
   ALTER TABLE [dbo].[PELATHS] 
   ENABLE  CHANGE_TRACKING
GO
