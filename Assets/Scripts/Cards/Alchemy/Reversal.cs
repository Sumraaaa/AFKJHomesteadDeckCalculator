using UnityEngine;

[CreateAssetMenu(fileName = "Reversal", menuName = "ScriptableObjects/Alchemy/Reversal", order = 1)]
public class Reversal : AlchemyCard
{
    public int multiplier = 0;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Reversal(multiplier);
        base.OnActivation(manager);
    }
}
