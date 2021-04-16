using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship 
{
    public string Rotate;
    public string Type;
    public int Dimension;
    public Vector2Int LDPoint;
    public int heals;
    public List<Vector2Int> MassTitle;


    public Ship()
    {
        Rotate = null;
        Dimension = -1;
        LDPoint = new Vector2Int(-1, -1);
        heals = 0; 
    }
    public Ship(string type,string rotate)
    {
        Rotate = rotate;
        Type = type;
        Dimension = SetType(type);
        LDPoint = new Vector2Int(-1, -1);
        heals 

    }
    public Ship(Ship ship) 
    {
        Rotate = ship.Rotate;
        Type = ship.Type;
        Dimension = ship.Dimension;
        LDPoint = ship.LDPoint;
        heals = ship.heals;
        MassTitle = ship.MassTitle;


    }
    private int SetType(string t)
    {
        switch (t)
        {
            case "One": { return 1; }
            case "Two": { return 2; }
            case "Tree": { return 3; }
            case "Fore": { return 4; }
        }
        return -1;
    }
    public static int HealsToInt(string t)
    {
        switch (t)
        {
            case "One": { return 100; }
            case "Two": { return 200; }
            case "Tree": { return 300; }
            case "Fore": { return 400; }
        }
        return -1;
    }
    public static string RotateToString(int Rotate)
    {
        string X = null;
        switch (Rotate)
        {
            case 0: { X = "Up"; break; }
            case 1: { X = "Down"; break; }
            case 2: { X = "Right"; break; }
            case 3: { X = "Left"; break; }

        }
        return X;
    }
    public static int RotateToInt(string Rotate)
    {
        int X = -1;
        switch (Rotate)
        {
            case "Up": { X = 0; break; }
            case "Down": { X = 1; break; }
            case "Right": { X = 2; break; }
            case "Left": { X = 3; break; }

        }
        return X;
    }

}
 