**Kitap Analiz Projesi** 

Bu çalışma, Kaggle üzerinden alınan ve içerisinde yaklaşık 1 milyon adet kitap verisi barındıran devasa bir veri setinin, modern web teknolojileriyle nasıl hızlı ve performanslı bir şekilde yönetilebileceğini göstermek amacıyla geliştirilmiştir.

Projede temel amaç, milyonlarca satırlık veri içerisinde boğulmadan, kullanıcının aradığı kitaba veya sayfalara milisaniyeler içinde ulaşmasını sağlamaktır. Bu hedef doğrultusunda arka planda Dapper micro-ORM kullanılarak veritabanı sorguları optimize edilmiş, SQL Server tarafında ise özel indeksleme ve sayfalama teknikleri uygulanmıştır.

___________________________________________________________________________________________________________________________________________________

🚀 **Öne Çıkan Özellikler**

**1 Milyon+ Gerçek Veri ile Çalışma:** Kaggle'dan alınan devasa kitap veri seti üzerinde gerçek zamanlı testler ve veri yönetimi.

**Dapper ile Maksimum Sorgu Hızı:** Entity Framework gibi ağır ORM'ler yerine, SQL'e en yakın hızda çalışan Dapper Micro-ORM kullanımı.

**Asenkron (Async) Mimari:** Veritabanı işlemleri sırasında sistemin kilitlenmesini önleyen Task tabanlı programlama yapısı.

**Gelişmiş Sayfalama (Pagination):** 1 milyon veri içinde kaybolmadan, SQL Server OFFSET-FETCH komutları ve doğru indeksleme ile milisaniyeler süren sayfa geçişleri.

**Performans Odaklı DTO Kullanımı:** Veritabanındaki tüm kolonları değil, sadece ekranda gösterilecek verileri taşıyan hafif veri transfer nesneleri (Data Transfer Objects).

**Modern ve Responsive Arayüz:** Argon Dashboard teması entegre edilerek hem masaüstü hem mobil cihazlarla uyumlu kullanıcı deneyimi.

**Hızlı Veri Erişimi (Indexing):** SQL tarafında oluşturulan özel indeksler sayesinde milyonlarca satır arasından ISBN veya kitap adına göre anlık erişim altyapısı.

___________________________________________________________________________________________________________________________________________________

🛠 **Performance Tuning**

1 milyon veri içerisinde takılmadan gezinebilmek için SQL Server tarafında uyguladığım kritik indeks sorguları aşağıdadır:

**Sayfalama ve Sıralama İndeksi**

Sayfalama yaparken ORDER BY ISBN kullandığımız için, SQL'in tüm tabloyu taramasını engelleyen indeks:

**SQL:**
CREATE NONCLUSTERED INDEX IX_Books_ISBN_Pagination 
ON Books (ISBN) 
INCLUDE (Book_Title, Book_Author, Year_Of_Publication, Publisher, Image_Url_S);

___________________________________________________________________________________________________________________________________________________

📈 **Performans Sonucu**

|İşlem Tipi          | İndekssiz Süre       | İndeksli Süre                   |
|-------------    |------------------           |------------------  |
| İlk 20 Kaydı Getirme         | 	~1.5 sn         | < 0.01 sn
| 500.000. Satırdan Sonrasını Getirme         | 	~12 sn         | < 0.05 sn

___________________________________________________________________________________________________________________________________________________

🛠 **Kullanılan Teknolojiler**

|Katman          | Teknoloji / Kütüphane       
|-------------    |------------------          
| Backend         |.NET 8.0 (ASP.NET Core MVC)        
| Veri Erişimi         |Dapper (Micro-ORM)  
| Veritabanı         |SQL Server (1.1 Milyon Kayıt) 
| Arayüz         |Argon Dashboard (Bootstrap 4 tabanlı) 
| Programlama         |Asenkron (Async/Await) Mimari 

___________________________________________________________________________________________________________________________________________________

:framed_picture: **Ekran Görüntüleri**

![Image](https://github.com/user-attachments/assets/a8477643-94ef-4a68-9a3a-e844dbfc98c3)

![Image](https://github.com/user-attachments/assets/ab3ddd44-016a-41fc-8dfa-d43f7bc50e73)





