# XF_WebViewEventsNotFired
 This sample project demonstrates a bug in Xamarin Forms update 4.8.0.1364 (4.8.0 Service Release 1)
## Detailed Description
_**1. Prerequisites:**_
   - The [Security Advisory CVE-2020-16873](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/release-notes/4.8/4.8.0-sr1#security-advisory) preventing the malicious Javascript by adding the following code, thus preventing the webView from firing Navigating and Navigated events:
   ```c#
      protected override AWebView CreateNativeControl()
      {
         var webView = new AWebView(Context);
         webView.Settings.SetSupportMultipleWindows(true);
         return webView;
      }
   ```
   - One example case of this is that I have a banner ad displayed at my login screen. When the user tap on it, the app will open external browser and navigate to the predefined target URL. 
   - Another case is inside a ContentPage that contains a WebView, I want to tap on an element inside the webView and navigate to a new ContentPage.
   - Both of the above scenarios doesn't work after update Xamarin Forms to v4.8.0.1364.
   - The change was made in this PR: [xamarin/Xamarin.Forms#11755](https://github.com/xamarin/Xamarin.Forms/pull/11755/files#).
   - Last known good version: 4.8.0.1269

_**2. Bug Content:**_
   - OS: Android.
   - Steps of reproduction
     - Tap the image **PRODUCTS** (Image contains Google Home, Google Pixel, Tablet) on the initial screen.
   - Actual Result:
     - Can't navigate to Google's store page.
     - The webView receives touches but doesn't fire navigating and navigated events.
     - The label Loading... is not showing.
   - Expected Result:
     - Can navigate to Google's store page and the label Loading is working correctly (similar to when tap title Google on webView's navigation bar)
 
 _**3. Work around:**_
   - Of course the workaround is as the Security Advisory stated "**use the same renderer with the false value instead**". But should this be considered a different approach to get the best of both worlds. That means preventing the malicious Javascript while keeping the WebView's events working the way it used to be.
   ```c#
    webView.Settings.SetSupportMultipleWindows(false);
   ```
