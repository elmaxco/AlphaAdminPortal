using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IClientService
{
    Task<int> CreateClientAsync(AddClientForm form);
    Task<bool> DeleteClientAsync(Client client);
    Task<ClientDto?> GetClientAsync(int id);
    Task<IEnumerable<ClientDto?>> GetAllClientsAsync();
    Task<bool> UpdateClientAsync(ClientUpdateDto form);
}
