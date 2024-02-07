using Microsoft.AspNetCore.Mvc;

namespace Application.Routes
{
    public class DeleteItemRoute
    {
        [FromRoute(Name ="id")] public int Id { get; set; }
    }
}
