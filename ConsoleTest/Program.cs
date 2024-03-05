// See https://aka.ms/new-console-template for more information
using CefSharp;
using CefSharp.DevTools.Page;
using CefSharp.OffScreen;
using System.Drawing;

Console.WriteLine("Hello, World!");

var settings = new CefSettings() {
    CachePath = Path.Combine(Path.GetTempPath(), "cefsharpcache")
};
//This fails
await Cef.InitializeAsync(settings);
//This works
//Cef.Initialize(settings);


string url = "www.bing.com";
BrowserSettings browserSettings = new BrowserSettings {
    WindowlessFrameRate = 1,
};
using (ChromiumWebBrowser browser = new ChromiumWebBrowser(url, browserSettings)) {
    browser.Size = new Size(1920, 1080);
    byte[] screenshot;

    await browser.WaitForRenderIdleAsync();
    screenshot = await browser.CaptureScreenshotAsync(CaptureScreenshotFormat.Png);
    await File.WriteAllBytesAsync(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".png"), screenshot);
}