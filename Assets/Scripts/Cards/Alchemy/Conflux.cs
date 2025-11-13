using UnityEngine;

[CreateAssetMenu(fileName = "Conflux", menuName = "ScriptableObjects/Alchemy/Conflux", order = 1)]
public class Conflux : AlchemyCard
{
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Conflux();
        base.OnActivation(manager);
    }
}
