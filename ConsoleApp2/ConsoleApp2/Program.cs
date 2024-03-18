// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Console.WriteLine("Ola, Mundo!");
Console.WriteLine("Witaj, swiecie!");
Console.WriteLine("Hei maailma!");

int[] testVal= [2, 5, 5, 6, 4, 3];
int[] testVal2 = [1, 16, 5345, 9, 0, 23424, 42];

static int average(int[] ave)
{
    int sum = 0;
    int counter = 0;
    
    for (int t = 0; t < ave.Length; t++)
    {
        sum += ave[t];
        counter++;

    }

    int val = sum / counter;
    
    return val;
}

Console.WriteLine(average(testVal));


static int maximum(int[] max)
{
    int maxVal = 0;
    //int tmp = 0;

    for (int i = 0; i < max.Length; i++)
    {
        if (maxVal < max[i])
        {
            maxVal = max[i];
        }
    }

    return maxVal;
}

Console.WriteLine(maximum(testVal2));