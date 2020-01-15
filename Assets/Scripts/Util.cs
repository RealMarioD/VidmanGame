
// Various random stuff used everywhere

using System;

public static class Util {
    private const double TOLERANCE = 0.001;

    public static bool EqualsFloat(this float n1, float n2) {
        return Math.Abs(n1 - n2) < TOLERANCE;
    }

    public static bool EqualsZero(this float n1) {
        return Math.Abs(n1) < TOLERANCE;
    }
}