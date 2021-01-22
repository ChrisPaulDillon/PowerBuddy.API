using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PowerBuddy.AuthenticationService.Configuration;
using PowerBuddy.AuthenticationService.Models;

namespace PowerBuddy.AuthenticationService
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token={0}";

        private readonly IFacebookConfig _facebookConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public FacebookAuthService(IFacebookConfig facebookConfig, IHttpClientFactory httpClientFactory)
        {
            _facebookConfig = facebookConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formattedUrl = string.Format(TokenValidationUrl, accessToken, _facebookConfig.AppId, _facebookConfig.AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            try
            {
                result.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw;
            }

            var responseStr = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseStr);
        }

        public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var formattedUrl = string.Format(UserInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);

            try
            {
                result.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw;
            }

            var responseStr = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseStr);
        }
    }
}
