using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }


    public async Task<int> CreateClientAsync(AddClientForm form)
    {
        try
        {
            if (await _clientRepository.ExistsAsync(x => x.Email == form.Email))
                return 409;

            var newClient = new ClientEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Phone = form.Phone,
                Address = form.Address,
                DateOfBirth = form.DateOfBirth
            };

            await _clientRepository.AddAsync(newClient);

            return 200;
        }
        catch
        {
            return 500;
        }
    }

    public async Task<IEnumerable<ClientDto?>> GetAllClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();

        var statusDtos = entities.Select(ClientFactory.Create).Where(dto => dto != null).ToList();
        return statusDtos;
    }

    public async Task<ClientDto?> GetClientAsync(int id)
    {
        var entities = await _clientRepository.GetAsync(x => x.Id == id);
        if (entities == null)
            return null!;

        var clientDto = ClientFactory.Create(entities);
        return clientDto;
    }

    public async Task<bool> UpdateClientAsync(ClientUpdateDto form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var entity = ClientFactory.Create(form);
            if (entity == null)
                return false;

            var result = await _clientRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteClientAsync(Client client)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(client);

            var entity = await _clientRepository.GetAsync(x => x.Id == client.Id);

            if (entity == null)
                return false;

            var result = await _clientRepository.RemoveAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
