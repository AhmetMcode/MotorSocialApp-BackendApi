
namespace MotorSocialApp.Domain.Enums
{
    public enum KiraDurumu
    {
        Aktif,
        Tamamlandı,
        İptalEdildi
    }

    public enum OdemeTuru
    {
        Nakit,
        KrediKartı,
        Havale,
        EFT
    }

    public enum StokDurumu
    {
        Mevcut,
        Kullanımda,
        Bakımda,
        Satıldı
    }

    public enum CariIslemTuru
    {
        Alacak,
        Borç,
        Tahsilat,
        Ödeme
    }

    public enum PaketDurumu
    {
        Hazırlanıyor,
        Tamamlandı,
        İptalEdildi
    }

}
