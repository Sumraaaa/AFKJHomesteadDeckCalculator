using UnityEngine;

[CreateAssetMenu(fileName = "Enchant", menuName = "ScriptableObjects/Alchemy/Enchant", order = 1)]
public class Enchant : AlchemyCard
{
    public bool isLevelTwo = false;

    public override void OnActivation(HomesteadManager manager)
    {
        manager.Enchant(isLevelTwo, bonusValue);
    }
}
