using System.Text;

var x = 1;
var y = 1;

Console.WriteLine("Input x axis lenght and press Enter:");

try
{
    x = int.Parse(Console.ReadLine());
}
catch
{
    throw new Exception("Bad parameter was input");
}

Console.WriteLine("Input Y axis lenght and press Enter:");

try
{
    y = int.Parse(Console.ReadLine());
}
catch
{
    throw new Exception("Bad parameter was input");
}


Console.WriteLine("Input rows with comma seperated values, then press enter for next row (i.e: 1,0,1,0)");

var rows = new List<string[]>();

for (var i = 0; i < y; i++) {
    var row = Console.ReadLine()?.Split(',');
    
    if (row.Length != x)
    {
        Console.WriteLine("Error: not enough values to fill matrix row.");
    }

    rows.Add(row);
}

var maxString = new StringBuilder();

for(var xIndex = 0; xIndex < x; xIndex++  ) 
{
    for (var yIndex = 0; yIndex < y; yIndex++)
    {
        maxString.Append($"{xIndex} {yIndex} {rows[xIndex][yIndex]}");
        maxString.Append(" ");
    }
}

Console.WriteLine("The resulting string found below was printed in a txt file in your documents folder with x and y parameters and the time of creation");
Console.WriteLine(maxString.ToString());

string docPath =
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"{x}_{y}_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.txt")))
{
    outputFile.WriteLine(maxString.ToString());
}

Console.WriteLine("Press any key to close the Calculator console app...");
Console.ReadLine();