using FlightsDomainModel;
using NUnit.Framework;
namespace Tests;


[TestFixture]
public class Tests
{
    Data _data;

    [SetUp]
    public void CreateTestData() {
        _data = new TestData().Prepare();
    }

    [TestCase("MCK 12000 CBA")]
    [TestCase("MCK 31000 CBA")]
    public void BuyTicketForFlight(string flightId) {
        if(false == _data.FindBestOffer(0, flightId, out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        if(false == _data.FinalizeBuy(theOffer!, out error)) {
            Assert.Fail($"failed to purchase the ticket {flightId}: {error}");
        }
        Assert.That(_data.Purchased.All().Any(tck => tck.Details.Flight.Id == flightId));
    }

    [Test]
    public void DiscountsShouldBeApplied() {
        _ = _data.FindBestOffer(0, "MCK 31000 CBA", out var theOffer, out var error);
        var valueOfDiscounts = theOffer!.Seat.BasePriceInCents - theOffer.Seat.PriceAfterDiscounts();
        Assert.That(valueOfDiscounts == 10 && theOffer!.AppliedDiscounts.Count == 2);
    }

    [Test]
    public void PriceAfterDiscoutnsShouldBeBelow20Euro() {
        Assert.Fail("test missing");
    }

    [Test]
    public void BirthdatDiscountApplies() {
        Assert.Fail("test missing");
    }

    [Test]
    public void AfricaDestinationDiscountApplies() {
        if(false == _data.FindBestOffer(1, "MCK 31000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        Assert.That(theOffer!.AppliedDiscounts.Any(dsc => dsc.Id == 0));
    }

    [Test]
    public void SavesDiscountsForCatATenants() {
        Assert.Fail("test missing");
    }

    [Test]
    public void DoesntSaveDiscountsForCatBTenants() {
        Assert.Fail("test missing");
    }
}
/*
X - Mo¿liwoœæ rêcznego dodania lotu
? - Mo¿liwoœæ zakupienia danego lotu wyszukanego po ID
? - Mo¿liwoœæ zastosowania zni¿ki do ceny:
? - Do ceny lotu mo¿na dodaæ zni¿kê, zawsze o wysokoœci 5 euro. Zni¿ki dzia³aj¹ per
criteria i siê kumuluj¹, przy czym cena lotu nie mo¿e wynieœæ mniej ni¿ 20 euro. Product
manager chcia³by mieæ mo¿liwoœæ ³atwego dodawania nowych kryteriów zni¿ki, bo
spodziewa siê ich du¿o w przysz³oœci.
Na pocz¹tku s¹ to jednak nastêpuj¹ce kryteria:
? - data wylotu przypada w urodziny kupuj¹cego
? - jest to lot do Afryki, odlatuj¹cy w czwartek
Przyk³ad:
Cena lotu wejœciowa to 30 euro. Kupuj¹cy ma dziœ urodziny i leci w czwartek do Afryki.
Zastosowano obydwa kryteria wiêc cena koñcowa wynosi 20 euro.
Cena lotu to 21 euro i kupuj¹cy ma dziœ urodziny. Nie mo¿na zastosowaæ ¿adnego
kryterium, poniewa¿ cena wynios³aby poni¿ej 20 euro.
USE CASE specyficzny dla grupy A
• System powinien zapisywaæ jakie kryteria zni¿ek zosta³y zastosowane do ka¿dego
zakupu.
USE CASE specyficzny dla grupy B
• Systemowi NIE wolno zapisywaæ kryteriów zastosowanych do zakupu*/
