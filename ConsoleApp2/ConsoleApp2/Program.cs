// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Console.WriteLine("Ola, Mundo!");
Console.WriteLine("Witaj, swiecie!");
Console.WriteLine("Hei maailma!");

int[] testVal= [2, 5, 5, 6, 4, 3];

static int average(int[] ave)
{
    int sum = 0;
    int counter = 0;
    
    for (int i = 0; i < ave.Length; i++)
    {
        sum += ave[i];
        counter++;

    }

    int val = sum / counter;
    
    return val;
}

Console.WriteLine(average(testVal));