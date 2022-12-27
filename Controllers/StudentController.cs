using AttendanceApi.Data.Services;
using AttendanceApi.Data.ViewModels.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly StudentService _studentService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public StudentController(StudentService service, IWebHostEnvironment environment)
    {
	 _studentService = service;
	 _webHostEnvironment = environment;
    }

    [HttpGet(template: "get-all-students/{className}")]
    public IActionResult GetStudents(string className)
    {
	 var list = _studentService.GetStudentByClass(className);
	 var responseList = new List<StudentsWithImagesViewModel>();
	 foreach (var student in list)
	 {
	   responseList.Add(new StudentsWithImagesViewModel(student, GetImageByStudentRegNo(student.Regno)));
	 }
	 return Ok(responseList);
    }

    [NonAction]
    private string GetFilePath(string regNo)
    {
	 return this._webHostEnvironment.WebRootPath + "\\uploads\\" + regNo;
    }

    [NonAction]
    private string GetImageByStudentRegNo(string regNo)
    {
	 string imageURL = string.Empty;
	 string hostURL = "http://192.168.100.12:7049";
	 string filePath = GetFilePath(regNo);
	 string imagePath = filePath + "\\Front.jpg";
	 if (System.IO.File.Exists(imagePath))
	 {
	   imageURL = hostURL + $"/uploads/{regNo}/Front.jpg";
	 }
	 return imageURL;
    }
  }
}