using System.Diagnostics.CodeAnalysis;
namespace FlightsDomainModel;


/// <summary>
/// This is super simplified, no seats, no limit of numer of setas, no basket, no payments...
/// </summary>
public static class Buy {
    public static bool FindBestOffer(this Data data, int tenantId, string flightId, [MaybeNullWhen(false)] out PurchaseOffer offer, [MaybeNullWhen(true)] out string error) {
        if(data.Passangers.WithId(tenantId) is not Tenant tenant) {
            error = "Tenant not found";
            offer = null;
            return false;
        }
        if(data.Flights.WithId(flightId) is not Flight flight) {
            error = "Flight not found";
            offer = null;
            return false;
        }
        if(false == FindOffers(data, tenant, flight, out var availableOffers, out error)) {
            offer = null;
            return false;
        }
        offer = PickBestPrice(availableOffers, tenant);
        return true;
    }

    public static PurchaseOffer PickBestPrice(List<PurchaseOffer> offers, Tenant forTenant) {
        //availableOffers.Sort((some, other) => ApplyDiscounts(some, tenant) - ApplyDiscounts(other, tenant));
        return offers.First();
        //TODO
    }

    public static int PickDiscounts(PurchaseOffer offer, Tenant forUser, out Guid[] appliedDiscounts) {
        appliedDiscounts = [];
        return offer.Seat.MinPriceInCents; //TODO:
    }

    public static bool FindOffers(this Data data, Tenant tenant, Flight flight, 
        [MaybeNullWhen(false)] out List<PurchaseOffer> offers, [MaybeNullWhen(true)] out string error) {
        offers = new();
        if(data.Offer.ForFlight(flight.Id) is not List<Seat> found || found.Count == 0) { 
            error = "No seats found on that flight";
            return false;
        }
        var available = found.Where(seat => seat.IsAvailable).ToList();
        if(available.Count == 0) {
            error = "All fligths are already reserved";
            return false;
        }
        foreach(var seat in available) {
            offers.Add(new() {
                Passanger = tenant,
                Seat = seat,
                AppliedDiscounts = new()
            });
        }
        error = null;
        return true;
    }

    /// <summary>
    /// Call this after payment system processed purchase
    /// </summary>
    public static bool FinalizeBuy(this Data data, PurchaseOffer offer, out string error) {
        if(false == offer.Seat.Provider.IsStillAvailable(offer.Seat)) {
            error = "Ticket no more available";
            return false;
        }
        if(false == offer.Seat.Provider.Buy(offer.Seat)) {
            //TODO: this could be handled well by checking alternatives
            error = "Reserving ticket from airline failed";
            return false;
        }
        data.Purchased.Add(data, offer);
        error = string.Empty;
        return true;
    }

    public static int PriceAfterDiscounts(this Seat seat, params IDiscount[] discounts) {
        //FIXME, TODO: 
        return 2100;
    }

    
}
