using Microsoft.AspNetCore.SignalR; 

namespace ChattingWebApp_SignalR.Hubs
{
    public class ConnectedHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            ConnectedUsers.myConnectedUsers.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {


            ConnectedUsers.myConnectedUsers.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);

        }


        // this code send messages to all users connected in hub. 
        public async Task SendMessage(string user,string message)
        {
            if (string.IsNullOrEmpty(user))


            await Clients.All.SendAsync("ReceiveMessage", user, message);

            else
                await Clients.Client(user).SendAsync("ReceiveMessage",user,message);
        
        }




    }
}
