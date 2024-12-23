
# C# Veri Tabanı Bağlantıları

C# geliştirilmiş uygulamalar, iki farklı şekilde veri tabanına erişebilir:

## 1. ADO.NET

ADO.NET, artık demode olmuş bir veri tabanı bağlantı şeklidir. Demode olmasının sebebi, verileri çekme zorluğu ve veri tabanı ile çalışırken çok fazla kod yazma zorunluluğudur.

Ayrıca, ADO.NET kullanıldığında yazılımın içerisindeki SQL cümlecikleri kullanılmaktaydı. Bu durumda, veri tabanında herhangi bir değişiklik yapıldığında aynı değişikliklerin kod tarafında da yapılması gerekiyordu.

## 2. Entity Framework

Tüm bu zorluklar, Microsoft'un yeni bir veri tabanı bağlantı türü geliştirmesi ile son buldu. Modern uygulamalarda, yazılım ve veri tabanı bağlantıları **Entity Framework** ile yapılmaktadır.

Entity Framework'ün en güzel yanı, C# geliştiricilerinin veri tabanı dili bilmeseler dahi, veri tabanı ile rahatlıkla çalışabilmeleridir.

Entity Framework'ün 2 farklı yaklaşımı vardır:

### 1. Code First

Code First yaklaşımında, veri tabanı şeması sıfırdan C# ile kodlanır.

### 2. Db First

Db First yaklaşımında ise mevcut bir veri tabanı alınıp C# üzerinde kullanılır.

-------------------------------------------------------------------------------------------------
## Paketlerin Yüklenmesi

Entity Framework Core kullanmaya başlamak için gerekli paketler şunlardır:

1. **Microsoft.EntityFrameworkCore**

   Bu paket, Entity Framework Core'un ana paketidir.
    ```bash
   dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
    ```

2. **Microsoft.EntityFrameworkCore.SqlServer**

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
    ```

3. **Microsoft.EntityFrameworkCore.Tools**
    
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
    ```

-------------------------------------------------------------------------------------------------
## Database Oluşturma ve Migration Adımları

### 1. `BooksDbContext` Sınıfı

- `BooksDbContext` sınıfı, veritabanımızı temsil eder. Bu sınıf, `DbContext` sınıfından kalıtım alır. 

```csharp
public class BooksDbContext : DbContext
{
    // 'Books' tablosu için DbSet'i tanımlıyoruz
    public DbSet<Book> Books { get; set; }
    
    // Parametre olarak alacağı connection string bilgisini base sınıfa iletmek için base constructor çağrılır
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }
}
-----------------------------------------------------------------------------------------------------

daha sonra contextın altında DBModal klasoru actım
    Books.cs dosyasını ekledım

    public class Book
    {
        //  VERİ TABLOSU OLUŞTURMAK İÇİN, SÜTUNLARI BELİRTMEMİZ GEREKİYOR
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
}

BooksContexte gidip 
    book isimli sınıfı tablo olarak şekilde verelim!!
            public DbSet<Book> Books { get; set; }
```
-----------------------------------------------------------------------------------------------------


### Migration'ın yüklenmesi için:

```bash
dotnet tool install --global dotnet-ef --version 9.*
```

### Migration oluşturmak için kullanılır (Migration: Kod tarafında yazılan kodları veri tabanına göndermek için hazırlayan bir yapıdır):

```bash
dotnet ef migrations add InitialCreate  
```

Migration çalıştıktan sonra kod tarafındaki eklenen veri tabanı ve tablonun veri tabanına işlenmesi için:

```bash
dotnet ef database update
```

Veri tabanını terminal ekranından oluşturmak için 3 komut girmeye ihtiyacımız var bunlar

    dotnet tool install --global dotnet-ef --version 9.*

     Migration oluşturmak için kullanılır!! (Migration : kod tarafında yazılan kodları veri tabanına göndermek için hazırlayan bir yapıdır!!)
     dotnet ef migrations add InitialCreate  

     migration çalıştıktan sonra
     kod tarafındaki eklenen veri tabanı ve tablonun veri tabanına işlenmesi için 
     dotnet ef database update komutunu çalıştırmanız gerekmektedir!!.


-------------------------------------------------------------------------------------

