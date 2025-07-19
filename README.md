# Inventory Management System

Bu proje, ürün stoklarını yönetmek için geliştirilmiş basit bir konsol uygulamasıdır.

## Özellikler

- Ürün ekleme (isim, fiyat ve stok miktarı ile)
- Ürün stok miktarını güncelleme
- Stoktaki tüm ürünleri listeleme
- Ürünleri envanterden kaldırma

## Kullanılan Veri Yapısı

- Ürünler `Product` sınıfı ile temsil edilir.
- Ürünün adı (`Name`), fiyatı (`Price`) ve stok miktarı (`Stock`) saklanır.
- Ürünler, `List<Product>` koleksiyonunda tutulur.

## Kurulum ve Çalıştırma

1. Projeyi Visual Studio'da açın.
2. .NET 6.0 SDK veya üzeri yüklü olmalıdır.
3. Projeyi derleyip çalıştırın.
4. Konsol ekranındaki menüden yapmak istediğiniz işlemi seçin.

## Kullanım

- Menüden `1` seçeneği ile yeni ürün ekleyebilirsiniz.
- Menüden `2` seçeneği ile var olan ürünün stok miktarını güncelleyebilirsiniz.
- Menüden `3` seçeneği ile tüm ürünleri ve stok bilgilerini görüntüleyebilirsiniz.
- Menüden `4` seçeneği ile istediğiniz ürünü envanterden kaldırabilirsiniz.
- Menüden `5` seçeneği ile uygulamadan çıkabilirsiniz.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır.  
Açık kaynaklı ve özgür kullanım, değiştirme ve dağıtım hakkı verir.  
Detaylar için [MIT Lisansı](https://opensource.org/licenses/MIT) sayfasına bakabilirsiniz.

## Proje Geliştirme Notu

Bu proje, [Foundations of Coding Back-End] kapsamında öğrenim sürecinde ödev olarak verilmiştir.  
Öğrenme ve uygulama amaçlı hazırlanmış temel bir örnek projedir.
