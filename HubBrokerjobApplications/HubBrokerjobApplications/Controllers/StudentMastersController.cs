using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HubBrokerjobApplications.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HubBrokerjobApplications.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMastersController : Controller
    {
        private readonly HubJobsContext _context;
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public StudentMastersController(HubJobsContext context)
        {
            _context = context;
        }

        [HttpGet("getapplicationList")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeList()
        {
            {
                try
                {
                    var Emp = (from sm in _context.StudentMaster
                               join dm in _context.Documents
                               on sm.JobId equals dm.DocId

                               select new Employee()
                               {
                                   StuId = sm.StuId,
                                   FullName = sm.FirstName + " " + sm.LastName,
                                   EmailAddress = sm.EmailAddress,
                                   MobileNo = sm.MobileNo,
                                   DocumentType = dm.DocumentType,


                               }).ToListAsync();
                    var emp = await Emp;
                    if (emp.Count > 0)
                    {
                        return Ok(emp);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                catch (Exception ex) { throw ex; }
            }


        }
        [HttpPost("postStudentData")]
        public async Task<ActionResult<StudentMaster>> PostStudentMaster(StudentMaster studentMaster)


        {

            try
            {

                _context.StudentMaster.Add(studentMaster);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("allVacancy")]
        public async Task<ActionResult<IEnumerable<CompanyMaster>>> GetCompanyMaster()

        {
            try
            {
                var DmCount = _context.CompanyMaster.Count();
                if (DmCount > 0)
                {
                    return await _context.CompanyMaster.ToListAsync();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        [HttpGet]
        [HttpGet("getstudentList")]

        public async Task<ActionResult<IEnumerable<StudentMaster>>> GettudentMaster()

        {
            try
            {
                var DmCount = _context.StudentMaster.Count();
                if (DmCount > 0)
                {
                    return await _context.StudentMaster.ToListAsync();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        [HttpGet("allDococment")]
        public async Task<ActionResult<IEnumerable<Documents>>> GetDocument()

        {
            try
            {
                var DmCount = _context.Documents.Count();
                if (DmCount > 0)
                {
                    return await _context.Documents.ToListAsync();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        [HttpPost("uploaddoc")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                List<Documents> document = new List<Documents>();
                foreach (var file in files)
                {
                    Documents documents = new Documents();
                    using (var stream = file.OpenReadStream())
                    {
                        documents.DocuentName = file.FileName;
                        documents.DocumentType = file.ContentType;
                        using (var reader = new StreamReader(stream))
                        {
                            documents.DocumentContent = reader.ReadToEnd();
                        }

                    }
                    document.Add(documents);
                }
                _context.Documents.AddRange(document);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Download")]
        public async Task<IActionResult> DownloadFile(int DocId)
        {
            if (!Directory.Exists(AppDirectory))
               Directory.CreateDirectory(AppDirectory);
            var file = _context.Documents.Where(x => x.DocId == DocId).FirstOrDefault();
            var path = Path.Combine(AppDirectory,file?.DocumentContent);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path,FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ContentType = "Application/octet-stream";
            var fileName = Path.GetFileName(path);
            return File(memory, ContentType);

        }
    }
}

