namespace Food.Delivery.Store.Domain.ValueObjects;

public class HorarioFuncionamento
{
    public ICollection<HorarioDiario> Horarios { get; private set; } = [];
}
