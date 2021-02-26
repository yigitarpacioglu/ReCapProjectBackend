
### İkinci El Araç Satış Platformu

## Son Güncellemeler

Database üzerinde CarImages tablosu ve ilgili sütunlar için (Id,CarId,ImagePath,Date) ilgili varlık oluşturuldu.
API aracılığyla resim ekleme işlemi gerçekleştirildi.
Eklenen resimler API içerisindeki wwwroot içerisinde tutuldu.
Resim silme, güncelleme yetkileri eklendi.
Bir araba için maksimum 5 resim ekleme kısıtı getirildi.
Resmin eklendiği tarih, sistem tarafından otomatik olarak encapsulation yardımıyla entity seviyesinde atanacaktır. Keyfi değer verildiğinde ise sistem o değeri tarih olarak alacaktır.
Bir arabaya ait resimleri listeleme imkanı oluşturuldu. Fakat listede araç olmadığında şirket logosu kullanıldı.

## Core
IEntity, IDto, IEntityRepository, EfEntityRepositoryBase yapıları bu katman içerisinde oluşturuldu.
IDto: Özel sorgular ile çekilebilecek nesneler için oluşturulan arayüz.
IEntityRepository: T generic yapısı ile kolayca implemente edilebilen, Gerçek DataAccess katmanındaki arayüzler için temel database işlemlerini tutmaktadır.,
EfEntityRepositoryBase: Entity Framework yapısı için yine generic bir yapıda context ve yapısını oluşturacak olan nesnesi(entity) yardımıyla temel database işlemleri için somut bir arayüz implementasyonunu sağlayacak iskeleti tutmaktadır.
ICrudServices: Gerçek Business katmanında farklı nesnelere ait servisler için benzer veri tabanı işlemlerinin uygulanabilirliğini kolaylaştırmak amacıyla generic yapıda oluşturulmuştur.
Autofac desteği getirildi.
Fluent Validation desteği getirildi.
(A)spect (O)riented (P)rogramming temel seviye giriş gerçekleştirildi.

## Entities 
Car adında bir sınıf ile araç özelliklerini tutan nesne oluşturuldu.
Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi.
Brand ve Color nesneleri eklendi. Bu nesneler Id ve Name özelliklerini taşımaktadırlar.
Users tablosu oluşturuldu.
Customers tablosu oluşturuldu 
Rentals tablosu oluşturuldu ve Key atamaları yapıldı.
Projede bu tablolardaki elemanlara karşılık gelecek Entity'ler oluşturuldu.
Yeni kullanıcılar, müşteriler ve kira kayıtları oluşturuldu. (SQL)

## DataAccess 
Veritabanından ekleme, silme, listeleme gibi işlemleri içermektedir.
Database için gerekli sorgular projeye eklenmiştir.
Car, Brand ve Color nesneleri için Entity Framework altyapısını yazılmıştır.
DAL operasyonlarında yeni eklenen Customers, Users ve Rentals için CRUD işlemleri yazıldı.

## Business 
Data Access katmanı aracılığıyla 
- GetAllService()          : Liste içerisindeki bütün araçları döndürmek,
- GetById(int id)          : Dışarıdan verilen bir ID ile ilişkili nesneyi döndürmektedir.
- AddService(T entity)     : Dışarıdan verilen bir nesnenin sisteme eklenmesi,
- UpdateService(T entity)  : Dışarıdan verilen bir nesnenin sistemdeki eşleşen ilanın güncellenmesi, 
- DeleteService(T entity)  : Yine dışarıdan verilen bir nesne ile eşleşen ilanın silinmesi fonksiyonları gerçekleştirilmiştir.
 Fluent Validation ile yeni kısıtlamalar getirildi.

## ConsoleUI
Consolda bütün CRUD test işlemleri gerçekleştirilmektedir.
Ayrıca GetCarDetails() ile farklı tablolarda bulunan CarName, BrandName, ColorName, DailyPrice bilgileri tabloların join edilmesi işlemi ile bir araya getirildi.
Program.cs üzerinde yeni test operasyonları eklendi.
Kiralama imkanı kod üzerinde gerçekleştirildi.
Eğer araç ofis tarafından teslim alınmamışsa, yeni kiralama işlemi yapılması engellendi.

# WebAPI 
WebAPI bölümü oluşturuldu.
Business katmanındaki bütün servisler için API karşılığı getirildi.
