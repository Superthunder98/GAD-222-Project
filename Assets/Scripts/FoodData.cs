using UnityEngine;

public class FoodData : MonoBehaviour
{
    public foodId FoodType = foodId.Null;

    public enum foodId 
    {
        Null, // default
        Testing_BL,
        Testing_BLU,
        Testing_Red,
    }
}
