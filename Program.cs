
using ReverseEnginereeingEF.Data;
using ReverseEnginereeingEF.Models;

using NADLANContext context = new NADLANContext();
//context.Database.EnsureCreated(); // Using Cosmos DB

Country Israel = new Country()
{
    CountryName = "Israel",
    Alpha2Code = "IL",
    Alpha3Code = "ISL",
    Numeric = "376",
};
Country Germany = new Country()
{
    CountryName = "Germany",
    Alpha2Code = "DU",
    Alpha3Code = "DEU",
    Numeric = "276",
};

context.Countries.AddRange(Germany,Israel);
context.SaveChanges();