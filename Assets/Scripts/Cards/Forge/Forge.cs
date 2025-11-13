using UnityEngine;

[CreateAssetMenu(fileName = "Forge", menuName = "ScriptableObjects/ForgeCards/Forge", order = 1)]
public class Forge : ForgeCard
{
    public int baseValue;
    public override int GetValue(HomesteadManager manager)
    {
         return base.GetValue(manager);
    }

    public override void OnActivation(HomesteadManager manager)
    {
        manager.FirstForgeCardPassed();
        base.OnActivation(manager);
    }

    public override void ResetAddedValue()
    {
        base.ResetAddedValue();
        StartValue = baseValue;
    }
}
