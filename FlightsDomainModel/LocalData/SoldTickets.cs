namespace FlightsDomainModel;

public class SoldTickets : SetOfModels<Ticket> {

    public void Add(Data data, PurchaseOffer offer) {
        var dto = new TicketDto() {
            SeatId = offer.Seat.Id,
            TenantId = offer.Passanger.Id,
            FinalPrice = offer.Seat.PriceAfterDiscounts(offer.AppliedDiscounts.ToArray()),
            AppliedDisconuts = offer.Passanger.Category == Tenant.Kind.A ? [] : offer.AppliedDiscounts.Select(dsc => dsc.Id).ToArray()
        };
        if(false == NullCheckedFactory.Create<Ticket, TicketDto>(dto, data, out var theTicket)) {
            Log.Error("Something is very wrong... we now have an incosistent state");
            return;
        }
        _models.Add(theTicket!);
    }

    public List<Ticket> All() =>
        _models;
}
