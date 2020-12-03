
CREATE FUNCTION [Url].[udf_CalculateTotalRedirectCount]
(
    @id int
)
RETURNS BIGINT
AS
BEGIN
	declare @result bigint=(select ISNULL(SUM(RedirectCount),0) from [Url].ShortCode where UrlId=@id);
    return @result;

END
