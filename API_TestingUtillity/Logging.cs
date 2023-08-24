using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API_TestingUtillity
{
    public class Logging
    {
        public async Task LoginAsync()
        {

           // string baseUrl = "https://your-api-url"; // Replace with your API URL

            // ... Authenticate and obtain JWT token as shown before

            // Use the obtained JWT token to access protected endpoints
          //  await AccessProtectedEndpointAsync(baseUrl, token);
        }
        static async Task AccessProtectedEndpointAsync(string baseUrl, string token)
        {
            using (var httpClient = new HttpClient())
            {
                // Set the Authorization header with the token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync($"{baseUrl}/api/protected");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
        }
    }
}
