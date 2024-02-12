using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var jsonOptions = new JsonSerializerOptions();
const int t48 = 2048;
jsonOptions.MaxDepth = t48;

Main();

void Main()
{
    var INS = Console.ReadLine();
    var count = int.Parse(INS);

    for (int i = 0; i < count; i++)
    {
        var INPUT = Console.ReadLine();
        var index = int.Parse(INPUT);
        var sub = new StringBuilder();

        for (int j = 0; j < index; j++)
        {
            var IN = Console.ReadLine();
            sub.AppendLine(IN);
        }

        var direction = JsonSerializer.Deserialize<File>(sub.ToString(), jsonOptions);
        Console.WriteLine(Rec2(direction));
    }
}

int Rec2(File direction)
{
    var res = 0;
    bool flag = false;

    if (direction.DirFiles != null)
    {
        var orDefault = direction.DirFiles.FirstOrDefault(file => file.EndsWith(".hack"));
        if (orDefault != null)
        {
            flag = true;
            res += Rec(direction);
        }
    }

    if (direction.DirFolders != null && !flag)
    {
        foreach (var item in direction.DirFolders)
        {
            res += Rec2(item);
        }
    }

    return res;
}

int Rec(File direction)
{
    int result = direction.DirFiles?.Count() ?? 0;

    if (direction.DirFolders != null)
    {
        result += direction.DirFolders.Sum(folder => Rec(folder));
    }

    return result;
}

class File
{
    [JsonPropertyName("dir")]
    public string DirName { get; set; }

    [JsonPropertyName("files")]
    public IEnumerable<string> DirFiles { get; set; }

    [JsonPropertyName("folders")]
    public IEnumerable<File> DirFolders { get; set; }
}
