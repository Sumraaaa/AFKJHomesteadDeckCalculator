using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemAdjuster : MonoBehaviour
{
    public int AmountOfCards = 0;

    public List<Item> KitchenItems;
    public List<Item> ForgeItems;
    public List<Item> AlchemyItems;
    public List<Item> EventItems;

    public TMP_Dropdown CategoryDropdown;
    public TMP_Dropdown KitchenDropdown;
    public TMP_Dropdown ForgeDropdown;
    public TMP_Dropdown AlchemyDropdown;
    public TMP_Dropdown EventDropdown;

    public TMP_InputField zeroInput;
    public TMP_InputField oneInput;
    public TMP_InputField twoInput;
    public TMP_InputField threeInput;
    public TMP_InputField fourInput;


    public Toggle buggedToggle;
    public TMP_Text warningText;
    private void Start()
    {
        UpdateItemSelection();
    }
    public void UpdateItemSelection()
    {
        MasterLoader.Instance.LoadPanelWithCorrectSize(GetCurrentItem().DeckSize);
        zeroInput.text = 0 + "";
        oneInput.text = GetCurrentItem().OneStarScore.ToString();
        twoInput.text = GetCurrentItem().TwoStarScore.ToString();
        threeInput.text = GetCurrentItem().ThreeStarScore.ToString();
        fourInput.text = GetCurrentItem().FourStarScore.ToString();
        /*
        if (GetCurrentItem().Name == "Copper Stewpot")
        {
            buggedToggle.gameObject.SetActive(true);
        }
        else
        {
            buggedToggle.gameObject.SetActive(false);
        }
        if(Category == 2)
        {
            warningText.gameObject.SetActive(true);
        }
        else
        {
            warningText.gameObject.SetActive(false);
        }*/
    }

    public Item GetCurrentItem()
    {
        switch (CategoryDropdown.value)
        {
            case 0:
                return KitchenItems[KitchenDropdown.value];
            case 1:
                return ForgeItems[ForgeDropdown.value];
            case 2:
                return AlchemyItems[AlchemyDropdown.value];
            case 3:
                return EventItems[EventDropdown.value];
        }
        return null;
    }

    public int GetCurrentItemIndex()
    {
        switch (CategoryDropdown.value)
        {
            case 0:
                return KitchenDropdown.value;
            case 1:
                return ForgeDropdown.value;
            case 2:
                return AlchemyDropdown.value;
            case 3:
                return EventDropdown.value;
        }
        return 0;
    }

    public TMP_Dropdown GetCurrentDropdown()
    {
        switch (CategoryDropdown.value)
        {
            case 0:
                return KitchenDropdown;
            case 1:
                return ForgeDropdown;
            case 2:
                return AlchemyDropdown;
            case 3:
                return EventDropdown;
        }
        return null;
    }

    public void DisplayCurrentDropdown()
    {
        switch (CategoryDropdown.value)
        {
            case 0:
                KitchenDropdown.gameObject.SetActive(true);
                ForgeDropdown.gameObject.SetActive(false);
                AlchemyDropdown.gameObject.SetActive(false);
                EventDropdown.gameObject.SetActive(false);
                break;
            case 1:
                KitchenDropdown.gameObject.SetActive(false);
                ForgeDropdown.gameObject.SetActive(true);
                AlchemyDropdown.gameObject.SetActive(false);
                EventDropdown.gameObject.SetActive(false);
                break;
            case 2:
                KitchenDropdown.gameObject.SetActive(false);
                ForgeDropdown.gameObject.SetActive(false);
                AlchemyDropdown.gameObject.SetActive(true);
                EventDropdown.gameObject.SetActive(false);
                break;
            case 3:
                KitchenDropdown.gameObject.SetActive(false);
                ForgeDropdown.gameObject.SetActive(false);
                AlchemyDropdown.gameObject.SetActive(false);
                EventDropdown.gameObject.SetActive(true);
                break;
        }
        HomesteadManager.Instance.UpdateCardSelectors();
        UpdateItemSelection();
        
        
    }

    public void SetSpecificItem(int cat, int item)
    {
        CategoryDropdown.value = cat;
        GetCurrentDropdown().value = item;
        DisplayCurrentDropdown();        
    }
    public int Category => CategoryDropdown.value;

    public void OnCategoryDropDown()
    {
        HomesteadManager.Instance.UpdateCardSelectors();
        DisplayCurrentDropdown();
    }

}
