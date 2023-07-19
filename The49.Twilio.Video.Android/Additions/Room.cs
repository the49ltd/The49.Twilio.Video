namespace Twilio.Video;

public partial class Room
{
    private InternalListener _listener;
    internal void SetListener(InternalListener roomListener)
    {
        _listener = roomListener;
    }
    // Copied from the generated code and adapted to not need a sender, since the sender is always the first parameter (room)
    internal sealed partial class InternalListener : Java.Lang.Object, IListener
    {
#pragma warning disable 0649
        public EventHandler<ConnectFailureEventArgs>? OnConnectFailureHandler;
#pragma warning restore 0649

        public void OnConnectFailure(Room room, TwilioException exception)
        {
            var __h = OnConnectFailureHandler;
            if (__h != null)
                __h(room, new ConnectFailureEventArgs(room, exception));
        }

#pragma warning disable 0649
        public EventHandler<ConnectedEventArgs>? OnConnectedHandler;
#pragma warning restore 0649

        public void OnConnected(Room room)
        {
            var __h = OnConnectedHandler;
            if (__h != null)
                __h(room, new ConnectedEventArgs(room));
        }

#pragma warning disable 0649
        public EventHandler<DisconnectedEventArgs>? OnDisconnectedHandler;
#pragma warning restore 0649

        public void OnDisconnected(Room room, TwilioException? exception)
        {
            var __h = OnDisconnectedHandler;
            if (__h != null)
                __h(room, new DisconnectedEventArgs(room, exception));
        }

#pragma warning disable 0649
        public EventHandler<DominantSpeakerChangedEventArgs>? OnDominantSpeakerChangedHandler;
#pragma warning restore 0649

        public void OnDominantSpeakerChanged(Room room, RemoteParticipant? remoteParticipant)
        {
            var __h = OnDominantSpeakerChangedHandler;
            if (__h != null)
                __h(room, new DominantSpeakerChangedEventArgs(room, remoteParticipant));
        }

#pragma warning disable 0649
        public EventHandler<ParticipantConnectedEventArgs>? OnParticipantConnectedHandler;
#pragma warning restore 0649

        public void OnParticipantConnected(Room room, RemoteParticipant participant)
        {
            var __h = OnParticipantConnectedHandler;
            if (__h != null)
                __h(room, new ParticipantConnectedEventArgs(room, participant));
        }

#pragma warning disable 0649
        public EventHandler<ParticipantDisconnectedEventArgs>? OnParticipantDisconnectedHandler;
#pragma warning restore 0649

        public void OnParticipantDisconnected(Room room, RemoteParticipant participant)
        {
            var __h = OnParticipantDisconnectedHandler;
            if (__h != null)
                __h(room, new ParticipantDisconnectedEventArgs(room, participant));
        }

#pragma warning disable 0649
        public EventHandler<ParticipantReconnectedEventArgs>? OnParticipantReconnectedHandler;
#pragma warning restore 0649

        public void OnParticipantReconnected(Room room, RemoteParticipant participant)
        {
            var __h = OnParticipantReconnectedHandler;
            if (__h != null)
                __h(room, new ParticipantReconnectedEventArgs(room, participant));
        }

#pragma warning disable 0649
        public EventHandler<ParticipantReconnectingEventArgs>? OnParticipantReconnectingHandler;
#pragma warning restore 0649

        public void OnParticipantReconnecting(Room room, RemoteParticipant participant)
        {
            var __h = OnParticipantReconnectingHandler;
            if (__h != null)
                __h(room, new ParticipantReconnectingEventArgs(room, participant));
        }

#pragma warning disable 0649
        public EventHandler<ReconnectedEventArgs>? OnReconnectedHandler;
#pragma warning restore 0649

        public void OnReconnected(Room room)
        {
            var __h = OnReconnectedHandler;
            if (__h != null)
                __h(room, new ReconnectedEventArgs(room));
        }

#pragma warning disable 0649
        public EventHandler<ReconnectingEventArgs>? OnReconnectingHandler;
#pragma warning restore 0649

        public void OnReconnecting(Room room, TwilioException exception)
        {
            var __h = OnReconnectingHandler;
            if (__h != null)
                __h(room, new ReconnectingEventArgs(room, exception));
        }

#pragma warning disable 0649
        public EventHandler<RecordingStartedEventArgs>? OnRecordingStartedHandler;
#pragma warning restore 0649

        public void OnRecordingStarted(Room room)
        {
            var __h = OnRecordingStartedHandler;
            if (__h != null)
                __h(room, new RecordingStartedEventArgs(room));
        }

#pragma warning disable 0649
        public EventHandler<RecordingStoppedEventArgs>? OnRecordingStoppedHandler;
#pragma warning restore 0649

        public void OnRecordingStopped(Room room)
        {
            var __h = OnRecordingStoppedHandler;
            if (__h != null)
                __h(room, new RecordingStoppedEventArgs(room));
        }
    }

    // Proxy all events through
    public event EventHandler<ConnectFailureEventArgs> ConnectFailure
    {
        add { _listener.OnConnectFailureHandler += value; }
        remove { _listener.OnConnectFailureHandler -= value; }
    }
    public event EventHandler<ConnectedEventArgs> Connected
    {
        add { _listener.OnConnectedHandler += value; }
        remove { _listener.OnConnectedHandler -= value; }
    }
    public event EventHandler<DisconnectedEventArgs> Disconnected
    {
        add { _listener.OnDisconnectedHandler += value; }
        remove { _listener.OnDisconnectedHandler -= value; }
    }
    public event EventHandler<ParticipantConnectedEventArgs> ParticipantConnected
    {
        add { _listener.OnParticipantConnectedHandler += value; }
        remove { _listener.OnParticipantConnectedHandler -= value; }
    }
    public event EventHandler<ParticipantDisconnectedEventArgs> ParticipantDisconnected
    {
        add { _listener.OnParticipantDisconnectedHandler += value; }
        remove { _listener.OnParticipantDisconnectedHandler -= value; }
    }
    public event EventHandler<ParticipantReconnectedEventArgs> ParticipantReconnected
    {
        add { _listener.OnParticipantReconnectedHandler += value; }
        remove { _listener.OnParticipantReconnectedHandler -= value; }
    }
    public event EventHandler<ParticipantReconnectingEventArgs> ParticipantReconnecting
    {
        add { _listener.OnParticipantReconnectingHandler += value; }
        remove { _listener.OnParticipantReconnectingHandler -= value; }
    }
    public event EventHandler<ReconnectedEventArgs> Reconnected
    {
        add { _listener.OnReconnectedHandler += value; }
        remove { _listener.OnReconnectedHandler -= value; }
    }
    public event EventHandler<ReconnectingEventArgs> Reconnecting
    {
        add { _listener.OnReconnectingHandler += value; }
        remove { _listener.OnReconnectingHandler -= value; }
    }
    public event EventHandler<RecordingStartedEventArgs> RecordingStarted
    {
        add { _listener.OnRecordingStartedHandler += value; }
        remove { _listener.OnRecordingStartedHandler -= value; }
    }
    public event EventHandler<RecordingStoppedEventArgs> RecordingStopped
    {
        add { _listener.OnRecordingStoppedHandler += value; }
        remove { _listener.OnRecordingStoppedHandler -= value; }
    }
}