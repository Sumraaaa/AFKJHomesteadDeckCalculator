using UnityEngine;

[CreateAssetMenu(fileName = "SlowCook", menuName = "ScriptableObjects/BakeryCards/SlowCook", order = 1)]
public class SlowCook : BakeryCard
{
    public bool isLevelTwo = false;

    public override int GetValue(HomesteadManager manager)
    {
        return 0;
    }

    public override void OnActivation(HomesteadManager manager)
    {
        manager.SlowCook(isLevelTwo, StartValue);
    }
}
