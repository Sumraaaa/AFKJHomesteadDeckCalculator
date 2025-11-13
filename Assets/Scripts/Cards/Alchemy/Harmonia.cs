using UnityEngine;

[CreateAssetMenu(fileName = "Harmonia", menuName = "ScriptableObjects/Alchemy/Harmonia", order = 1)]
public class Harmonia : AlchemyCard
{
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Harmonia();
        base.OnActivation(manager);
    }
}
