using UnityEngine;

[CreateAssetMenu(fileName = "ForgeExpert", menuName = "ScriptableObjects/ForgeCards/ForgeExpert", order = 1)]
public class ForgeExpert : ForgeCard
{
    public int baseValue;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.AddValueToFutureCards<ForgeExpert>(bonusValue);
        manager.AddValueToFutureCards<Soulbind>(bonusValue);
        base.OnActivation(manager);
    }

    public override void ResetAddedValue()
    {
        base.ResetAddedValue();
        StartValue = baseValue;
    }
}
