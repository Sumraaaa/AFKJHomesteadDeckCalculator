using UnityEngine;
[CreateAssetMenu(fileName = "Pyroburst", menuName = "ScriptableObjects/ForgeCards/Pyroburst", order = 1)]
public class Pyroburst : ForgeCard
{
    public int baseValue;
    public int triggeramount = 0;
    public int buffrequirement = 0;

    public override void ResetAddedValue()
    {
        base.ResetAddedValue();
        StartValue = baseValue;
    }
}
