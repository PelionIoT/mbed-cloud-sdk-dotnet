# Webhook Example

This example ASP.NET Core server demonstrates how the Mbed Cloud SDK can be used to listen for notifications with a webhook, rather than a long polling channel.

## Build

Clone the MbedCloudSDK repo and move to the Examples/WebhookExample directory

```bash
$ cd Examples/WebhookExample
```

Restore the dependencies

```bash
$ dotnet restore
```

Build the example

```bash
$ dotnet build
```

Before you run the project, make sure you have set `$MBED_CLOUD_API_KEY` envrionment variable to your api key.

```bash
$ dotnet run
```

The server will now be running at port 5000.

## routes

### POST /register

This sets the webhook url to a url that is visible on the public internet.

An example request

```
curl -X POST \
  http://localhost:5000/register \
  -H 'Content-Type: application/json' \
  -d '{
	"url": "http://1842069c.ngrok.io"
}'
```

This will set the webhook to `http://1842069c.ngrok.io`.

### POST /subscribe

This creates a new subscription to resource value changes. You can set deviceId, resourcePaths or both.

An example request

```
curl -X POST \
  http://localhost:5000/subscribe \
  -H 'Content-Type: application/json' \
  -d '{
	"deviceId":"0161661f44460042069000010010004f",
	"resourcePaths": ["/3200/0/5501"]
}'
```

This will subscribe to the path `/3200/0/5501` on device with Id  `0161661f44460042069000010010004f`.

Wildcards can be used in deviceID or ResourcePaths, for example

```
{
    "deviceId":"0161661f444*",
	"resourcePaths": ["/3200/*"]
}
```

Or just subscribe to everything

```
{
    "deviceId":"*"
}
```

Warning - The broader your parameters, the longer the request will take as a broad filter will result in many API calls.

### PUT /

This route captures all data sent down the notification channel. In your own application to feed these notifications into the SDK you must use the `Notify` method on the `ConnectApi`. For example, the `PUT /` in this example looks like

```C#
[HttpPut("/")]
public IActionResult Put([FromBody] NotificationMessage data)
{
    _connectService.connect.Notify(data);
    return Ok();
}
```

## Services

### ConnectService

As the ConnectApi can only have one channel per ApiKey, it is advisable to use the singleton pattern. The ConnectService creates a new instance of the ConnectApi on startup and is registered as a singleton. This can then be injected into the relevant controllers.