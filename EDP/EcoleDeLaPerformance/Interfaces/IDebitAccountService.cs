namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IDebitAccountService
    {
        Task<int> GetDebitAccountByCommercialNameAsync(string name);
        Task<int> GetDebitAccountByPeriodAsync(string name, DateOnly periodFirstDay, DateOnly periodLastDay);
    }
}
