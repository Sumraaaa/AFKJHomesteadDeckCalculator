using UnityEngine;

[CreateAssetMenu(fileName = "Ignite", menuName = "ScriptableObjects/ForgeCards/Ignite", order = 1)]
public class Ignite : ForgeCard
{
    public int multiplicationAmount = 1;


    public override void OnActivation(HomesteadManager manager)
    {
        manager.MultiplyRandomColour(multiplicationAmount);
    }
}
