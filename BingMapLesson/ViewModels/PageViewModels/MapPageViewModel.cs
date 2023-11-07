using BingMapLesson.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BingMapLesson.ViewModels.PageViewModels;

public class MapPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<AftoBus> buses;
    public ObservableCollection<AftoBus> Buses { get => buses; set { buses = value; OnPropertyChanged(); } }
    public MapPageViewModel()
    {
        //// Json file dan oxuma
        var folder = new DirectoryInfo("../../../DataBase");

        var fullPath = folder + "/Buses.json";

        var jsonText = File.ReadAllText(fullPath);

        var buses = JsonSerializer.Deserialize<BakuBus>(jsonText);


        Buses = new ObservableCollection<AftoBus>(buses!.BUS);
        AllBuss.Buses = Buses;
        //ReapFromApi();
    }

    //private async Task ReapFromApi()
    //{
    //    // api  den oxumaq
    //    var client = new HttpClient();
    //    //var jsonText  = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;
    //    //var jsonText = client.GetStringAsync("https://raw.githubusercontent.com/CavidAtamoghlanov/BakuBusApi/main/bakubusApi.json").Result;
    //    var jsonText = await client.GetStringAsync("https://raw.githubusercontent.com/CavidAtamoghlanov/BakuBusApi/main/bakubusApi.json");


    //    var buses = JsonSerializer.Deserialize<BakuBus>(jsonText);

        
    //}


    // ------------------------------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyNmae = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNmae));
}
