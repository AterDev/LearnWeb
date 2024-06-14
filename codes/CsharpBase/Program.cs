

int GetMaxDivisor(int m, int n)
{
    if (m < n)
    {
        int temp = m;
        m = n;
        n = temp;
    }
    int r = m % n;
    while (r != 0)
    {
        m = n;
        n = r;
        r = m % n;
    }
    return n;
}

void Output(int m, int n)
{
    var result = GetMaxDivisor(m, n);
    Console.WriteLine($"{m} 和 {n} 的最大约数是: {result}");
}

Output(16, 24);
Output(39, 13);