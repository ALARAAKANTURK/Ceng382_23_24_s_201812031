using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace LabProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

   
 
    public  IActionResult  OnGet()
    {
         string url = "http://localhost:5054/Identity/Account/Login" 
      + Request.Query["redirect_url"];

    return Redirect(url);

    }
}
