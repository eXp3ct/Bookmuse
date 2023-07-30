using Expect.Bookmuse.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Expect.Bookmuse.UI.Pages
{
    public class BooksListModel : PageModel
    {
        [BindProperty] public List<Book> Books { get; set; } = new();
        [BindProperty] public string BookPageBaseUrl {get; private set;} = "/book/";
        public async Task OnGetAsync()
        {
			//https://localhost:53991/getbooks?page=0&pageSize=10
			//https://main-service:443/getbooks?page=0&pageSize=100
			using var clientHandler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
			};
			using var client = new HttpClient(clientHandler);
            using var response = await client.GetAsync("https://main-service:443/getbooks?page=1&pageSize=100");
            var responseString = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(responseString))
                return;

            Books = JsonConvert.DeserializeObject<OperationResultTest>(responseString)?.Data;
        }

        public async Task<IActionResult> OnPostBuyBookAsync(Guid id)
        {
			using var clientHandler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
			};
			using var client = new HttpClient(clientHandler);
            var content = new HttpRequestMessage(HttpMethod.Post,"https://main-service:443/buybook")
            {
                Content = new StringContent($"id:{id}", System.Text.Encoding.UTF8, "application/json")
            };
            using var response = await client.SendAsync(content);

            return RedirectToPage();
		}
    }
}
