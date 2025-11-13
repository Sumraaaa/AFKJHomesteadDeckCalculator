using UnityEngine;

[CreateAssetMenu(fileName = "HeatControl", menuName = "ScriptableObjects/BakeryCards/HeatControl", order = 1)]
public class HeatControl : BakeryCard
{

    public override int GetValue(HomesteadManager manager)
    {
        manager.HeatControl();
        return StartValue;
    }

    public override void OnActivation(HomesteadManager manager)
    {
        bool recursionActive = true;
        int retriggerTimes = manager.FermentCounter;

        for (int i = 0; i < retriggerTimes; i++)
        {
            manager.CurrentRoundCalc(this);
        }
            


        //Multiple recursions
        while (recursionActive)
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.5f)
            {
                manager.CurrentRoundCalc(this);
            }
            else
            {
                recursionActive = false;
            }
        }
    }
}
