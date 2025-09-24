namespace Food.Delivery.Store.Domain.ValueObjects;

public class Contato
{
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public Contato(string telefone, string email)
    {
        Telefone = telefone;
        Email = email;
    }
}
