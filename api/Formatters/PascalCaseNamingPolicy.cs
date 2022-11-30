using System.Text;
using System.Text.Json;

public class PascalCaseNamingPolicy : JsonNamingPolicy
{
    public static PascalCaseNamingPolicy Instance { get; } = new PascalCaseNamingPolicy();

    public override string ConvertName(string name)
    {
        return this.ToPascalCase(name);
    }

    String ToPascalCase(String s)
    {
        StringBuilder sb = new StringBuilder(s.Length);
        int a = 1, b = 1;
        bool toUpper = true;

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '-':
                case '_':
                    if (a != b)
                    {
                        sb.Append(s.Substring(a, b - a));
                    }
                    a = b = i + 2;
                    toUpper = true;
                    break;

                default:
                    if (toUpper)
                    {
                        sb.Append(char.ToUpper(s[i]));
                        toUpper = false;
                    }
                    else
                    {
                        b++;
                    }
                    break;
            }
        }

        if (a != b)
        {
            sb.Append(s.Substring(a, b - a));
        }

        return sb.ToString();
    }
}
