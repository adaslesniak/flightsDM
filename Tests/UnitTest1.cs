using FlightsDomainModel;
using NUnit.Framework;
namespace Tests;

/* I do not support adding tickets by hand, that's a discussion to have with business
 * but basically that's risky and doesn't have sense, it makes so much trouble to system 
 * - how to check if there are places,
 * - how to check if we have deal with airlane
 * Those are just two that comes first, there may be a lot more problems, like inconsistent data
 */

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
        if(false == _data.FindBestOffer(1, "MCK 31000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        var valueOfDiscounts = theOffer!.Seat.BasePriceInCents - theOffer.PriceAfterDiscout;
        Assert.That(valueOfDiscounts == 10 && theOffer!.AppliedDiscounts.Count == 2);
    }

    [Test]
    public void BirthdatDiscountApplies() {
        if(false == _data.FindBestOffer(0, "MCK 12000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        Assert.That(theOffer!.AppliedDiscounts.Any(dsc => dsc.Id == 1));
    }

    [Test]
    public void BirthdatDiscountDoesNotApplies() {
        if(false == _data.FindBestOffer(1, "MCK 12000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        Assert.That(false == theOffer!.AppliedDiscounts.Any(dsc => dsc.Id == 1));
    }

    [Test]
    public void AfricaDestinationDiscountApplies() {
        if(false == _data.FindBestOffer(1, "MCK 31000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        Assert.That(theOffer!.AppliedDiscounts.Any(dsc => dsc.Id == 0));
    }

    [Test]
    public void AfricaDestinationDiscountDoesNotApplies() {
        if(false == _data.FindBestOffer(1, "MCK 23000 CBA", out var theOffer, out var error)) {
            Assert.Fail("fix other things for this test to proceed");
        }
        Assert.That(false == theOffer!.AppliedDiscounts.Any(dsc => dsc.Id == 0));
    }

    [Test]
    public void SavesDiscountsForCatATenants() {
        if(false == _data.FindBestOffer(1, "MCK 31000 CBA", out var theOffer, out var findError)) {
            Assert.Fail($"fix other things for this test to proceed: {findError}");
        }
        if(false == _data.FinalizeBuy(theOffer, out var buyError)) {
            Assert.Fail($"fix buy procedure for this test to proceed: {buyError}");
        }
        var saved = _data.Purchased.All().First(tck => tck.Owner.Id == 1 && tck.Details.Flight.Id == "MCK 31000 CBA");
        Assert.That(saved.AppliedDisconuts.Count() == 2);
    }

    [Test]
    public void DoesntSaveDiscountsForCatBTenants() {
        if(false == _data.FindBestOffer(0, "MCK 31000 CBA", out var theOffer, out var findError)) {
            Assert.Fail($"fix other things for this test to proceed: {findError}");
        }
        if(false == _data.FinalizeBuy(theOffer!, out var buyError)) {
            Assert.Fail($"fix buy procedure for this test to proceed: {buyError}");
        }
        var saved = _data.Purchased.All().First(tck => tck.Owner.Id == 0 && tck.Details.Flight.Id == "MCK 31000 CBA");
        Assert.That(saved.AppliedDisconuts.Count() == 0);
    }

    [Test]
    public void PriceShouldntGoBelowMinimum() {
        if(false == _data.FindBestOffer(0, "MCK 21000 CBA", out var theOffer, out var error)) {
            Assert.Fail($"fix finding offers, to run this test: {error}");
        }
        Assert.That(theOffer.AppliedDiscounts.Count == 0);
    }
}

