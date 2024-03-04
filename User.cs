namespace FrontEndAPI;

public record User
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }

}

public record Address
{
    public required string Street { get; set; }
    public required string Suite { get; set; }
    public required string City { get; set; }
    public required string Zipcode { get; set; }
    public Geo? Geo { get; set; }
}

public record Geo
{
    public required string Lat { get; set; }
    public required string Lng { get; set; }
}

public record ToDo
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}
