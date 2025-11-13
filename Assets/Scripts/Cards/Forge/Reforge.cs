using UnityEngine;

[CreateAssetMenu(fileName = "Reforge", menuName = "ScriptableObjects/ForgeCards/Reforge", order = 1)]
public class Reforge : ForgeCard
{
    public int reforgeAmount = 0;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Reforge(reforgeAmount);
        base.OnActivation(manager);
    }
}
