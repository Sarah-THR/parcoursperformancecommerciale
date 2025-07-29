using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class ContractReadRepository : IContractReadRepository
    {
        private readonly BiContext _biContext;

        public ContractReadRepository(BiContext biContext)
        {
            _biContext = biContext;
        }

        public async Task<List<EcolePerformanceSm>> GetContractByUserNameAsync(string commercial)
        {
            return await _biContext.EcolePerformanceSms.Where(x => x.Commercial == commercial).ToListAsync();
        }

        public async Task<int> GetNbContractByUserNameAsync(string commercial, DateOnly startDate, DateOnly endDate)
        {
            var contracts = await _biContext.EcolePerformanceNewContrats.Where(x => x.Commercial == commercial && x.DateContrat >= startDate && x.DateContrat <= endDate).ToListAsync();
            return contracts.Count;
        }

        public async Task<List<VenteOneShot>> GetContractSaleByUserNameAsync(string commercial)
        {
            string connectionString = "Server=XFISRVSQL002; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";
            //string connectionString = "Server=XFISRVSQLPREPROD; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";//PREPROD
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery = $"select * from XFISRVSQL004.BI.dbo.ecole_performance_vente_one_shot WHERE co_nom = '{commercial}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    List<VenteOneShot> contractsDataList = new List<VenteOneShot>();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            VenteOneShot contractsData = new VenteOneShot
                            {
                                do_date = DateOnly.FromDateTime((DateTime)reader["do_date"]),
                                co_nom = reader["co_nom"].ToString(),
                                nb = Convert.ToInt32(reader["nb"]),
                            };

                            contractsDataList.Add(contractsData);
                        }
                    }

                    return contractsDataList;
                }
            }
        }

        public async Task<List<NexleaseContract>> GetContractNexleaseByUserNameAsync(string commercial)
        {
            string connectionString = "Server=XFISRVSQL002; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";
            //string connectionString = "Server=XFISRVSQLPREPROD; Database=BI;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";//PREPROD
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery = $"select * from XFISRVSQL004.BI.dbo.ecole_performance_location_NEXLEASE WHERE co_nom = '{commercial}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    List<NexleaseContract> contractsDataList = new List<NexleaseContract>();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            NexleaseContract contractsData = new NexleaseContract
                            {
                                do_date = DateOnly.FromDateTime((DateTime)reader["do_date"]),
                                co_nom = reader["co_nom"].ToString(),
                                nb = Convert.ToInt32(reader["nb"]),
                            };

                            contractsDataList.Add(contractsData);
                        }
                    }

                    return contractsDataList;
                }
            }
        }
    }
}
