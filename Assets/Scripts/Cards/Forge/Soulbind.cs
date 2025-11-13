using UnityEngine;
[CreateAssetMenu(fileName = "Soulbind", menuName = "ScriptableObjects/ForgeCards/Soulbind", order = 1)]
public class Soulbind : ForgeCard
{
    public int baseValue = 0;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Soulbind();
        base.OnActivation(manager);
    }

    public int GetStartValue()
    {
        return StartValue;
    }

    public override void ResetAddedValue()
    {
        StartValue = baseValue;
        base.ResetAddedValue();
    }
}
