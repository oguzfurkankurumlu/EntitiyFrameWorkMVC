public class Book
{
    //  VERİ TABLOSU OLUŞTURMAK İÇİN, SÜTUNLARI BELİRTMEMİZ GEREKİYOR
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
}
    // dotnet tool install --global dotnet-ef --version 9.*
    // dotnet ef migrations add InitialCreate       
    