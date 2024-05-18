using System;
using System.Collections.Generic;

namespace lb4;

public class Research
{
    public Customer Customer { get; private set; }
    public DateTime SignedDate { get; private set; }
    public List<Publication> Publications { get; private set; } = new();

    public Research()
    { }

    public Research(Customer customer, DateTime signedDate)
    {
        this.Customer = customer;
        this.SignedDate = signedDate;
    }

    public void AddPublication(Publication publication)
    {
        Publications.Add(publication);
    }

    public override string ToString()
    {
        return $"Customer: {this.Customer.OrganizationName} requested to research {this.Customer.ResearchTopic}\n" +
               $"Signed at: {SignedDate}\n" +
               $"Currently has: {Publications.Count} publication(s)";
    }

    public string ToShortString()
    {
        return $"Requested topic: {this.Customer.ResearchTopic}\n" +
               $"Has {Publications.Count} publication(s)";
    }
}