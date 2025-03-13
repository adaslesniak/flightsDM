using FlightsDomainModel;
namespace Tests;

public class Tests
{
    Data _data;

    [SetUp]
    public void CreateTestData() {
        _data = new TestData().Prepare();
    }

    [TestCase("MCK 12000 CBA")]
    public void BuyTicketForFlight(string flightId) {
        _ = _data.FindBestOffer(0, flightId, out var theOffer, out var error);
        _ = _data.FinalizeBuy(theOffer!, out error);
        Assert.That(_data.Purchased.All().Any(tck => tck.Details.Flight.Id == flightId));
    }

    [TestCase("MCK 12345 BCA")]
    public void DiscountsShouldBeApplied(string flightId) {

    }

    [TestCase("MCK 12345 BCA")]
    public void PriceAfterDiscoutnsShouldBeBelow20Euro(string flightId) {

    }

    [TestCase("MCK 12345 BCA")]
    public void BirthdatDiscountApplies(string flightId) {

    }

    [Test]
    public void AfricaDestinationDiscountApplies() {

    }

    [Test]
    public void SavesDiscountsForCatATenants() {

    }

    [Test]
    public void DoesntSaveDiscountsForCatBTenants() {

    }
}
/*
X - Mo�liwo�� r�cznego dodania lotu
? - Mo�liwo�� zakupienia danego lotu wyszukanego po ID
? - Mo�liwo�� zastosowania zni�ki do ceny:
? - Do ceny lotu mo�na doda� zni�k�, zawsze o wysoko�ci 5 euro. Zni�ki dzia�aj� per
criteria i si� kumuluj�, przy czym cena lotu nie mo�e wynie�� mniej ni� 20 euro. Product
manager chcia�by mie� mo�liwo�� �atwego dodawania nowych kryteri�w zni�ki, bo
spodziewa si� ich du�o w przysz�o�ci.
Na pocz�tku s� to jednak nast�puj�ce kryteria:
? - data wylotu przypada w urodziny kupuj�cego
? - jest to lot do Afryki, odlatuj�cy w czwartek
Przyk�ad:
Cena lotu wej�ciowa to 30 euro. Kupuj�cy ma dzi� urodziny i leci w czwartek do Afryki.
Zastosowano obydwa kryteria wi�c cena ko�cowa wynosi 20 euro.
Cena lotu to 21 euro i kupuj�cy ma dzi� urodziny. Nie mo�na zastosowa� �adnego
kryterium, poniewa� cena wynios�aby poni�ej 20 euro.
USE CASE specyficzny dla grupy A
� System powinien zapisywa� jakie kryteria zni�ek zosta�y zastosowane do ka�dego
zakupu.
USE CASE specyficzny dla grupy B
� Systemowi NIE wolno zapisywa� kryteri�w zastosowanych do zakupu*/
