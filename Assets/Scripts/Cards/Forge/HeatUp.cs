using UnityEngine;

[CreateAssetMenu(fileName = "HeatUp", menuName = "ScriptableObjects/ForgeCards/HeatUp", order = 1)]
public class HeatUp : ForgeCard
{
    public override void OnActivation(HomesteadManager manager)
    {
        manager.AddValueToFutureArtisanCards(bonusValue);
    }
}
