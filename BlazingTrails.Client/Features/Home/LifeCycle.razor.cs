using Microsoft.AspNetCore.Components;

namespace BlazingTrails.Client.Features.Home;

public partial class LifeCycle
{
    List<string> _greeting = new List<string>();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        Console.WriteLine("SetParametersAsync - Begin");
        await base.SetParametersAsync(parameters);
        Console.WriteLine("SetParametersAsync - End");
    }

    protected override void OnInitialized()                
        => Console.WriteLine("OnInitialized");
 
    protected override async Task OnInitializedAsync()
    {
        _greeting.Add("Welcome");            
 
        await Task.Delay(1000);              
        _greeting.Add("to");
        StateHasChanged();
        await Task.Delay(1000);              
        _greeting.Add("Blazor in Action");   
    }
 
    protected override void OnParametersSet()              
        => Console.WriteLine("OnParametersSet");

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("OnParametersSetAsync - Begin");
        await Task.Delay(500);
        Console.WriteLine("OnParametersSetAsync - End");
    }

    protected override void OnAfterRender(bool firstRender)                                   
        => Console.WriteLine($"OnAfterRender (First render: {firstRender})");
 
    protected override async Task OnAfterRenderAsync(bool firstRender)                                   
        => await Task.Run(() => Console.WriteLine($"OnAfterRenderAsync (First render: {firstRender})"));
}

