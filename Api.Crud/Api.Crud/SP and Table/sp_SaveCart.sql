CREATE PROCEDURE [dbo].[sp_SaveCart]-- 1, 2, 3, 'Test sp'
(
	@CartId int,
	@TotalAmount money,
	@Cash money,
	@ChangeCash money,
	@CreatedBy nvarchar(50)
)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM SavedCart WHERE CartId = @CartId)
		BEGIN
			INSERT INTO SavedCart(CartId, TotalAmount, Cash, ChangeCash, CreatedDate, CreatedBy)
			VALUES(@CartId, @TotalAmount, @Cash, @ChangeCash, GETDATE(), @CreatedBy)
			
			SELECT CONVERT(BIT, 1) Result
		END
	ELSE
		SELECT 400 StatusCode, 'Something went wrong' StatusMessage
END