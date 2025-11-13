using UnityEngine;

[CreateAssetMenu(fileName = "Season", menuName = "ScriptableObjects/BakeryCards/Season", order = 1)]
public class Season : BakeryCard
{
    public int multiplicationAmount = 1;


    public override void OnActivation(HomesteadManager manager)
    {
        manager.MultiplyRandomColour(multiplicationAmount);
    }
}
