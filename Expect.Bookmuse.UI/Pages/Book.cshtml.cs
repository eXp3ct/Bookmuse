using Expect.Bookmuse.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Expect.Bookmuse.UI.Pages
{
    public class BookModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "id")] public Guid BookId { get; set; }
		[BindProperty] public Book Book { get; set; }
        public async Task OnGetAsync()
        {
			var clientHandler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
			};
			using var client = new HttpClient(clientHandler);
			using var response = await client.GetAsync($"https://main-service:443/getbook/{BookId}");

			var responseString = await response.Content.ReadAsStringAsync();

			if (string.IsNullOrEmpty(responseString))
				return;

			Book = JsonConvert.DeserializeObject<OperationResultTest1>(responseString)?.Data;
		}
    }
}
