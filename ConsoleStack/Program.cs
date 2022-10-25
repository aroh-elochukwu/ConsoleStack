public abstract class Client
{
    private string Name { get; set; }
    private string Email { get; set; }
    private int? Age { get; set; }
    public bool AccessDisabled { get; set; }
    public AccessHandler AccessHandler { get; set; }
    public Client(string name , string email, int? age, bool accessDisabled)
    {
        Name = name;
        Email = email;
        Age = age;
        AccessDisabled = accessDisabled;

    }

    public virtual void HandleAccess()
    {
        AccessHandler.GetAccess(null, AccessDisabled);
    }

}

public class User: Client
{
    private int Id { get; set; }
    private int Value { get; set; }
    private int Reputation   { get; set; }
    public User(string name, string email, int? age, bool accessDisabled, int reputation): base(name, email, age, accessDisabled)
    {
        Reputation = reputation;
        AccessHandler = new HasReputation();

    }


}

public class Manager : Client
{
    public Manager(string name, string email, int? age, bool accessDisabled)
        : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }

}

public class Admin : Client
{
    public Admin(string name, string email, int? age, bool accessDisabled)
        : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }

}

public interface AccessHandler
{
    public bool GetAccess(int? Reputation = 0, bool AccessDiabled = false);
        
    
}

public class HasReputation : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return reputation != null && reputation > 20;
    }    

}



public class HasAccessAutomatic : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return !accessDisabled;
    }


}