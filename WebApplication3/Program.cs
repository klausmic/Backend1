using WebApplication3.Data;
using WebApplication3.Models;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var markets = new[]
{
    "Sales Representative", "Paper Advertisement"
};

app.MapGet("/markets", async () =>
{
    await using var context = new HasContext();
    var marketsFromDb = context.Markets.Where(m => m.isActive).Select(s => new
    {
        MarketId = s.MarketId,
        MarketCode = s.MarketCode,
        MarketName = s.MarketName
    }).ToList();

    return marketsFromDb;
});

app.MapGet("/contacts", async () =>
{
    await using var context = new HasContext();
    var contactsFromDb = context.Contacts.Where(n => n.IsClosed).Select(s => new
    {
        ContactId = s.ContactId,
        MarketId = s.MarketId,
        Name = s.Name,
        MobileNumber = s.MobileNumber,
        Email = s.Email,
        Address = s.Address,
        CreatedTimestamp = s.CreatedTimestamp,
        Note = s.Note,

    }).ToList();

    return contactsFromDb;
});

app.MapGet("/markets/{marketId}", async (int marketId) =>
{
    await using var context = new HasContext();
    var market = context.Markets.Where(m => m.MarketId.Equals(marketId)).FirstOrDefault();
    return Results.Ok(market);
});

app.MapGet("/contacts/{ContactId}", async (int ContactId) =>
{
    await using var context = new HasContext();
    var contact = context.Contacts.Where(m => m.ContactId.Equals(ContactId)).FirstOrDefault();
    return Results.Ok(contact);
});

app.MapPost("/markets", async (MarketModel newMarketModel) =>
{
    await using var context = new HasContext();

    Market newMarket = new()
    {
        MarketCode = newMarketModel.MarketCode,
        MarketName = newMarketModel.MarketName,
        isActive = true
    };

    context.Add(newMarket);
    await context.SaveChangesAsync();
    return Results.Created($"https://localhost:7223/markets/{newMarket.MarketId}", newMarket);

});

app.MapPost("/contacts", async (ContactModel newContactModel) =>
{
    await using var context = new HasContext();
    Contact newContact = new()
    {
        MarketId = newContactModel.MarketId,
        Name = newContactModel.Name,
        MobileNumber = newContactModel.MobileNumber,
        Email = newContactModel.Email,
        Address = newContactModel.Address,
        CreatedTimestamp = newContactModel.CreatedTimestamp,
        Note = newContactModel.Note
    };
    context.Add(newContact);
    await context.SaveChangesAsync();
    return Results.Created($"https://localhost:7223/contacts/{newContact.ContactId}", newContact);
});


app.Run();
    