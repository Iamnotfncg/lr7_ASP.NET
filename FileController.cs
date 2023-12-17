// FileController.cs
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

public class FileController : Controller
{
    [Route("file")]
    public IActionResult DownloadFile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DownloadFile(string firstName, string lastName, string fileName)
    {
        // Перевірка наявності обов'язкових даних
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(fileName))
        {
            ViewBag.Error = "Будь ласка, заповніть всі поля форми.";
            return View();
        }

        return Json(new { FileUrl = Url.Action("Download", new { fileName = fileName + ".txt" }) });
    }

    public IActionResult Download(string fileName)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName);
        return PhysicalFile(filePath, "text/plain", fileName);
    }
}
