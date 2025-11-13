using UnityEngine;

[CreateAssetMenu(fileName = "Cut", menuName = "ScriptableObjects/BakeryCards/Cut", order = 1)]
public class Cut : BakeryCard
{
    public int MaxValue = 0;
    public bool isLevelSeven = false;
    public int repeatAmount = 0;
    public override int GetValue(HomesteadManager manager)
    {
        if(manager.isCurrentItemName("Salted Raisin") || manager.isCurrentItemName("Roasted Corn"))
            return MaxValue;
        else
            return Random.Range(StartValue, MaxValue + 1);
    }

    public override void OnActivation(HomesteadManager manager)
    {
        if (isLevelSeven)
            manager.CutCounter();
        base.OnActivation(manager);
    }
}
