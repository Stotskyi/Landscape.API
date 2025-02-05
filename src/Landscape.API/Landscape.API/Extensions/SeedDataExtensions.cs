using Bogus;
using Dapper;
using Landscape.Application.Abstractions.Data;

namespace Landscape.API.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> landmarks = new();
        for (var i = 0; i < 100; i++)
        {
            landmarks.Add(new
            {
            
            });
        }

        const string sql = $"""
                            INSERT INTO public.apartments
                            (id, "name", description, address_country, address_state, address_zip_code, address_city, address_street, price_amount, price_currency, cleaning_fee_amount, cleaning_fee_currency, amenities, last_booked_on_utc)
                            VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @Amenities, @LastBookedOn);
                            """;

        var rersponse = connection.Execute(sql, landmarks);
    }
}