using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CardSelector : MonoBehaviour
{

    public TMP_Dropdown KitchenDropDown;
    public TMP_Dropdown ForgeDropDown;
    public TMP_Dropdown AlchemyDropDown;
    public TMP_Dropdown EventDropDown;

    public void DisplayCurrentDropdown()
    {
        switch (HomesteadManager.Instance.itemAdjuster.Category)
        {
            case 0:
                KitchenDropDown.gameObject.SetActive(true);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(false);
                break;
            case 1:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(true);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(false);
                break;
            case 2:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(true);
                EventDropDown.gameObject.SetActive(false);
                break;
            case 3:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(true);
                break;
        }
    }

    public int GetCurrentSelectedCardIndex()
    {
        switch (HomesteadManager.Instance.itemAdjuster.Category)
        {
            case 0:
                return KitchenDropDown.value;
            case 1:
                return ForgeDropDown.value;
            case 2:
                return AlchemyDropDown.value;
            case 3:
                return EventDropDown.value;

        }
        return 0;
    }

    private TMP_Dropdown GetCurrentSelectedDropdown()
    {
        switch (HomesteadManager.Instance.itemAdjuster.Category)
        {
            case 0:
                return KitchenDropDown;
            case 1:
                return ForgeDropDown;
            case 2:
                return AlchemyDropDown;
            default:
                return null;
        }

    }
    public void SetSpecificDropdown(int category, int card)
    {
        switch (category)
        {
            case 0:
                KitchenDropDown.gameObject.SetActive(true);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(false);
                KitchenDropDown.value = card;
                break;
            case 1:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(true);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(false);
                ForgeDropDown.value = card;
                break;
            case 2:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(true);
                EventDropDown.gameObject.SetActive(false);
                AlchemyDropDown.value = card;
                break;
            case 3:
                KitchenDropDown.gameObject.SetActive(false);
                ForgeDropDown.gameObject.SetActive(false);
                AlchemyDropDown.gameObject.SetActive(false);
                EventDropDown.gameObject.SetActive(true);
                EventDropDown.value = card;
                break;
        }

        
    }
}
