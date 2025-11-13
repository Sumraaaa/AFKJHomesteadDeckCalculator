using UnityEngine;

[CreateAssetMenu(fileName = "Bake", menuName = "ScriptableObjects/BakeryCards/Bake", order = 1)]
public class Bake : BakeryCard
{
    public override void OnActivation(HomesteadManager manager)
    {
        manager.Bake();
        base.OnActivation(manager);
    }
}
