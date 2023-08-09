# Patika.NET-Bootcamp
# final projects 
**İhtiyaçlar Kategori ekleme güncelleme apileri. Listeleme apileri. Kategori bazlı urun listeleme apisi . Kategori silme apisi (Kategoride ürün varsa silinemez) Ürün ekleme güncelleme apisi. Listeleme apisi. Silme apisi Kullanıcı oluşturma apisi. Login apisi. Kullanıcı güncelleme ve silme apisi. Yetkilendirme icin jwt token altyapısı Sipariş apileri, oluşturma , aktif siparişler, geçmiş sipariş apileri Sipariş detay apisi, siparişteki ürün bilgileri Kupon oluşturma listeleme ve silme apileri

**Tech-Stack Veri tabanı (Postgresql,Mssql) alt yapısı hazırlandı.Proje kapsamında MsSql kullanıldı. Database için CodeFirst yaklaşımı kullanıldı. Migration oluşturuldu. JWT token (Yetkilendirme) kullanıldı. EF-Repositroy - Unitofwork ikiside kullanıldı. Postman View document = https://documenter.getpostman.com/view/14710639/2s93z6ejYD Postman için collection.json dosyasıda eklendi. Redis (Basket controller) da kullanıldı. MediatR (Order controller) da kullanıldı. FluentValidation kullanıldı.

Docker Redis için cli komutları docker pull redis docker run --name redis-baskets -p 6379:6379 -d redis