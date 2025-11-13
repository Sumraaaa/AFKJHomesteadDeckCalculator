using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public string Name;
    public int OneStarScore = 0;
    public int TwoStarScore = 0;
    public int ThreeStarScore = 0;
    public int FourStarScore = 0;

    public int DeckSize = 0;

    [Header("Wish Points")]
    public int ZeroStarWP = 0;
    public int OneStarWP = 0;
    public int TwoStarWP = 0;
    public int ThreeStarWP = 0;
    public int FourStarWP = 0;
}
