#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    //log.LogInformation("C# HTTP trigger function processed a request.");

    string email = req.Query["email"];
    string domain = req.Query["domain"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    email = email ?? data?.email;
    domain = domain ?? data?.domain;
    
    var emaildomain = email.Split('@').Last();

    if (domain != emaildomain)
        {
            email = email.Replace('@' + emaildomain,'_' + emaildomain + "#ext#@blabla.onmicrosoft.com"); 
        }

    return new OkObjectResult(email);
}
