﻿namespace CMS.Domain.Entities;

public class Client : Entity
{
    public Client()
    {}
    private Client(Guid id, string name, string emailAddress, string phoneNumber, string homeAddress) : base(id)
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
        => new(Guid.NewGuid(), name, emailAddress, phoneNumber, homeAddress);
    public static Client Create(Guid id, string name, string emailAddress, string phoneNumber, string homeAddress)
        => new(id, name, emailAddress, phoneNumber, homeAddress);
    public void Update(string name, string emailAddress, string phoneNumber, string homeAddress)
    {
        Name = name;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        HomeAddress = homeAddress;
    }
}