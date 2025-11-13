using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardAdjuster : MonoBehaviour
{
    [SerializeField] TMP_Dropdown KitchenLevel;
    [SerializeField] TMP_Dropdown ForgeLevel;
    [SerializeField] TMP_Dropdown AlchemyLevel;

    
    [Header("Kitchen")]
    [SerializeField] Cut Cut;
    [SerializeField] HeatControl HeatControl;
    [SerializeField] Season Season;
    [SerializeField] SlowCook SlowCook;
    [SerializeField] Ferment Ferment;
    [SerializeField] Bake Bake;
    [SerializeField] ExactCook ExactCook;
    [SerializeField] Banquet Banquet;

    [Header("Forge")]
    [SerializeField] Forge Forge;
    [SerializeField] ForgeExpert ForgeExpert;
    [SerializeField] HeatUp HeatUp;
    [SerializeField] Ignite Ignite;
    [SerializeField] Charge Charge;
    [SerializeField] MultiForge MultiForge;
    [SerializeField] Reforge Reforge;
    [SerializeField] Sharpening Sharpening;
    [SerializeField] Pyroburst Pyroburst;
    [SerializeField] Soulbind Soulbind;

    [Header("Alchemy")]
    [SerializeField] Ingredients Ingredients;
    [SerializeField] Grind Grind;
    [SerializeField] Distill Distill;
    [SerializeField] Crystallize Crystallize;
    [SerializeField] Enchant Enchant;
    [SerializeField] Fuse Fuse;
    [SerializeField] Overload Overload;
    [SerializeField] Overcharge Overcharge;
    [SerializeField] Harmonia Harmonia;
    [SerializeField] Reversal Reversal;
    [SerializeField] Conflux Conflux;

    [Header("KitchenDropdown")]
    [SerializeField] TMP_Dropdown CutDropdown;
    [SerializeField] TMP_Dropdown HeatControlDropdown;
    [SerializeField] TMP_Dropdown SeasonDropdown;
    [SerializeField] TMP_Dropdown SlowCookDropdown;
    [SerializeField] TMP_Dropdown FermentDropdown;
    [SerializeField] TMP_Dropdown BakeDropdown;
    [SerializeField] TMP_Dropdown ExactCookDropdown;
    [SerializeField] TMP_Dropdown BanquetDropdown;

    [Header("ForgeDropdown")]
    [SerializeField] TMP_Dropdown ForgeDropdown;
    [SerializeField] TMP_Dropdown ForgeExpertDropdown;
    [SerializeField] TMP_Dropdown HeatUpDropdown;
    [SerializeField] TMP_Dropdown IgniteDropdown;
    [SerializeField] TMP_Dropdown ChargeDropdown;
    [SerializeField] TMP_Dropdown MultiForgeDropdown;
    [SerializeField] TMP_Dropdown ReforgeDropdown;
    [SerializeField] TMP_Dropdown SharpeningDropdown;
    [SerializeField] TMP_Dropdown PyroburstDropdown;
    [SerializeField] TMP_Dropdown SoulbindDropdown;

    [Header("AlchemyDropdown")]
    [SerializeField] TMP_Dropdown IngredientsDropdown;
    [SerializeField] TMP_Dropdown GrindDropdown;
    [SerializeField] TMP_Dropdown DistillDropdown;
    [SerializeField] TMP_Dropdown CrystallizeDropdown;
    [SerializeField] TMP_Dropdown EnchantDropdown;
    [SerializeField] TMP_Dropdown FuseDropdown;
    [SerializeField] TMP_Dropdown OverloadDropdown;
    [SerializeField] TMP_Dropdown OverchargeDropdown;
    [SerializeField] TMP_Dropdown HarmoniaDropdown;
    [SerializeField] TMP_Dropdown ReversalDropdown;
    [SerializeField] TMP_Dropdown ConfluxDropdown;

    private void Start()
    {
        LoadCardLevel();
    }

    public void SaveChanges()
    {
        AdjustForge();
        AdjustForgeExpert();
        AdjustHeatUp();
        AdjustIgnite();
        AdjustCharge();
        AdjustMultiForge();
        AdjustReforge();
        AdjustSharpening();
        AdjustPyroburst();
        AdjustSoulbind();

        AdjustCut();
        AdjustHeatControl();
        AdjustSeason();
        AdjustSlowCook();
        AdjustFerment();
        AdjustBake();
        AdjustByExactCook();
        AdjustBanquet();

        AdjustIngredients();
        AdjustGrind();
        AdjustDistill();
        AdjustCrystallize();
        AdjustEnchant();
        AdjustFuse();
        AdjustOverload();
        AdjustOvercharge();
        AdjustHarmonia();
        AdjustReversal();
        AdjustConflux();

        SafeCardLevel();
    }

    private void AdjustForge()
    {
        switch (ForgeDropdown.options.Count - ForgeDropdown.value - 1)
        {
            case 0:
                Forge.StartValue = 1;
                Forge.baseValue = 1;
                break;
            case 1:
                Forge.StartValue = 2;
                Forge.baseValue = 2;
                break;
            case 2:
                Forge.StartValue = 3;
                Forge.baseValue = 3;
                break;
            case 3:
                Forge.StartValue = 5;
                Forge.baseValue = 5;
                break;
            case 4:
                Forge.StartValue = 10;
                Forge.baseValue = 10;
                break;
            case 5:
                Forge.StartValue = 15;
                Forge.baseValue = 15;
                break;
            case 6:
                Forge.StartValue = 20;
                Forge.baseValue = 20;
                break;
        }
    }
    private void AdjustForgeExpert()
    {
        switch (ForgeExpertDropdown.options.Count - ForgeExpertDropdown.value - 1)
        {
            case 0:
                ForgeExpert.StartValue = 3;
                ForgeExpert.bonusValue = 3;
                ForgeExpert.baseValue = 3;
                break;
            case 1:
                ForgeExpert.StartValue = 4;
                ForgeExpert.bonusValue = 3;
                ForgeExpert.baseValue = 4;
                break;
            case 2:
                ForgeExpert.StartValue = 4;
                ForgeExpert.bonusValue = 4;
                ForgeExpert.baseValue = 4;
                break;
            case 3:
                ForgeExpert.StartValue = 5;
                ForgeExpert.bonusValue = 4;
                ForgeExpert.baseValue = 5;
                break;
            case 4:
                ForgeExpert.StartValue = 5;
                ForgeExpert.bonusValue = 5;
                ForgeExpert.baseValue = 5;
                break;
            case 5:
                ForgeExpert.StartValue = 10;
                ForgeExpert.bonusValue = 5;
                ForgeExpert.baseValue = 10;
                break;
        }
    }
    private void AdjustHeatUp()
    {
        switch (HeatUpDropdown.options.Count - HeatUpDropdown.value - 1)
        {
            case 0:
                HeatUp.StartValue = 0;
                HeatUp.bonusValue = 3;
                break;
            case 1:
                HeatUp.StartValue = 0;
                HeatUp.bonusValue = 6;
                break;
            case 2:
                HeatUp.StartValue = 0;
                HeatUp.bonusValue = 10;
                break;
            case 3:
                HeatUp.StartValue = 0;
                HeatUp.bonusValue = 12;
                break;
            case 4:
                HeatUp.StartValue = 0;
                HeatUp.bonusValue = 14;
                break;
        }
    }
    private void AdjustIgnite()
    {
        switch (IgniteDropdown.options.Count - IgniteDropdown.value - 1)
        {
            case 0:
                Ignite.StartValue = 0;
                Ignite.multiplicationAmount = 2;
                break;
        }
    }
    private void AdjustCharge()
    {
        switch (ChargeDropdown.options.Count - ChargeDropdown.value - 1)
        {
            case 0:
                Charge.StartValue = 0;
                Charge.ChargeAmount = 1;
                break;
            case 1:
                Charge.StartValue = 0;
                Charge.ChargeAmount = 3;
                break;
            case 2:
                Charge.StartValue = 0;
                Charge.ChargeAmount = 100;
                break;
            case 3:
                Charge.StartValue = 5;
                Charge.ChargeAmount = 100;
                break;
        }
    }

    private void AdjustMultiForge()
    {
        switch (MultiForgeDropdown.options.Count - MultiForgeDropdown.value - 1)
        {
            case 0:
                MultiForge.nextCardcount = 1;
                MultiForge.triggerAmount = 2;
                break;
            case 1:
                MultiForge.nextCardcount = 1;
                MultiForge.triggerAmount = 3;
                break;
        }
    }

    private void AdjustReforge()
    {
        switch (ReforgeDropdown.options.Count - ReforgeDropdown.value - 1)
        {
            case 0:
                Reforge.reforgeAmount = 3;
                break;
            case 1:
                Reforge.reforgeAmount = 10;
                break;
            case 2:
                Reforge.reforgeAmount = 15;
                break;
        }
    }

    private void AdjustSharpening()
    {
        switch (SharpeningDropdown.options.Count - SharpeningDropdown.value - 1)
        {
            case 0:
                Sharpening.sharpenAmount = 10;
                break;
            case 1:
                Sharpening.sharpenAmount = 12;
                break;
        }
    }
    private void AdjustPyroburst()
    {
        switch (PyroburstDropdown.options.Count - PyroburstDropdown.value - 1)
        {
            case 0:
                Pyroburst.StartValue = 12;
                Pyroburst.baseValue = 12;
                Pyroburst.triggeramount = 1;
                Pyroburst.buffrequirement = 2;
                break;
            case 1:
                Pyroburst.StartValue = 18;
                Pyroburst.baseValue = 18;
                Pyroburst.triggeramount = 1;
                Pyroburst.buffrequirement = 2;
                break;

        }
    }

    private void AdjustSoulbind()
    {
        switch (SoulbindDropdown.options.Count - SoulbindDropdown.value - 1)
        {
            case 0:
                Soulbind.StartValue = 0;
                Soulbind.baseValue = 0;
                break;
            case 1:
                Soulbind.StartValue = 5;
                Soulbind.baseValue = 5;
                break;
        }
    }
    private void AdjustCut()
    {
        switch (CutDropdown.options.Count - CutDropdown.value - 1)
        {
            case 0:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 1;
                Cut.MaxValue = 1;
                break;
            case 1:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 2;
                Cut.MaxValue = 2;
                break;
            case 2:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 3;
                Cut.MaxValue = 3;
                break;
            case 3:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 4;
                Cut.MaxValue = 8;
                break;
            case 4:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 8;
                Cut.MaxValue = 12;
                break;
            case 5:
                Cut.isLevelSeven = false;
                Cut.repeatAmount = 0;
                Cut.StartValue = 10;
                Cut.MaxValue = 15;
                break;
            case 6:
                Cut.isLevelSeven = true;
                Cut.repeatAmount = 1;
                Cut.StartValue = 10;
                Cut.MaxValue = 15;
                break;
            case 7:
                Cut.isLevelSeven = true;
                Cut.repeatAmount = 1;
                Cut.StartValue = 13;
                Cut.MaxValue = 18;
                break;
            case 8:
                Cut.isLevelSeven = true;
                Cut.repeatAmount = 2;
                Cut.StartValue = 13;
                Cut.MaxValue = 18;
                break;
        }
    }
    private void AdjustHeatControl()
    {
        switch (HeatControlDropdown.options.Count - HeatControlDropdown.value - 1)
        {
            case 0:
                HeatControl.StartValue = 3;
                break;
            case 1:
                HeatControl.StartValue = 4;
                break;
            case 2:
                HeatControl.StartValue = 6;
                break;
            case 3:
                HeatControl.StartValue = 8;
                break;
            case 4:
                HeatControl.StartValue = 10;
                break;
            case 5:
                HeatControl.StartValue = 12;
                break;
            case 6:
                HeatControl.StartValue = 15;
                break;
            case 7:
                HeatControl.StartValue = 18;
                break;
        }
    }
    private void AdjustSeason()
    {
        switch (SeasonDropdown.options.Count - SeasonDropdown.value - 1)
        {
            case 0:
                Season.StartValue = 0;
                Season.multiplicationAmount = 2;
                break;
        }
    }
    private void AdjustSlowCook()
    {
        switch (SlowCookDropdown.options.Count - SlowCookDropdown.value - 1)
        {
            case 0:
                SlowCook.StartValue = 4;
                SlowCook.isLevelTwo = false;
                break;
            case 1:
                SlowCook.StartValue = 2;
                SlowCook.isLevelTwo = true;
                break;
            case 2:
                SlowCook.StartValue = 4;
                SlowCook.isLevelTwo = true;
                break;
            case 3:
                SlowCook.StartValue = 5;
                SlowCook.isLevelTwo = true;
                break;
            case 4:
                SlowCook.StartValue = 6;
                SlowCook.isLevelTwo = true;
                break;
        }
    }

    private void AdjustFerment()
    {
        switch (FermentDropdown.options.Count - FermentDropdown.value - 1)
        {
            case 0:
                Ferment.fermentAmount = 1;
                break;
            case 1:
                Ferment.fermentAmount = 2;
                break;
            case 2:
                Ferment.fermentAmount = 3;
                break;
        }
    }

    private void AdjustBake()
    {
        switch (BakeDropdown.options.Count - BakeDropdown.value - 1)
        {
            case 0:
                Bake.StartValue = 0;
                break;
            case 1:
                Bake.StartValue = 10;
                break;

        }
    }

    private void AdjustByExactCook()
    {
        switch (ExactCookDropdown.options.Count - ExactCookDropdown.value - 1)
        {
            case 0:
                ExactCook.recipeMultiplier = 2;
                ExactCook.isLevel2 = false;
                break;
            case 1:
                ExactCook.recipeMultiplier = 2;
                ExactCook.isLevel2 = true;
                break;
        }
    }

    private void AdjustGrind()
    {
        switch (GrindDropdown.options.Count - GrindDropdown.value - 1)
        {
            case 0:
                Grind.StartValue = 2;
                Grind.negativeValue = 0;
                break;
            case 1:
                Grind.StartValue = 3;
                Grind.negativeValue = 0;
                break;
            case 2:
                Grind.StartValue = 4;
                Grind.negativeValue = 2;
                break;
            case 3:
                Grind.StartValue = 8;
                Grind.negativeValue = 3;
                break;
            case 4:
                Grind.StartValue = 11;
                Grind.negativeValue = 4;
                break;
            case 5:
                Grind.StartValue = 15;
                Grind.negativeValue = 5;
                break;
            case 6:
                Grind.StartValue = 20;
                Grind.negativeValue = 6;
                break;
            case 7:
                Grind.StartValue = 35;
                Grind.negativeValue = 7;
                break;
        }
    
    }
    private void AdjustIngredients()
    {
        switch (IngredientsDropdown.options.Count - IngredientsDropdown.value - 1)
        {
            case 0:
                Ingredients.StartValue = 4;
                Ingredients.negativeValue = 0;
                break;
            case 1:
                Ingredients.StartValue = 6;
                Ingredients.negativeValue = 0;
                break;
            case 2:
                Ingredients.StartValue = 10;
                Ingredients.negativeValue = 2;
                break;
            case 3:
                Ingredients.StartValue = 15;
                Ingredients.negativeValue = 3;
                break;
            case 4:
                Ingredients.StartValue = 20;
                Ingredients.negativeValue = 4;
                break;
            case 5:
                Ingredients.StartValue = 30;
                Ingredients.negativeValue = 5;
                break;
            case 6:
                Ingredients.StartValue = 50;
                Ingredients.negativeValue = 7;
                break;
        }
    }

    private void AdjustDistill()
    {
        switch (DistillDropdown.options.Count - DistillDropdown.value - 1)
        {
            case 0:
                Distill.multiplicationAmount = 2;
                break;
        }
    }
    private void AdjustCrystallize()
    {
        switch (CrystallizeDropdown.options.Count - CrystallizeDropdown.value - 1)
        {
            case 0:
                Crystallize.multiplicationAmount = 2;
                break;
        }
    }

    private void AdjustEnchant()
    {
        switch (EnchantDropdown.options.Count - EnchantDropdown.value - 1)
        {
            case 0:
                Enchant.StartValue = 8;
                Enchant.bonusValue = 1;
                Enchant.isLevelTwo = false;
                break;
            case 1:
                Enchant.StartValue = 16;
                Enchant.bonusValue = 1;
                Enchant.isLevelTwo = true;
                break;
            case 2:
                Enchant.StartValue = 30;
                Enchant.bonusValue = 1;
                Enchant.isLevelTwo = true;
                break;
            case 3:
                Enchant.StartValue = 40;
                Enchant.bonusValue = 2;
                Enchant.isLevelTwo = true;
                break;
            case 4:
                Enchant.StartValue = 60;
                Enchant.bonusValue = 3;
                Enchant.isLevelTwo = true;
                break;
        }
    }

    private void AdjustFuse()
    {
        switch (FuseDropdown.options.Count - FuseDropdown.value - 1)
        {
            case 0:
                Fuse.pointDifference = 10;
                Fuse.scoreAddedAtEnd = 5;
                Fuse.isLevel3 = false;
                break;
            case 1:
                Fuse.pointDifference = 20;
                Fuse.scoreAddedAtEnd = 10;
                Fuse.isLevel3 = false;
                break;
            case 2:
                Fuse.pointDifference = 50;
                Fuse.scoreAddedAtEnd = 20;
                Fuse.isLevel3 = true;
                break;
            case 3:
                Fuse.pointDifference = 80;
                Fuse.scoreAddedAtEnd = 30;
                Fuse.isLevel3 = true;
                break;
        }
    }

    private void AdjustOverload()
    {
        switch (OverloadDropdown.options.Count - OverloadDropdown.value - 1)
        {
            case 0:
                Overload.StartValue = 40;
                Overload.randomMinus = 3;
                Overload.isLevelTwo = false;
                break;
            case 1:
                Overload.StartValue = 60;
                Overload.randomMinus = 1;
                Overload.isLevelTwo = true;
                break;
            case 2:
                Overload.StartValue = 100;
                Overload.randomMinus = 3;
                Overload.isLevelTwo = true;
                break;
        }
    }
    private void AdjustOvercharge()
    {
        switch (OverchargeDropdown.options.Count - OverchargeDropdown.value - 1)
        {
            case 0:
                Overcharge.amountOfCharges = 2;
                Overcharge.multiplicator = 3;
                break;
            case 1:
                Overcharge.amountOfCharges = 3;
                Overcharge.multiplicator = 4;
                break;
        }
    }
    private void AdjustHarmonia()
    {
        switch (HarmoniaDropdown.options.Count - HarmoniaDropdown.value - 1)
        {
            case 0:
                Harmonia.StartValue = 0;
                break;
        }
    }

    private void AdjustReversal()
    {
        switch (ReversalDropdown.options.Count - ReversalDropdown.value - 1)
        {
            case 0:
                Reversal.multiplier = 1;
                break;
            case 1:
                Reversal.multiplier = 2;
                break;
        }
    }
    private void AdjustConflux()
    {

    }

    private void AdjustBanquet()
    {

    }
    private void SafeCardLevel()
    {
        PlayerPrefs.SetInt("HeatControl", HeatControlDropdown.value);
        PlayerPrefs.SetInt("Cut", CutDropdown.value);
        PlayerPrefs.SetInt("Season", SeasonDropdown.value);
        PlayerPrefs.SetInt("SlowCook", SlowCookDropdown.value);
        PlayerPrefs.SetInt("Ferment", FermentDropdown.value);
        PlayerPrefs.SetInt("Bake", BakeDropdown.value);
        PlayerPrefs.SetInt("ExactCook", ExactCookDropdown.value);
        PlayerPrefs.SetInt("Banquet", BanquetDropdown.value);

        PlayerPrefs.SetInt("ForgeExpert", ForgeExpertDropdown.value);
        PlayerPrefs.SetInt("Forge", ForgeDropdown.value);
        PlayerPrefs.SetInt("Ignite", IgniteDropdown.value);
        PlayerPrefs.SetInt("HeatUp", HeatUpDropdown.value);
        PlayerPrefs.SetInt("Charge", ChargeDropdown.value);
        PlayerPrefs.SetInt("MultiForge", MultiForgeDropdown.value);
        PlayerPrefs.SetInt("Reforge", ReforgeDropdown.value);
        PlayerPrefs.SetInt("Sharpening", SharpeningDropdown.value);
        PlayerPrefs.SetInt("Pyroburst", PyroburstDropdown.value);
        PlayerPrefs.SetInt("Soulbind", SoulbindDropdown.value);

        PlayerPrefs.SetInt("Ingredients", IngredientsDropdown.value);
        PlayerPrefs.SetInt("Grind", GrindDropdown.value);
        PlayerPrefs.SetInt("Distill", DistillDropdown.value);
        PlayerPrefs.SetInt("Crystallize", CrystallizeDropdown.value);
        PlayerPrefs.SetInt("Enchant", EnchantDropdown.value);
        PlayerPrefs.SetInt("Fuse", FuseDropdown.value);
        PlayerPrefs.SetInt("Overload", OverloadDropdown.value);
        PlayerPrefs.SetInt("Overcharge", OverchargeDropdown.value);
        PlayerPrefs.SetInt("Harmonia", HarmoniaDropdown.value);
        PlayerPrefs.SetInt("Reversal", ReversalDropdown.value);
        PlayerPrefs.SetInt("Conflux", ConfluxDropdown.value);

        PlayerPrefs.SetInt("KitchenLevel", KitchenLevel.value);
        PlayerPrefs.SetInt("ForgeLevel", ForgeLevel.value);
        PlayerPrefs.SetInt("AlchemyLevel", AlchemyLevel.value);
    }

    private void LoadCardLevel()
    {
        HeatControlDropdown.value = PlayerPrefs.GetInt("HeatControl", 0);
        CutDropdown.value = PlayerPrefs.GetInt("Cut", 0);
        SeasonDropdown.value = PlayerPrefs.GetInt("Season", 0);
        SlowCookDropdown.value = PlayerPrefs.GetInt("SlowCook", 0);
        FermentDropdown.value = PlayerPrefs.GetInt("Ferment", 0);
        BakeDropdown.value = PlayerPrefs.GetInt("Bake", 0);
        ExactCookDropdown.value = PlayerPrefs.GetInt("ExactCook", 0);
        BanquetDropdown.value = PlayerPrefs.GetInt("Banquet", 0);

        ForgeExpertDropdown.value = PlayerPrefs.GetInt("ForgeExpert", 0);
        ForgeDropdown.value = PlayerPrefs.GetInt("Forge", 0);
        IgniteDropdown.value = PlayerPrefs.GetInt("Ignite", 0);
        HeatUpDropdown.value = PlayerPrefs.GetInt("HeatUp", 0);
        ChargeDropdown.value = PlayerPrefs.GetInt("Charge", 0);
        MultiForgeDropdown.value = PlayerPrefs.GetInt("MultiForge", 0);
        ReforgeDropdown.value = PlayerPrefs.GetInt("Reforge", 0);
        SharpeningDropdown.value = PlayerPrefs.GetInt("Sharpening", 0);
        PyroburstDropdown.value = PlayerPrefs.GetInt("Pyroburst", 0);
        SoulbindDropdown.value = PlayerPrefs.GetInt("Soulbind", 0);

        IngredientsDropdown.value = PlayerPrefs.GetInt("Ingredients", 0);
        GrindDropdown.value = PlayerPrefs.GetInt("Grind", 0);
        DistillDropdown.value = PlayerPrefs.GetInt("Distill", 0);
        CrystallizeDropdown.value = PlayerPrefs.GetInt("Crystallize", 0);
        EnchantDropdown.value = PlayerPrefs.GetInt("Enchant", 0);
        FuseDropdown.value = PlayerPrefs.GetInt("Fuse", 0);
        OverloadDropdown.value = PlayerPrefs.GetInt("Overload", 0);
        OverchargeDropdown.value = PlayerPrefs.GetInt("Overcharge", 0);
        HarmoniaDropdown.value = PlayerPrefs.GetInt("Harmonia", 0);
        ReversalDropdown.value = PlayerPrefs.GetInt("Reversal", 0);
        ConfluxDropdown.value = PlayerPrefs.GetInt("Conflux", 0);

        KitchenLevel.value = PlayerPrefs.GetInt("KitchenLevel", 0);
        ForgeLevel.value = PlayerPrefs.GetInt("ForgeLevel", 0);
        AlchemyLevel.value = PlayerPrefs.GetInt("AlchemyLevel", 0);
    }

    public int GetCurrentCategoryLevel(int category)
    {
        switch (category)
        {
            case 0:
                return KitchenLevel.options.Count - KitchenLevel.value - 1;
            case 1:
                return ForgeLevel.options.Count - ForgeLevel.value - 1;
            case 2:
                return AlchemyLevel.options.Count - AlchemyLevel.value - 1;
            case 3:
                return 14;
            default:
                return 0;
        }
    }

    public bool IsCardActive(int categoryIndex, int ItemIndex)
    {
        bool isCardActive = true;

        switch (categoryIndex)
        {
            case 0: //kitchen
                switch(ItemIndex)
                {
                    case 0:
                        isCardActive = CutDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 1:
                        isCardActive = HeatControlDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 2:
                        isCardActive = SeasonDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 3:
                        isCardActive = SlowCookDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 4:
                        isCardActive = FermentDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 5:
                        isCardActive = BakeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 6:
                        isCardActive = ExactCookDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 7:
                        isCardActive = BanquetDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                }
                break;

            case 1: //Forge
                switch (ItemIndex)
                {
                    case 0:
                        isCardActive = ForgeExpertDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 1:
                        isCardActive = ForgeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 2:
                        isCardActive = HeatUpDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 3:
                        isCardActive = IgniteDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 4:
                        isCardActive = ChargeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 5:
                        isCardActive = MultiForgeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 6:
                        isCardActive = ReforgeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 7:
                        isCardActive = SharpeningDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 8:
                        isCardActive = PyroburstDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 9:
                        isCardActive = SoulbindDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                }
                break;

            case 2: // Alchemy
                switch (ItemIndex)
                {
                    case 0:
                        isCardActive = IngredientsDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 1:
                        isCardActive = GrindDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 2:
                        isCardActive = DistillDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 3:
                        isCardActive = CrystallizeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 4:
                        isCardActive = EnchantDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 5:
                        isCardActive = FuseDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 6:
                        isCardActive = OverloadDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 7:
                        isCardActive = OverchargeDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 8:
                        isCardActive = HarmoniaDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 9:
                        isCardActive = ReversalDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                    case 10:
                        isCardActive = ConfluxDropdown.transform.parent.GetChild(2).GetComponent<Toggle>().isOn;
                        break;
                }
                break;
            default:
                break;
        }

        return isCardActive;
    }
}
