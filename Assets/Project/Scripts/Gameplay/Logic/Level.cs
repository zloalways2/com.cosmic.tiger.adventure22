using System;

public static class Level
{
    public const int MinValue = 1;
    public const int MaxValue = 12;

    private static int _value;

    public static bool IsLastLevel => _value == MaxValue;

    public static int GetLevel()
    {
        return _value;
    }

    public static bool TrySetLevel(int level)
    {
        if (level <= MinValue || level > MaxValue) throw new ArgumentOutOfRangeException();

        _value = level;

        return true;
    }

    public static bool TrySetNextLevel()
    {
        if (_value == MaxValue) return false;

        _value++;

        return true;
    }
}