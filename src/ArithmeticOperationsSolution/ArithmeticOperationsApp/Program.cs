namespace ArithmeticOperationsApp;

class Program
{
    static void Main(string[] args)
    {
        Number n = new("12");
        Number n2 = new("11");
        Console.WriteLine(n);
        Console.WriteLine(n2);
        Console.WriteLine("--");
        Number answer = Number.Add(n, n2);
        Console.WriteLine($"= {answer}");
    }
}

public class Digit
{
    public char Value { get; set; }

    public Digit(char digit)
    {
        Value = digit;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class Number
{
    List<Digit> _digits = [];

    public Digit this[int index]
    {
        get => _digits[index];
        set => _digits[index] = value;
    }

    public Number(string number)
    {
        _digits.AddRange(Parse(number));
    }

    public int Count => _digits.Count;

    public static Number Add(Number n1, Number n2)
    {
        var answer = 0;

        var count = 0; // Increment count in loop and add it to Math.Pow(10, 0);
        for (var i = n1.Count - 1; i >= 0; i--)
        {
            answer += (n1[i].Value - '0') + (n2[i].Value - '0') * (int)(Math.Pow(10, 0));
        }

        return new Number(answer.ToString());
    }

    private static IEnumerable<Digit> Parse(string number)
    {
        return from n in number where char.IsDigit(n) select new Digit(n);
    }

    public override string ToString()
    {
        return string.Join("", _digits);
    }
}