using UnityEngine;

[CreateAssetMenu(fileName = "Sharpening", menuName = "ScriptableObjects/ForgeCards/Sharpening", order = 1)]
public class Sharpening : ForgeCard
{
    public int sharpenAmount = 10;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Sharpen(sharpenAmount);
        base.OnActivation(manager);
    }
}
