using UnityEngine;

[CreateAssetMenu(fileName = "Fuse", menuName = "ScriptableObjects/Alchemy/Fuse", order = 1)]
public class Fuse : AlchemyCard
{
    public int pointDifference = 0;
    public int scoreAddedAtEnd = 0;
    public bool isLevel3 = false;
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Fuse(pointDifference, scoreAddedAtEnd, isLevel3);
        base.OnActivation(manager);
    }
}
