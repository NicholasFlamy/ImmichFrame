using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public static class JavaScriptInterop
{
    private static IJSRuntime? _jsRuntime;

    public static void SetJSRuntime(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public static async Task SaveToLocalStorageAsync(string key, string data)
    {
        if (_jsRuntime == null)
            throw new InvalidOperationException("JSRuntime not set.");

        await _jsRuntime.InvokeVoidAsync("saveToLocalStorage", key, data);
    }

    public static async Task<string?> GetFromLocalStorageAsync(string key)
    {
        if (_jsRuntime == null)
            throw new InvalidOperationException("JSRuntime not set.");

        return await _jsRuntime.InvokeAsync<string>("getFromLocalStorage", key);
    }
}
