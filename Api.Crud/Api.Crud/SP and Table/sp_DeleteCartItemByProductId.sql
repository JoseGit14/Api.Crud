CREATE PROCEDURE [dbo].[sp_DeleteCartItemByProductId]
(
	@CartId int,
	@ProductId int
)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM ProductCart WHERE CartId = @CartId AND ProductId = @ProductId)
		BEGIN
			DELETE FROM ProductCart WHERE CartId = @CartId AND ProductId = @ProductId

			SELECT CONVERT(BIT, 1) Result
		END
	ELSE
		SELECT 400 StatusCode, 'Cart/Product does not exist' StatusMessage
END