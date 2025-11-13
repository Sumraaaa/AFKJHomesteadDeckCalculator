using UnityEngine;

[CreateAssetMenu(fileName = "Crystallize", menuName = "ScriptableObjects/Alchemy/Crystallize", order = 1)]
public class Crystallize : AlchemyCard
{
    public int multiplicationAmount = 1;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.MultiplyLowestColour(multiplicationAmount);
    }
}
