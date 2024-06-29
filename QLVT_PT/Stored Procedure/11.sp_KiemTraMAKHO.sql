CREATE PROC [dbo].[sp_KiemTraMAKHO](@X int)
as

begin 
	DECLARE	@return_value int
	set @return_value=0
	if exists (SELECT MAKHO FROM dbo.Kho WHERE MAKHO=@X)
		set @return_value=1
	else if exists (SELECT MAKHO FROM LINK1.QLVT.dbo.KHO WHERE MAKHO=@X)
		set @return_value=1

	SELECT	'Return Value' = @return_value
end
GO


