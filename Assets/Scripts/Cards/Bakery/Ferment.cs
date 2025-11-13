using UnityEngine;

[CreateAssetMenu(fileName = "Ferment", menuName = "ScriptableObjects/BakeryCards/Ferment", order = 1)]
public class Ferment : BakeryCard
{
    public int fermentAmount = 1;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Ferment(fermentAmount);
        base.OnActivation(manager);
    }
}
