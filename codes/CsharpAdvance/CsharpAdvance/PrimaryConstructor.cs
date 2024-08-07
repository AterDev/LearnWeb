﻿namespace CsharpAdvance;
/// <summary>
/// 主构造函数
/// </summary>
/// <param name="nameFormatter"></param>
public class PrimaryConstructor(string nameFormatter)
{
    public required string Name { get; set; }
    private readonly string _nameFormatter = nameFormatter;

    public PrimaryConstructor(string nameFormatter, string name) : this(nameFormatter)
    {
        Name = name;
    }
}
