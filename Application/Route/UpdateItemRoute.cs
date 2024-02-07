using Microsoft.AspNetCore.Mvc;

namespace Application.Routes
{
    public class UpdateItemRoute
    {
        [FromRoute(Name = "id")] public int Id { get; set; }
    }
}
