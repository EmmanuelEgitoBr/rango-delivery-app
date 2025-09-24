namespace Food.Delivery.Store.Domain.ValueObjects;

public class HorarioDiario
{
    public DayOfWeek DiaDaSemana { get; private set; }
    public TimeSpan HoraAbertura { get; private set; }
    public TimeSpan HoraFechamento { get; private set; }
    public HorarioDiario(DayOfWeek diaDaSemana, TimeSpan horaAbertura, TimeSpan horaFechamento)
    {
        if (horaFechamento <= horaAbertura)
            throw new ArgumentException("Hora de fechamento deve ser maior que hora de abertura.");
        DiaDaSemana = diaDaSemana;
        HoraAbertura = horaAbertura;
        HoraFechamento = horaFechamento;
    }
}
