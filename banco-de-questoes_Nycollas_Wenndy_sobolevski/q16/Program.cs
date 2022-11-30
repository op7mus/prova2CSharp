using System;
using System.IO;
using System.Linq;
using static System.Console;
using System.Collections.Generic;

var days = getDays();
var bikes = getSharings();

// EXC 1
int media = new int();
foreach (var item in bikes)
    media += item.Casual + item.Registred;
    
Console.WriteLine($"Media de alugueis {media = media/731}");

// EXC 2



// TODO

IEnumerable<DayInfo> getDays()
{
    StreamReader reader = new StreamReader("dayInfo.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        DayInfo info = new DayInfo();

        info.Day = int.Parse(data[0]);
        info.Season = int.Parse(data[1]);
        info.IsWorkingDay = int.Parse(data[2]) == 1;
        info.Weather = int.Parse(data[3]);
        info.Temp = float.Parse(data[4].Replace('.', ','));

        yield return info;
    }

    reader.Close();
}

IEnumerable<BikeSharing> getSharings()
{
    StreamReader reader = new StreamReader("bikeSharing.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        BikeSharing info = new BikeSharing();

        info.Day = int.Parse(data[0]);
        info.Casual = int.Parse(data[1]);
        info.Registred = int.Parse(data[2]);

        yield return info;
    }

    reader.Close();
}

public class DayInfo
{
    public int Day { get; set; }
    public int Season { get; set; }
    public bool IsWorkingDay { get; set; }
    public int Weather { get; set; }
    public float Temp { get; set; }
}

public class BikeSharing
{
    public int Day { get; set; }
    public int Casual { get; set; }
    public int Registred { get; set; }
}