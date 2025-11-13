using UnityEngine;

[CreateAssetMenu(fileName = "ByTheRecipe", menuName = "ScriptableObjects/BakeryCards/ByTheRecipe", order = 1)]
public class ExactCook : BakeryCard
{
    public int recipeMultiplier = 0;
    public bool isLevel2 = false;

    public override void OnActivation(HomesteadManager manager)
    {
        manager.ExactCook(recipeMultiplier, isLevel2);
        base.OnActivation(manager);
    }
}
