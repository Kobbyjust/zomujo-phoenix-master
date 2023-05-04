using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Phoenix.Auth.Business.Services;

internal class AuthCloudMessagingService
{
    private readonly FirebaseMessaging _messaging;
    public AuthCloudMessagingService()
    {
        // TODO:: Get credentials from firebase console and use path
        var credential = GoogleCredential.FromFileAsync("path/to/credentials.json", new CancellationToken())
            .GetAwaiter()
            .GetResult();
        var app = FirebaseApp.Create(new AppOptions
        {
            Credential = credential
        });
        _messaging = FirebaseMessaging.GetMessaging(app);
    }
    
    // var message = new Message
    // {
    //     Notification = new Notification
    //     {
    //         Title = "My Notification",
    //         Body = "Hello, World!"
    //     },
    //     Token = "device_token"
    // };

    public async Task SendAsync(Message message)
    {
        await _messaging.SendAsync(message);
    }
    
    public async Task SendMultipleAsync(IEnumerable<Message> messages)
    {
        await _messaging.SendAllAsync(messages);
    }
    
    public async Task SendMulticastAsync(MulticastMessage messages)
    {
        await _messaging.SendMulticastAsync(messages);
    }
}