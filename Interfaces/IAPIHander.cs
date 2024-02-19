using HackerNewsAPI.Models;

namespace HackerNewsAPI.Interfaces
{
    public interface IAPIHander
    {
        Task<List<string>>? GetAllStory();
        Task<IEnumerable<Story>>? GetStoryById(string? id);
    }
}
