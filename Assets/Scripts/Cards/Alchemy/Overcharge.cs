using UnityEngine;

[CreateAssetMenu(fileName = "Overcharge", menuName = "ScriptableObjects/Alchemy/Overcharge", order = 1)]
public class Overcharge : AlchemyCard
{
    public int multiplicator = 3;
    public int amountOfCharges = 2;

    public override void OnActivation(HomesteadManager manager)
    {
        manager.Overcharge(amountOfCharges, multiplicator);
        base.OnActivation(manager);
    }
}
