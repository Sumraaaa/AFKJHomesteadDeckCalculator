using UnityEngine;

public class Card : ScriptableObject
{
    public int StartValue = 0;
    public int AddedValue = 0;
    
    public int bonusValue = 0;

    public int[] CardAmounts = new int[20];

    private int baseStartValue;

    
    public virtual int GetValue(HomesteadManager manager)
    {
        return StartValue + AddedValue;
    }

    public virtual void OnActivation(HomesteadManager manager)
    {

    }

    public virtual void ResetAddedValue()
    {
        AddedValue = 0;
    }
}
