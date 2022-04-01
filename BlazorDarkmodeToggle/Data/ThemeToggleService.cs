using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDarkmodeToggle.Data
{
    public class ThemeToggleService
    {
        private readonly IJSRuntime jSRuntime;

        public ThemeToggleService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public bool IsLightTheme { get; set; } = true;
        public string GetIdentifier => IsLightTheme ? "light" : "dark";

        public async Task ToggleTheme() {
            IsLightTheme = !IsLightTheme;
            await jSRuntime.InvokeVoidAsync("toggleTheme", GetIdentifier);
        }
    }
}
