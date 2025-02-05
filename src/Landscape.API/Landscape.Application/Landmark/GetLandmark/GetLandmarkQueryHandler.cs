using Dapper;
using Landscape.Application.Abstractions.Data;
using Landscape.Application.Abstractions.Messaging;
using Landscape.Domain.Abstractions;
using Landscape.Domain.Landmark;

namespace Landscape.Application.Landmark.GetLandmark;

internal sealed class GetLandmarkQueryHandler : IQueryHandler<GetLandmarkQuery, LandmarkResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetLandmarkQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<LandmarkResponse>> Handle(GetLandmarkQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        
        const string sql = $"""
                            SELECT
                                id AS Id,
                                description AS Description,
                                name AS Name,
                                state AS State,
                                park AS Park,
                                latitude AS Latitude,
                                longitude AS Longitude
                            FROM landmarks
                            WHERE id = @LandmarkId
                            """;

        var landmark = await connection.QueryFirstOrDefaultAsync<LandmarkResponse>(
            sql,
            new
            {
                request.LandmarkId
            });

        if (landmark is null )
        {
            return Result.Failure<LandmarkResponse>(LandmarkErrors.NotFound);
        }
        return landmark;
    }
}