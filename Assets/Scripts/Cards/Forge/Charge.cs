using UnityEngine;

[CreateAssetMenu(fileName = "Charge", menuName = "ScriptableObjects/ForgeCards/Charge", order = 1)]
public class Charge : ForgeCard
{
    public int ChargeAmount;
    public override int GetValue(HomesteadManager manager)
    {
        return base.GetValue(manager);
    }

    public override void OnActivation(HomesteadManager manager)
    {
        manager.Charge(ChargeAmount);
        base.OnActivation(manager);
    }
}
