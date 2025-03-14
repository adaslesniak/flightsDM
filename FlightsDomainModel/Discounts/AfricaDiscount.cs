﻿namespace FlightsDomainModel;

public class AfricaDiscount : IDiscount {

    int _id = 0;
    int _value = 5;

    int IDiscount.Id =>
        _id;

    int IDiscount.ValueInCents =>
        _value;

    string IDiscount.Description =>
        "Applied on user birthday";

    //TODO: confirm with business that to Africa doesn't mean inter Africa flights
    //TODO: create some proper enumeration or constants for Countries and Continents and Airports probably as well instead of hardcoding strings
    bool IDiscount.CanBeApplied(Tenant _, Seat flight) =>
        flight.From.Continent != "Africa"
        && flight.Destination.Continent == "Africa";
}
