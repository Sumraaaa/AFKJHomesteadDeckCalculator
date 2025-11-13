using UnityEngine;

[CreateAssetMenu(fileName = "Overload", menuName = "ScriptableObjects/Alchemy/Overload", order = 1)]
public class Overload : AlchemyCard
{
    public int randomMinus = 0;
    public bool isLevelTwo = false;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Overload(randomMinus, isLevelTwo);
        base.OnActivation(manager);
    }
}
