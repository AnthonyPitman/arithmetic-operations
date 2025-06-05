namespace ArithmeticOperationsApp;

class Program
{
    static void Main(string[] args)
    {
        Number n = new("9");
        Number n2 = new("9");
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

    public Number(string number) // TODO: consider making this an implicit operator so that it these are just created like Number n = "123"
    {
        _digits.AddRange(Parse(number));
    }

    public int Count => _digits.Count;

    // TODO: after unit tests, refactor
    public static Number Add(Number n1, Number n2)
    {
        var answer = 0;

        var count = 0;
        var carry = 0;
        for (var i = n1.Count - 1; i >= 0; i--)
        {
            var value = ((n1[i].Value - '0') + (n2[i].Value - '0') + carry);
            carry = value / 10;
            var temp = value % 10 * (int)(Math.Pow(10, count));
            answer += temp;
            count++;
        }

        if (carry > 0)
        {
            answer += carry * (int)(Math.Pow(10, count));
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