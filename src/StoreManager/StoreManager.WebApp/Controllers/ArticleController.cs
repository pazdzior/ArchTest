using Microsoft.AspNetCore.Mvc;
using StoreManager.Repository;
using StoreManager.Services;

namespace StoreManager.WebApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ArticleController : Controller
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetArticles()
    {
        var result = _articleService.GetArticles();
        return Ok(result);
    }
}