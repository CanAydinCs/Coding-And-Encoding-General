# Coding And Encoding General
 Hipotenüs üçgeninin avantajlarını kullanarak yazdığım şifreleme sisteminin kaynak kodlarıdır.
 Derlenebilir dosyalar:
 /bin/debug dosyasının altında projenin ismi ile bulunabilir.

 Çalışma mantığı:
 Hipotenüsleri aynı sayı olan ama kenarları farklı tam sayı olan dik üçgenler vardır. Mesela 4897,1704;5185-5016,1313;5185-5183,144;5185 bunların hepsinin hipotenüsü aynı olsa da diğer kenarları farklılık göstermektedir. Bu algoritma da bundan yararlanarak aynı girdiyi farklı şekillerde şifrelebilmeyi amaçlamıştır. Bunun sonucunda ise hipotenüse bağlı kenarları birer harfe atayarak o hipotenüsün aynı kenarı için farklı üçgenlerdeki değerini döndürerek şifrelemiştir.
 Mesela "t" harfi için örnek şifreleme şu şekildedir: 360b2040 360 ve 2040'ın b kenarı olduğu ortak üçgen ve o üçgenin hipotenüsü.
 Bu ortaklık sadece 2 tane ortak hipotenüse sahip olan üçgenler için bile 4 farklı rastgele şifreleme oluşturabilirken daha büyük sayılarda ortak hipotenüs arttığı için bu çeşitlilik daha da artmaktadır. Mesela bakınız: 5525'in 5 farklı versiyonu bulunmaktadır.
