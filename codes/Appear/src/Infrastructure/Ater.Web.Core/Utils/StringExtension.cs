using Ater.Web.Core.Utils;

namespace Ater.Web.Core.Utils;

public static class StringExtension
{
    /// <summary>
    /// to hyphen style: HelloWord->hello-word
    /// </summary>
    /// <param name="str"></param>
    /// <param name="separator">分隔符</param>
    /// <returns></returns>
    public static string ToHyphen(this string str, char separator = '-')
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return string.Empty;
        }

        StringBuilder builder = new();
        var upperNumber = 0;
        for (var i = 0; i < str.Length; i++)
        {
            var item = str[i];
            // 连续的大写只添加一个-
            var pre = i >= 1 ? str[i - 1] : 'a';
            if (char.IsUpper(item) && char.IsLower(pre))
            {
                upperNumber++;
                if (upperNumber > 1)
                {
                    _ = builder.Append(separator);
                }
            }
            else if (item is '_' or ' ')
            {
                _ = builder.Append(separator);
            }
            _ = builder.Append(char.ToLower(item));
        }
        return builder.ToString();
    }

    /// <summary>
    /// to snake lower style: HelloWord->hello_word
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToSankeLower(this string str)
    {
        return str.ToHyphen('_');
    }

    /// <summary>
    /// to Pascalcase style:hello-word->HelloWord
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToPascalCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return string.Empty;
        }
        StringBuilder resultBuilder = new();
        foreach (var c in str)
        {
            _ = !char.IsLetterOrDigit(c) ? resultBuilder.Append(' ') : resultBuilder.Append(c);
        }
        var result = resultBuilder.ToString();
        result = string.Join(string.Empty, result.Split(' ').Select(r => r.ToUpperFirst()).ToArray());
        return result;
    }

    /// <summary>
    /// to camelcase style:hello-word->hellowWord
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return string.Empty;
        }
        str = str.ToPascalCase();
        return char.ToLower(str[0]) + str[1..];
    }
    public static string ToUpperFirst(this string str)
    {
        return string.IsNullOrWhiteSpace(str) ? string.Empty : char.ToUpper(str[0]) + str[1..];
    }

    /// <summary>
    /// 计算两字符串相似度
    /// <param name="source">原字符串</param>
    /// <param name="target">对比字符串</param>
    /// <returns>返回0-1.0</returns>
    /// </summary>
    public static double Similarity(this string source, string target)
    {
        if (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(target))
        {
            return 1.0;
        }
        else if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
        {
            return 0.0;
        }

        if (source.Equals(target))
        {
            return 1.0;
        }

        var stepsToSame = source.ComputeLevenshteinDistance(target);
        return 1.0 - stepsToSame / (double)Math.Max(source.Length, target.Length);
    }
    /// <summary>
    /// 计算两字符串转变距离
    /// </summary>
    public static int ComputeLevenshteinDistance(this string source, string target)
    {
        if (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(target))
        {
            return 1;
        }
        else if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
        {
            return 0;
        }

        if (source.Equals(target))
        {
            return source.Length;
        }

        var sourceWordCount = source.Length;
        var targetWordCount = target.Length;

        // Step 1
        if (sourceWordCount == 0)
        {
            return targetWordCount;
        }

        if (targetWordCount == 0)
        {
            return sourceWordCount;
        }

        var distance = new int[sourceWordCount + 1, targetWordCount + 1];

        // Step 2
        for (var i = 0; i <= sourceWordCount; distance[i, 0] = i++)
        {
            ;
        }

        for (var j = 0; j <= targetWordCount; distance[0, j] = j++)
        {
            ;
        }

        for (var i = 1; i <= sourceWordCount; i++)
        {
            for (var j = 1; j <= targetWordCount; j++)
            {
                // Step 3
                var cost = target[j - 1] == source[i - 1] ? 0 : 1;

                // Step 4
                distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
            }
        }

        return distance[sourceWordCount, targetWordCount];
    }
    /// <summary>
    /// 对比字符串相似度
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static double GetSimilar(this string source, string target)
    {
        string longerString, shorterString;
        if (source.Length > target.Length)
        {
            longerString = source;
            shorterString = target;
        }
        else
        {
            longerString = target;
            shorterString = source;
        }

        var sameNum = 0;
        for (var i = 0; i < shorterString.Length; i++)
        {
            foreach (var item in longerString)
            {
                if (shorterString[i] == item)
                {
                    sameNum++;
                    break;
                }
            }
        }
        return sameNum / shorterString.Length;
    }

    /// <summary>
    /// 字符串是否为 null/empty/whitespace
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEmpty(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    public static bool NotEmpty(this string? str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }
}
