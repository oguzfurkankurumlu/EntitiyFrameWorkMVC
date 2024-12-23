using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

// Database'i oluşturalım
// BookDbContext bizim databasimizdir!!
// bir sınıfın databaee olması için, DbContext isimli sınıftan kalıtım alması gerekmektedir.
public class BooksDbContext : DbContext
{
    // book isimli sınıfı tablo olarak şekilde verelim!!
    public DbSet<Book> Books { get; set; }
    // Parametre olarak alacağı connection stringm bilgisini, base sınıfa iletmesi için base ctor'u çağırdık!!
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
            
    }
    // Veri tabanını terminal ekranından oluşturmak için 3 komut girmeye ihtiyacımız var bunlar
     // Migration'ın yüklenmesi için, 
    // dotnet tool install --global dotnet-ef --version 9.*

     // Migration oluşturmak için kullanılır!! (Migration : kod tarafında yazılan kodları veri tabanına göndermek için hazırlayan bir yapıdır!!)
     // dotnet ef migrations add InitialCreate  

     // migration çalıştıktan sonra
     // kod tarafındaki eklenen veri tabanı ve tablonun veri tabanına işlenmesi için 
     // dotnet ef database update komutunu çalıştırmanız gerekmektedir!!.
}