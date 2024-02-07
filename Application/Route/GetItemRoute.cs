using Microsoft.AspNetCore.Mvc;

namespace Application.Routes
{
    public class GetItemRoute
    {
        [FromRoute(Name = "id")] public int Id { get; set; }
    }
}
