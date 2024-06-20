using System;

namespace FbxSharp;

public struct FbxDateTime
{
    #region Public Member Functions

    public void Clear() => throw new NotImplementedException();

    public bool isValid() => throw new NotImplementedException();

    #endregion

    #region Static Public Member Functions

    public static FbxDateTime currentDateTimeGMT() =>
        throw new NotImplementedException();

    #endregion

    #region Constructors

    public FbxDateTime() :
        this(0, 0, 0, 0, 0, 0)
    {
    }

    public FbxDateTime(int pDay, int pMonth, int pYear, int pHour, int pMin,
        int pSec, int pMillisecond = 0)
    {
        setDate(pDay, pMonth, pYear);
        setTime(pHour, pMin, pSec, pMillisecond);
    }

    #endregion

    #region Boolean operation

    // public bool operator ==(const FbxDateTime  &pRHS)
    // public bool operator !=(const FbxDateTime  &pRHS)

    #endregion

    #region Access

    public void setDate(int pDay, int pMonth, int pYear)
    {
        Year = pYear;
        Month = pMonth;
        Day = pDay;
    }

    public void setTime(int pHour, int pMin, int pSec, int pMillisecond = 0)
    {
        Hour = pHour;
        Minute = pMin;
        Second = pSec;
        Millisecond = pMillisecond;
    }

    public int Year { get; private set; }
    public int Month { get; private set; }
    public int Day { get; private set; }
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public int Second { get; private set; }
    public int Millisecond { get; private set; }

    #endregion

    #region Operation with string

    public string toString() => ToString();

    public bool fromString(string s) => throw new NotImplementedException();

    #endregion
}
