namespace Twilio.Video;

public partial class TwilioVideo
{
    // We expose the Connect method without a listener, the listener is created internally
    public static unsafe Room Connect(Android.Content.Context context, ConnectOptions connectOptions)
    {
        // This will call the method underneath
        var room = Connect(context, connectOptions, new Room.InternalListener());
        return room;
    }
    // Internal method that sets the room's listener immediately after it is created
    internal static unsafe Room Connect(Android.Content.Context context, ConnectOptions connectOptions, Room.InternalListener roomListener)
    {
        // as Room.IListener makes sure it calls the native method and not the current one
        var room = Connect(context, connectOptions, roomListener as Room.IListener);
        room.SetListener(roomListener);
        return room;
    }
}
