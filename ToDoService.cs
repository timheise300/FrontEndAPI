namespace FrontEndAPI;

public interface IToDoService
{ 
    Task<User> GetUser(string userName);
    Task<List<ToDo>> GetToDoList(int id);

}

public class ToDoService(IHttpClientFactory httpClientFactory) : IToDoService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

    public async Task<User> GetUser(string userName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users/");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{(int)response.StatusCode}: Error invoking User API");
        }

        User user = (await response.Content.ReadFromJsonAsync<List<User>>())!
            .FirstOrDefault(user => user.Username == userName)!;

        return user;
    }

    public async Task<List<ToDo>> GetToDoList(int id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{(int)response.StatusCode}: Error invoking Todo API");
        }

        return await response.Content.ReadFromJsonAsync<List<ToDo>>() ?? [];
    }
}
