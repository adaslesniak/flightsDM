namespace FlightsDomainModel;
internal static class Log
{
    internal static void Error(string msg, Exception? err = null) {
        //TODO: plug in some serious log
        Console.WriteLine(msg);
    }
}
