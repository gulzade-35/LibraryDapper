**Kitap Analiz Projesi** 

Bu çalışma, Kaggle üzerinden alınan ve içerisinde yaklaşık 1 milyon adet kitap verisi barındıran devasa bir veri setinin, modern web teknolojileriyle nasıl hızlı ve performanslı bir şekilde yönetilebileceğini göstermek amacıyla geliştirilmiştir.

Projede temel amaç, milyonlarca satırlık veri içerisinde boğulmadan, kullanıcının aradığı kitaba veya sayfalara milisaniyeler içinde ulaşmasını sağlamaktır. Bu hedef doğrultusunda arka planda Dapper micro-ORM kullanılarak veritabanı sorguları optimize edilmiş, SQL Server tarafında ise özel indeksleme ve sayfalama teknikleri uygulanmıştır.

🚀 **Öne Çıkan Özellikler**

**1 Milyon+ Gerçek Veri ile Çalışma:** Kaggle'dan alınan devasa kitap veri seti üzerinde gerçek zamanlı testler ve veri yönetimi.

**Dapper ile Maksimum Sorgu Hızı:** Entity Framework gibi ağır ORM'ler yerine, SQL'e en yakın hızda çalışan Dapper Micro-ORM kullanımı.

**Asenkron (Async) Mimari:** Veritabanı işlemleri sırasında sistemin kilitlenmesini önleyen Task tabanlı programlama yapısı.

**Gelişmiş Sayfalama (Pagination):** 1 milyon veri içinde kaybolmadan, SQL Server OFFSET-FETCH komutları ve doğru indeksleme ile milisaniyeler süren sayfa geçişleri.

**Performans Odaklı DTO Kullanımı:** Veritabanındaki tüm kolonları değil, sadece ekranda gösterilecek verileri taşıyan hafif veri transfer nesneleri (Data Transfer Objects).

**Modern ve Responsive Arayüz:** Argon Dashboard teması entegre edilerek hem masaüstü hem mobil cihazlarla uyumlu kullanıcı deneyimi.

**Hızlı Veri Erişimi (Indexing):** SQL tarafında oluşturulan özel indeksler sayesinde milyonlarca satır arasından ISBN veya kitap adına göre anlık erişim altyapısı.

🛠 **Performance Tuning**

1 milyon veri içerisinde takılmadan gezinebilmek için SQL Server tarafında uyguladığım kritik indeks sorguları aşağıdadır:

**1. Sayfalama ve Sıralama İndeksi**

Sayfalama yaparken ORDER BY ISBN kullandığımız için, SQL'in tüm tabloyu taramasını engelleyen indeks:

**SQL**
CREATE NONCLUSTERED INDEX IX_Books_ISBN_Pagination 
ON Books (ISBN) 
INCLUDE (Book_Title, Book_Author, Year_Of_Publication, Publisher, Image_Url_S);

**2. Kitap Adına Göre Hızlı Arama**

Kullanıcı bir kitap ismi aradığında sonucun anında gelmesi için:

**SQL**
CREATE NONCLUSTERED INDEX IX_Books_Title_Search 
ON Books (Book_Title) 
WHERE Book_Title IS NOT NULL;








