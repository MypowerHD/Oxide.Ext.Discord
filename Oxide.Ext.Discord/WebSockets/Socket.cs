namespace Oxide.Ext.Discord.WebSockets
{
    using System;
    using Oxide.Ext.Discord.Exceptions;
    using WebSocketSharp;

    public class Socket
    {
        private DiscordClient client;

        private WebSocket socket;

        private SocketListener _listener;

        public bool hasConnectedOnce = false;

        public Socket(DiscordClient client)
        {
            this.client = client;
        }

        public void Connect(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new NoURLException();
            }

            if (socket != null && socket.ReadyState != WebSocketState.Closed && socket.ReadyState != WebSocketState.Closing)
            {
                //throw new SocketRunningException(client);
                // Assume force-reconenct
                socket?.Close(CloseStatusCode.Abnormal);
            }
            client.DestroyHeartbeat();

            socket = new WebSocket($"{url}/?v=6&encoding=json");

            if(_listener == null)
                _listener = new SocketListener(client, this);

            socket.OnOpen += _listener.SocketOpened;
            socket.OnClose += _listener.SocketClosed;
            socket.OnError += _listener.SocketErrored;
            socket.OnMessage += _listener.SocketMessage;

            socket.ConnectAsync();
        }

        public void Disconnect(bool normal = true)
        {
            if (IsClosed() || IsClosing()) return;

            socket?.CloseAsync(normal ? CloseStatusCode.Normal : CloseStatusCode.Abnormal);
        }

        public void Dispose()
        {
            _listener = null;
            socket = null;
        }

        public void Send(string message, Action<bool> completed = null)
        {
            if (IsAlive())
                socket?.SendAsync(message, completed);
        }

        public bool IsAlive()
        {
            if (socket == null)
                return false;
            return socket.ReadyState == WebSocketState.Open;
        }

        public bool IsClosing()
        {
            if (socket == null)
                return false;
            return socket.ReadyState == WebSocketState.Closing;
        }

        public bool IsClosed()
        {
            if (socket == null)
                return true;
            return socket.ReadyState == WebSocketState.Closed;
        }
    }
}
