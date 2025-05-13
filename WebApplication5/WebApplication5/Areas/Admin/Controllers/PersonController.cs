
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Contexts;
using WebApplication5.Models.Concretes;

namespace WebApplication5.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles ="Admin")]
public class PersonController : Controller
{
    AppDbContext _context;

    public PersonController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Persons.ToListAsync();

        return View(categories);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {

        if (!person.File.ContentType.Contains("image"))
        {
            return View();
        }

        var safeFileName = Path.GetFileName(person.File.FileName);


        string fileName;

        if (safeFileName.Length > 100)
        {
            fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
        }
        else
        {
            fileName = Guid.NewGuid().ToString() + safeFileName;
        }




        var filePath = Path.Combine("C:\\Users\\I Novbe\\source\\repos\\WebApplication5\\WebApplication5\\wwwroot\\images\\", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            person.File.CopyTo(stream);
        }


        person.ImgURl = fileName;

        await _context.AddAsync(person);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Persons.FindAsync(id);


        _context.Persons.Remove(c!);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    public IActionResult Update(int id)
    {
        var c = _context.Persons.FirstOrDefault(x => x.Id == id);

        return View(c);
    }


    [HttpPost]
    public async Task<IActionResult> Update(Person person)
    {

        if (person.File != null)
        {
            if (!person.File.ContentType.Contains("image"))
            {
                return View();
            }

            var safeFileName = Path.GetFileName(person.File.FileName);
            string fileName;

            if (safeFileName.Length > 100)
            {
                fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
            }
            else
            {
                fileName = Guid.NewGuid().ToString() + safeFileName;
            }

            var filePath = Path.Combine("C:\\Users\\I Novbe\\source\\repos\\WebApplication5\\WebApplication5\\wwwroot\\images\\", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                person.File.CopyTo(stream);
            }

            person.ImgURl = fileName;


            _context.Persons.Update(person);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else
        {

            _context.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
