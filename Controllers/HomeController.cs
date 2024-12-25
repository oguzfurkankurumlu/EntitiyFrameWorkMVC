using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntitiyFrameWorkMVC.Models;

namespace EntityFramework_MVC.Controllers;

public class HomeController : Controller
{
    public BooksDbContext _context;
    public HomeController(BooksDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        // c# geliştirilmiş uygulamalar, 2 farklı şekilde veri tabanına erişebilir

        // 1 : Ado.net : Ado.net  artık demode olmuş veri tabanı bağlantı şeklidir
        // Demode olmasının sebebi, verileri çekme zorluğu  ve veri tabanı ile çalışırken, çok kod yazma zorunluluğudur

        // ayrıca, Ado.net kullanıldığında, yazılımın içerisindeki sql cümlecikleri kullanılmaktaydı
        // buda, veri tabanında herhangi bir değişklik yapıldığında aynısını kod tarafında da yapma zorunluluydu.


        // tüm bu zorluklar, microsoft'un yeni bir veri tabanı bağlantı türü geliştirmesi ile son buldu

        // Modern uygulamalarda, yazılım ve veri tabanı bağlantıları EntityFramework ile yapılmaktadır.

        // EntityFramework'ün, en güzel yanı, c# developerler, veri tabanı dili bilmeselerde, veri tabanı ile rahatlıkla çalışaiblirler!!

        // Entity Framework'ün 2 yaklaşımı vardır

        // 1 : Code First 
        // 2 : Db First : 


        // Code first : Veri tabanı şemasını sıfırdan c# ile kodlamak

        // DbFirst : Mevcut bir veri tabanı, alıp c# üzerinde kullanmak!!


        //Bu örnekte, Code First yaklaşımı yapılacaktır!!

        // hiç bir şekilde veri tabanı açmadan, veri tabanı oluşturup içerisne tablolar oluşturup, aynı zamanda sorguyalabileceğiz
        //_context.Database.EnsureCreated();

        _context.Books.Add(new Book() { Name = "Book1", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book2", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book3", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book4", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book5", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book6", Price = 1, Stock = 10 });
        _context.Books.Add(new Book() { Name = "Book7", Price = 1, Stock = 10 });

        // context üzeirnden books tablosuna veri ekledik!!

        // eklenen verilerin veri tabanına gitmesi içinm, _context.savechange() metodunu çağırdık!!

        // SaveChange yapılan değişikliklerin(insert,update,delete) veri tabanına yansımasını sağlar!!.

        // oluşturduğumuz yeni kayıtları veri tabanına aktaralım!!
        _context.SaveChanges();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}