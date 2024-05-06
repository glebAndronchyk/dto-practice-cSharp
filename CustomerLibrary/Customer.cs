public class Customer
{
    public string OrganizationName { get; private set; }
    public string ResearchTopic { get; private set; }
    public int Price { get; private set; }

    public Customer(string organizationName, string researchTopic, int price)
    {
        if (price < 0)
        {
            throw new ArithmeticException("Price is negative");
        }

        OrganizationName = organizationName;
        ResearchTopic = researchTopic;
        Price = price;
    }
}