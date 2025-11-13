using UnityEngine;

[CreateAssetMenu(fileName = "MultiForge", menuName = "ScriptableObjects/ForgeCards/MultiForge", order = 1)]
public class MultiForge : ForgeCard
{
    public int nextCardcount = 0;
    public int triggerAmount = 0;

    public override void OnActivation(HomesteadManager manager)
    {
        manager.MultiForge(nextCardcount, triggerAmount);
        base.OnActivation(manager);
    }
}
