using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        Dictionary<int, string> dialingCodes = GetEmptyDictionary();
        dialingCodes.Add(1, "United States of America");
        dialingCodes.Add(55, "Brazil");
        dialingCodes.Add(91, "India");
        return dialingCodes;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        Dictionary<int, string> dialingCodes = GetEmptyDictionary();
        dialingCodes.Add(countryCode, countryName);
        return dialingCodes;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        Dictionary<int, string> returnDic = existingDictionary;
        returnDic.Add(countryCode, countryName);
        return returnDic;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
            return existingDictionary[countryCode];
        return "";
    }
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        Dictionary<int, string> updatedDictionary = existingDictionary;
        if (CheckCodeExists(existingDictionary, countryCode))
        {
            updatedDictionary[countryCode] = countryName;
        }
        return updatedDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        Dictionary<int, string> returnDic = existingDictionary;
        if (returnDic.ContainsKey(countryCode))
            returnDic.Remove(countryCode);
        return returnDic;
    }
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        int longestNameLength = 0;
        string longestName = "";
        var dc = existingDictionary;

        if (existingDictionary.Count > 0)
        {
            foreach(KeyValuePair<int, string> e in dc)
            {
                if (e.Value.Length > longestNameLength)
                {
                    longestNameLength = e.Value.Length;
                    longestName = e.Value;
                }
            }
            return longestName;
        }
        else
            return "";
    }
}
