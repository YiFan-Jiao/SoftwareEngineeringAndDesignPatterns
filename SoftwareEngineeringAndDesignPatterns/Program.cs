using System;

abstract class Client
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Description { get; protected set; }

    public virtual string GetDescription()
    {
        return Description;
    }

    public virtual string GetBadges()
    {
        return ""; 
    }
}


class User : Client
{
    public User()
    {
        Description = "Base-level User";
    }
}


abstract class BadgeDecorator : Client
{
    protected Client decoratedClient;

    public BadgeDecorator(Client client)
    {
        decoratedClient = client;
    }

    public override string GetBadges()
    {
        return decoratedClient.GetBadges();
    }
}


class SilverBadgeDecorator : BadgeDecorator
{
    public SilverBadgeDecorator(Client client) : base(client) { }

    public override string GetBadges()
    {
        return decoratedClient.GetBadges() + " Silver Badge";
    }

    public override string GetDescription()
    {
        return decoratedClient.GetDescription();
    }
}

class GoldBadgeDecorator : BadgeDecorator
{
    public GoldBadgeDecorator(Client client) : base(client) { }

    public override string GetBadges()
    {
        return decoratedClient.GetBadges() + " Gold Badge";
    }

    public override string GetDescription()
    {
        return decoratedClient.GetDescription();
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        Console.WriteLine("User Description: " + user.GetDescription());

        SilverBadgeDecorator silverBadgeUser = new SilverBadgeDecorator(user);
        Console.WriteLine("User Description with Silver Badge: " + silverBadgeUser.GetDescription());
        Console.WriteLine("Badges: " + silverBadgeUser.GetBadges());

        GoldBadgeDecorator goldBadgeUser = new GoldBadgeDecorator(user);
        Console.WriteLine("User Description with Gold Badge: " + goldBadgeUser.GetDescription());
        Console.WriteLine("Badges: " + goldBadgeUser.GetBadges());
    }
}
