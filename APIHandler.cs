using HackerNewsAPI.Interfaces;
using HackerNewsAPI.Models;
using Newtonsoft.Json;

namespace HackerNewsAPI
{
    public class APIHandler : IAPIHander
    {
        private readonly HttpClient httpClient;
        private readonly string? serviceUrl;
        private readonly string? allStory;
        private readonly IConfiguration configuration;
        private readonly ILogger<APIHandler> logger;
        public APIHandler(IConfiguration _configuration, ILogger<APIHandler> _logger)
        {
            httpClient = new HttpClient();
            configuration = _configuration;
            serviceUrl = _configuration.GetSection("ServiceUrl").Get<string>();
            allStory = _configuration.GetSection("GetStories").Get<string>();
            logger = _logger;
        }


        public async Task<IEnumerable<Story>> GetStoryById(string? id)
        {
            string apiUrl = string.Format(serviceUrl, id);

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var convertedValue = content == "null" ? null : content;

                    if (!string.IsNullOrWhiteSpace(convertedValue))
                    {
                        Story? story = JsonConvert.DeserializeObject<Story>(convertedValue);

                        // Adding a Story object to the list
                        List<Story>? storiesList = new List<Story>();
                        storiesList?.Add(story);
                        IEnumerable<Story>? storiesEnumerable = storiesList;

                        return storiesEnumerable;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to execute the API, Please try again");
                throw ex;

            }
        }

        public async Task<List<string>> GetAllStory()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(allStory);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var convertedValue = content == "null" ? null : content;

                    if (!string.IsNullOrWhiteSpace(convertedValue))
                    {
                        var data = JsonConvert.DeserializeObject<List<String>>(convertedValue);
                        return data;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to execute the API, Please try again");
                throw ex;
            }
        }
    }

}
