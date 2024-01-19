using CMS.Domain.Shared;

namespace CMS.Domain.Errors;

public static class DomainErrors
{
    public static class Client
    {
        public static readonly Error InvalidId = new("Client.InvalidId",
            "Their is no Client with this Id");

        public static readonly Error InvalidEmail = new("Client.InvalidEmail", 
            "Please Use Valid email format");

        public static readonly Error DuplicateEmail = new("Client.DuplicateEmail",
            "Email must be unique");
    }
}