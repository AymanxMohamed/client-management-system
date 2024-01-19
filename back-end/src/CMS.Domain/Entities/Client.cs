namespace CMS.Domain.Entities;

public class Client : Entity
{
    private Client(string name, string emailAddress, string phoneNumber, string homeAddress) : base(Guid.NewGuid())
    {
        Name = name;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        HomeAddress = homeAddress;
    }
    
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string HomeAddress { get; set; }


    public static Client Create(string name, string emailAddress, string phoneNumber, string homeAddress)
        => new(name, emailAddress, phoneNumber, homeAddress);

    public void Update(string name, string emailAddress, string phoneNumber, string homeAddress)
    {
        Name = name;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        HomeAddress = homeAddress;
    }
}