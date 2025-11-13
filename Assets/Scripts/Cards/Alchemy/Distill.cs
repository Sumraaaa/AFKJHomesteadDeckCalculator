using UnityEngine;

[CreateAssetMenu(fileName = "Distill", menuName = "ScriptableObjects/Alchemy/Distill", order = 1)]
public class Distill : AlchemyCard
{
    public int multiplicationAmount = 1;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.MultiplyHighestColour(multiplicationAmount);
    }
}
