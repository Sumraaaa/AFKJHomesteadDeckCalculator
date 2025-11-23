using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HomesteadManager : MonoBehaviour
{
    public static HomesteadManager Instance;

    public int OptimizationIterationCount = 2000;

    [SerializeField] GameObject CalculatingText;
    //public List<Card> AvailableCards;

    public List<Card> KitchenCards;
    public List<Card> ForgeCards;
    public List<Card> AlchemyCards;
    public List<Card> EventCards;

    //public List<TMP_Dropdown> Dropdowns;

    public List<Panel> Panels;

    [Header("UI")]
    public Slider iterationSlider;
    public TMP_Text SliderValueDisplay;

    public TMP_Text AverageText;
    public TMP_Text VarianceText;
    public TMP_Text StandardDeviation;
    public TMP_Text MinText;
    public TMP_Text MaximumText;
    public TMP_Text WishPointText;

    public GameObject Stars;

    private Panel ActivePanel;

    public UI_ItemAdjuster itemAdjuster;
    public UI_CardAdjuster cardAjuster;
    private List<int> resultsList = new();

    private List<Card> cards = new();
    private List<Card> tempCards = new();

    private List<bool> debuffTypes = new();

    private int leftColour = 1;
    private int rightColour = 1;

    private int currentCard = 0;
    public int CurrentCard { get { return currentCard; } }

    private void Awake()
    {   
        if(isActiveAndEnabled)
            Instance = this;
    }
    public void Instantiate()
    {
        Instance = this;
    }
    private void Start()
    {
        SetActivePanel();
    }
    public void SetActivePanel()
    {

        for (int i = 0; i < Panels.Count; i++)
        {
            if (Panels[i].isActiveAndEnabled)
                ActivePanel = Panels[i];
        }
    }
    private int ForgeExpertCounter = 0;
    public void AddValueToFutureCards<T>(int amount) where T : Card
    {
        for (int i = 0; i < tempCards.Count; i++)
        {
            if (i < tempCards.Count && tempCards[i] is T specialCard)
            {
                specialCard.AddedValue += amount;
                
            }

        }
        ForgeExpertCounter++;
    }
    public void AddValueToFutureArtisanCards(int amount)
    {
        for (int i = 0; i < tempCards.Count; i++)
        {
            if (tempCards[i] is ForgeCard specialCard)
            {
                if (specialCard.isArtisan)
                    specialCard.AddedValue += amount;
                else if (specialCard is Soulbind sb)
                    specialCard.AddedValue += amount;
            }
        }
        HeatUpCounter++;
    }

    public void MultiplyRandomColour(int amount)
    {
        float chance = Random.Range(0f, 1f);
        if (chance < 0.5f)
            leftColour = leftColour * amount;
        else
            rightColour = rightColour * amount;
    }
    public void MultiplyHighestColour(int amount)
    {
        if (isCurrentItemName("Earth Antidote") )
        {
            amount *= 2;
        }
        if (leftColour > rightColour)
        {
            leftColour *= amount;
        }
        else if (rightColour > leftColour)
        {
            rightColour *= amount;
        }
        else
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.5f)
                leftColour *= amount;
            else
                rightColour *= amount;
        }    
    }
    public void MultiplyLowestColour(int amount)
    {
        if (overchargeAmount > 0)
        {
            amount *= overchargeMultiplier;
            if (leftColour > rightColour)
            {
                leftColour *= amount;
            }
            else if (rightColour > leftColour)
            {
                rightColour *= amount;
            }
            else
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.5f)
                    leftColour *= amount;
                else
                    rightColour *= amount;
            }

        }
        else
        {
            if (leftColour < rightColour)
            {
                leftColour *= amount;
            }
            else if (rightColour < leftColour)
            {
                rightColour *= amount;
            }
            else
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.5f)
                    leftColour *= amount;
                else
                    rightColour *= amount;
            }
        }
    }
    //private bool hasEarthAntidoted = false;

    private string thirdlastCardName = null;
    private string secondlastCardName = null;
    private string lastCardName = null;
    private string currentCardName = null;
    private Card lastCard = null;

    private bool hasSweetbeanJuiced = false;
    private int cardCounter = 0;
    private bool isTea = false;
    private int CalculateResults()
    {
        //int result = 0;
        leftColour = 1;
        rightColour = 1;

        artisanCounter = 0;

        artisanMultiCounter = 0;
        multiForgeTriggerAmount = 0;

        ReforgeBonus = 0;
        ReforgeAmount = 0;

        SoulbindMultiforge = 0;

        sharpenValue = 0;
        seenCards.Clear();

        slowCookCounter = 0;
        slowCooklvltwo = false;
        slowcookAmount = 0;

        howManyHeatControls = 0;
        howManyAritsans = 0;
        HeatUpCounter = 0;
        ForgeExpertCounter = 0;

        enchantCounter = 0;
        enchantlvltwo = false;
        enchantAmount = 0;

        fermCounter = 0;

        didWeBake = false;
        cutCounter = 0;

        exactCookAmount = 0;
        recipeMultiplier = 1;
        recipeSuccess = false;
        recipeLevel2 = false;
        recipelvl2Success = false;

    hasFirstForgeCardPassed = false;
        firstForgeAmount = 0;

        fuseAmountDifference = 0;
        fuseAmountAdded = 0;
        didWeFuse = false;
        fuseLevel3 = false;

        amountOfOverloads = 0;
        overloadPointsMinus = 0;
        overloadlvltwo = false;

        overchargeAmount = 0;
        overchargeMultiplier = 0;

        didWeHarmonize = false;
        didWeReversal = false;
        reversalMultiplier = 1;

        tempCards = new(cards);
        debuffTypes.Clear();

        thirdlastCardName = null;
        secondlastCardName = null;
        lastCardName = null;
        lastCard = null;
        currentCardName = null;

        cardCounter = 0;
        hasSweetbeanJuiced = false;
        isTea = false;
        foreach (var c in tempCards)
        {
            c.ResetAddedValue(); 
        }

        if (isCurrentItemName("Fireward Ring"))
            leftColour += 15;

        
        while (tempCards.Count > 0)
        {


            int cardInteger = Random.Range(0, tempCards.Count);
            
            Card card = tempCards[cardInteger];

            if (card is Banquet && lastCard != null)
            {
                card = lastCard;
            }

            lastCard = card;

            //ByTheRecipe
            thirdlastCardName = secondlastCardName;
            secondlastCardName = lastCardName;
            lastCardName = currentCardName;       // shift previous
            currentCardName = card.name;


            if (lastCardName != null && card.name == lastCardName )
            {
                recipelvl2Success = true;
            }
            if (lastCardName != null && secondlastCardName != null && card.name == lastCardName && card.name == secondlastCardName )
            {
                recipeSuccess = true;
            }
            
            if(isCurrentItemName("Sweetbean Juice"))
            {
                if (thirdlastCardName != null && secondlastCardName != null && lastCardName != null && card.name == lastCardName && card.name == secondlastCardName && card.name == thirdlastCardName)
                    hasSweetbeanJuiced = true;
            }   

            if(isCurrentItemName("Lightproof Brush") && !(card is Reforge) && !(card is Sharpening))
            {
                if (!seenCards.Contains(card.name))
                {
                    if (card is Soulbind s)
                    {
                        SoulbindMultiforge += 2;

                    }
                    else
                    {
                        CurrentRoundCalc(card);
                        card.OnActivation(this);
                    }
                }
            }

            if (isCurrentItemName("Midnight Tea"))
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.25f)
                {
                    if (card is Cut)
                    {
                        IncreaseRandomColour(card.GetValue(this));
                    }
                    else if (card is HeatControl)
                    {
                        IncreaseRandomColour(card.GetValue(this));
                    }
                    else if (!(card is SlowCook))
                    {

                        CurrentRoundCalc(card);
                        card.OnActivation(this);
                    }
                }
            }

            if (isCurrentItemName("Armored Bodysuit") && cardCounter < 3 && !(card is Reforge) && !(card is Sharpening))
            {

                CurrentRoundCalc(card);
                card.OnActivation(this);
                cardCounter++;
            }

            if ((isCurrentItemName("Copper Stewpot") || isCurrentItemName("Firefang Sword")) && card is ForgeExpert fe)
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.3f)
                {
                    int value = fe.GetValue(this);
                    if (fe.isArtisan && artisanCounter > 0)
                    {

                        leftColour += value;
                        rightColour += value;
                    }
                    else
                    {
                        float leftchance = Random.Range(0f, 1f);
                        if (leftchance < 0.5f)
                            leftColour += value;
                        else
                            rightColour += value;
                    }
                    if (itemAdjuster.buggedToggle.isOn)
                        card.StartValue = value;
                    fe.OnActivation(this);
                }
            }

            if(card is Pyroburst P )
            {
                int pyroBurstBuffAmount = 0;
                if (HeatUpCounter > 0)
                    pyroBurstBuffAmount++;
                if (artisanCounter > 0)
                    pyroBurstBuffAmount++;
                if (artisanMultiCounter > 0)
                    pyroBurstBuffAmount++;

                if (pyroBurstBuffAmount >= P.buffrequirement)
                {
                   int value = P.GetValue(this);
                    CurrentRoundCalc(P);
                    if (itemAdjuster.buggedToggle.isOn)
                    {
                        card.StartValue = value;
                    }
                    P.OnActivation(this);

                    //second bugged retrigger
                    CurrentRoundCalc(P);
                    if (itemAdjuster.buggedToggle.isOn)
                    {
                        card.StartValue = value;
                    }
                    P.OnActivation(this);

                    //SoulbindMultiforge += 2;
                }
            }
            
            if (isCurrentItemName("Protective Pick Hammer") && (card is Pyroburst || card is Forge || card is ForgeExpert))
            {
                int hammerBuffAmount = 0;
                if (HeatUpCounter > 0)
                    hammerBuffAmount++;
                if (artisanCounter > 0)
                    hammerBuffAmount++;
                if (artisanMultiCounter > 0)
                    hammerBuffAmount++;

                if (hammerBuffAmount >= 2)
                {
                    int pvalue = card.GetValue(this);
                    CurrentRoundCalc(card);
                    if (itemAdjuster.buggedToggle.isOn)
                    {
                        card.StartValue = pvalue;
                    }
                    card.OnActivation(this);

                    /*
                    //second bugged retrigger
                    CurrentRoundCalc(P);
                    if (itemAdjuster.buggedToggle.isOn)
                    {
                        card.StartValue = value;
                    }
                    P.OnActivation(this);
                    */
                }
            }
            //Multiforge
            if (card is ForgeCard forgeC && forgeC.isArtisan && artisanMultiCounter > 0)
            {

                if (artisanCounter < multiForgeTriggerAmount * artisanMultiCounter && artisanCounter != 0)
                {
                    artisanCounter = multiForgeTriggerAmount * artisanMultiCounter + 1;
                }
                for (int i = 0; i < multiForgeTriggerAmount * artisanMultiCounter; i++)
                {

                    int value = forgeC.GetValue(this);
                    CurrentRoundCalc(forgeC);
                    if (itemAdjuster.buggedToggle.isOn)
                    {
                        card.StartValue = value;
                    }
                    forgeC.OnActivation(this);

                }
                artisanMultiCounter = 0;
            }
            if (card is Soulbind sb)
            {
                int value = sb.GetValue(this) - ForgeExpertCounter/2 * 5;
                    //Debug.Log("Soulbinding " + SoulbindMultiforge + "  value: " + value);
                for (int i = 0; i < SoulbindMultiforge; i++)
                {
                    if (artisanCounter > 0)
                    {
                        leftColour += value;
                        rightColour += value;
                    }
                    else
                        IncreaseRandomColour(value);
                    card.OnActivation(this);
                }

            }

            CurrentRoundCalc(card);
            card.OnActivation(this);
            
            if (isCurrentItemName("Carved Box") && firstForgeAmount >= 1)
            {
                hasFirstForgeCardPassed = true;
            }
            else if (isCurrentItemName("Fireproof Helm") && firstForgeAmount >= 3)
            {

                hasFirstForgeCardPassed = true;
            }

            //Sharpen
            if (card is ForgeCard)
            {
                seenCards.Add(card.name);
            }

            tempCards.RemoveAt(cardInteger);
            if(overchargeAmount > 0)
                overchargeAmount--;
        }
        
        if (isCurrentItemName("Dried Mushroom") && howManyHeatControls >= 7)
        {
            leftColour += 3;
            rightColour += 3;
        }
        if(isCurrentItemName("Warm Stone Armor") && howManyAritsans >= 6)
        {
            leftColour += 3;
            rightColour += 3;
        }

        FuseCheck();
        BakeCheck();
        ByTheRecipeCheck();
        if(isCurrentItemName("Healthy Candied Skewer"))
        {
            if (leftColour < rightColour)
                rightColour = leftColour;
            else
                leftColour = rightColour;
        }
        if (isCurrentItemName("Odd Sweet"))
            OddSweet();

        if(isCurrentItemName("Frost Antidote"))
        {
            if (leftColour < rightColour)
            {
                if (leftColour * 3 < rightColour)
                {
                    rightColour *= 2;
                }
            }
            else if (leftColour > rightColour)
            {
                if (leftColour > rightColour * 3)
                {
                    leftColour *= 2;
                }
            }
        }

        if (isCurrentItemName("Wood Incense"))
        {
            if (leftColour < rightColour)
            {
                if (leftColour * 5 < rightColour)
                {
                    rightColour *= 3;
                }
            }
            else if (leftColour > rightColour)
            {
                if (leftColour > rightColour * 5)
                {
                    leftColour *= 3;
                }
            }
        }

        if (hasSweetbeanJuiced)
        {
            Debug.Log("Sweetbean juiced");
            IncreaseBothColours(20);

        }

        return leftColour * rightColour;
    }
    
    private void FuseCheck()
    {
        if (didWeFuse && Mathf.Abs(leftColour - rightColour) < fuseAmountDifference)
        {           
            leftColour += fuseAmountAdded;
            rightColour += fuseAmountAdded;
            if (fuseLevel3)
            {
                int pointDifference = Mathf.Abs(leftColour - rightColour);
                if (leftColour > rightColour)
                    leftColour -= pointDifference;
                else if (rightColour > leftColour)
                    rightColour -= pointDifference;

                for (int i = 0; i < pointDifference; i++)
                {
                    float chance = Random.Range(0f, 1f);
                    if (chance < 0.5f)
                        leftColour += 1;
                    else
                        rightColour += 1;
                }
            }

        }
    }
    private void BakeCheck()
    {
        if (didWeBake)
        {
            int pointDifference = Mathf.Abs(leftColour - rightColour);
            if (leftColour > rightColour)
                leftColour -= pointDifference;
            else if (rightColour > leftColour)
                rightColour -= pointDifference;

            for (int i = 0; i < pointDifference; i++)
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.5f)
                    leftColour += 1;
                else
                    rightColour += 1;
            }
        }
    }

    private void ByTheRecipeCheck()
    {
        if(recipeLevel2 && recipelvl2Success)
        {
            for (int i = 0; i < exactCookAmount; i++)
            {
                MultiplyRandomColour(recipeMultiplier);
            }
        }
        else if(recipeSuccess)
        {

            for (int i = 0; i < exactCookAmount; i++)
            {
                MultiplyRandomColour(recipeMultiplier);
            }
        }
    }
    private void OddSweet()
    {
        if (Mathf.Abs(leftColour - rightColour) < 5)
        {
            leftColour += 5;
            rightColour += 5;
        }
    }
    private int howManyAritsans = 0;
    private int HeatUpCounter = 0;
    public void ArtisanTriggered()
    {
        howManyAritsans++;
    }
    private int artisanCounter = 0;
    public void Charge(int amount)
    {
        artisanCounter = amount;
    }
    private int artisanMultiCounter = 0;
    private int multiForgeTriggerAmount = 0;
    public void MultiForge(int howManyCards, int retriggerAmount)
    {
        artisanMultiCounter += howManyCards;
        multiForgeTriggerAmount = retriggerAmount;
        SoulbindMultiforge += retriggerAmount;

    }
    private int ReforgeAmount = 0;
    private int ReforgeBonus = 0;
    public void Reforge(int buffamount)
    {
        ReforgeBonus = buffamount;
        ReforgeAmount += 1;
    }
    public void ReforgeTrigger()
    {
        for (int i = 0; i < ReforgeAmount; i++)
        {
            leftColour += ReforgeBonus;
            rightColour += ReforgeBonus;   
        }
        if (isCurrentItemName("Armored Bodysuit") && cardCounter < 3)
        {
            leftColour += ReforgeBonus;
            rightColour += ReforgeBonus;
            cardCounter++;
        }
    }
    private int sharpenValue = 0;
    private List<string> seenCards = new();
    public void Sharpen(int value)
    {
        sharpenValue += value;
    }

    private int SoulbindMultiforge = 0;
    public void Soulbind()
    { 
        /*
        foreach (string cardName in seenCards)
        {
            Card c = ForgeCards.FirstOrDefault(so => so.name == cardName.Replace("(Clone)", "").Trim());
            if (c is ForgeExpert fc)
                fc.OnActivation(this);
            //else if (c is MultiForge mfc)
            //    mfc.OnActivation(this);
            else if (c is HeatUp hc)
                hc.OnActivation(this);
            else if (c is Charge cc)
                cc.OnActivation(this);

        }*/
    }

    private int slowCookCounter = 0;
    private bool slowCooklvltwo = false;
    private int slowcookAmount = 0;
    public void SlowCook(bool lvltwo, int amount)
    {
        slowCookCounter++;

        slowCooklvltwo = lvltwo;
        slowcookAmount = amount;
    }
    private int fermCounter = 0;
    public int FermentCounter => fermCounter;
    public void Ferment(int amount)
    {
        fermCounter = amount;
    }
    private int howManyHeatControls = 0;
    public void HeatControl()
    {
        howManyHeatControls++;
        for (int i = 0; i < slowCookCounter; i++)
        {
            if (slowCooklvltwo)
            {
                if (isCurrentItemName("Midnight Tea"))
                {
                    float chance = Random.Range(0f, 1f);
                    if (chance < 0.25f)
                    {
                        leftColour += slowcookAmount;
                        rightColour += slowcookAmount;
                    }
                }
                leftColour += slowcookAmount;
                rightColour += slowcookAmount;
            }
            else
            {
                float chance = Random.Range(0f, 1f);
                if (chance < 0.5f)
                    leftColour += slowcookAmount;
                else
                    rightColour += slowcookAmount;
            }
        }      
    }
    private bool recipeSuccess = false;
    private bool recipelvl2Success = false;
    private int exactCookAmount = 0;
    private int recipeMultiplier = 1;
    private bool recipeLevel2 = false;
    public void ExactCook(int amount, bool isLevel2)
    {
        recipeMultiplier = amount;
        exactCookAmount++;
        recipeLevel2 = isLevel2;
    }
    public void EnchantAndOverloadProc()
    {
        for (int i = 0; i < debuffTypes.Count; i++)
        {
            if (debuffTypes[i])
                EnchantProc();
            else
                OverloadTrigger();
        }
    }

    private int enchantCounter = 0;
    private bool enchantlvltwo = false;
    private int enchantAmount = 0;
    public void Enchant(bool lvltwo, int amount)
    {
        enchantCounter++;

        enchantlvltwo = lvltwo;
        enchantAmount = amount;

        debuffTypes.Add(true);
    }

    public void EnchantProc()
    {

        if (enchantlvltwo)
        {
            ReduceBothColours(enchantAmount);
        }
        else
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.5f)
                ReduceLowestColour(enchantAmount);
            else
                ReduceHighestColour(enchantAmount);
        }

    }
    private int amountOfOverloads = 0;
    private int overloadPointsMinus = 0;
    private bool overloadlvltwo = false;
    public void Overload(int pointsMinus, bool level2)
    {
        amountOfOverloads += 1;
        overloadPointsMinus = pointsMinus;
        overloadlvltwo = level2;
        debuffTypes.Add(false);
    }
    public void OverloadTrigger()
    {
        if (overloadlvltwo)
        {

            ReduceBothColours(overloadPointsMinus);

        }
        else
        {

            ReduceRandomColour(overloadPointsMinus);

        }
    }
    private int overchargeAmount = 0;
    private int overchargeMultiplier = 0;
    public void Overcharge(int amount, int multiplicator)
    {
        overchargeAmount = amount + 1;
        overchargeMultiplier = multiplicator;
    }

    private int fuseAmountDifference = 0;
    private int fuseAmountAdded = 0;
    private bool didWeFuse = false;
    private bool fuseLevel3 = false;
    public void Fuse(int difference, int added, bool isLevel3)
    {
        fuseAmountDifference = difference;
        fuseAmountAdded += added;
        didWeFuse = true;
        fuseLevel3 = isLevel3;
    }

    private bool didWeHarmonize = false;
    //private bool HarmonizeUsedUp = false;
    public void Harmonia()
    {
        didWeHarmonize = true;
    }
    private bool didWeReversal = false;
    //private bool ReversalUsedUP = false;
    private int reversalMultiplier = 1;
    public void Reversal(int multiplier)
    {
        reversalMultiplier = multiplier;
        didWeReversal = true;
    }

    public void Conflux()
    {
        if (rightColour > leftColour)
            rightColour += leftColour / 2;
        else
            leftColour += rightColour / 2;
    }

    private bool didWeBake = false;
    public void Bake()
    {
        didWeBake = true;
    }
    private int cutCounter = 0;
    public void CutCounter()
    {
        cutCounter++;
    }

    
    public void CurrentRoundCalc(Card c)
    {
        //Reforge
        if (c is ForgeCard reforgeCheck && reforgeCheck.isArtisan)
            ReforgeTrigger();
        //Sharpen
        if (c is ForgeCard && !seenCards.Contains(c.name))
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.5f)
                leftColour += sharpenValue;
            else
                rightColour += sharpenValue;
        }
        if (c is ForgeCard fc && (fc.isArtisan) && artisanCounter > 0)
        {
            int value = fc.GetValue(this);
            leftColour += value;
            rightColour += value;
            artisanCounter--;
        }
        else if(c is Forge f && isCurrentItemName("Carved Box") && !hasFirstForgeCardPassed)
        {
            int value = f.GetValue(this);
            leftColour += value;
            rightColour += value;
        }
        else if (c is Forge f2 && isCurrentItemName("Fireproof Helm") && !hasFirstForgeCardPassed)
        {
            int value = f2.GetValue(this);
            leftColour += value;
            rightColour += value;
        }
        else if (c is Soulbind sb)
        {
            int value = sb.GetValue(this);
            if (artisanCounter > 0)
            {
                leftColour += value;
                rightColour += value;
            }
            else
                IncreaseRandomColour(value);
          
        }
        else if(c is AlchemyCard alc)
        {
            AlchemyCounterCheck();
            EnchantAndOverloadProc();
            if (alc is Grind g)
            {
                int negativevalue = g.negativeValue;
                int value = g.GetValue(this);
                if (isCurrentItemName("Earth Antidote"))
                {
                    negativevalue *= 2;
                }
                if (isCurrentItemName("Warming Incense"))
                {
                    if (leftColour > rightColour)
                    {

                        IncreaseLowestRightColour(value);
                        leftColour -= negativevalue;
                        if (leftColour < 1)
                            leftColour = 1;
                    }
                    else if (rightColour > leftColour)
                    {
                        IncreaseLowestLeftColour(value);
                        rightColour -= negativevalue;
                        if (rightColour < 1)
                            rightColour = 1;
                    }
                    else
                    {
                        if (overchargeAmount > 0)
                        {
                            leftColour += value * overchargeMultiplier;
                            leftColour -= negativevalue;
                            if (leftColour < 1)
                                leftColour = 1;
                        }
                        else
                        {

                            rightColour += value;
                            leftColour -= negativevalue;
                            if (leftColour < 1)
                                leftColour = 1;
                        }
                    }
                    EnchantAndOverloadProc();
                }
                if (leftColour > rightColour)
                {
                    IncreaseLowestRightColour(value);
                    leftColour -= negativevalue;
                    if (leftColour < 1)
                        leftColour = 1;
                }
                else if (rightColour > leftColour)
                {
                    IncreaseLowestLeftColour(value);
                    rightColour -= negativevalue;
                    if (rightColour < 1)
                        rightColour = 1;
                }
                else
                {
                    if (overchargeAmount > 0)
                    {
                        leftColour += value * overchargeMultiplier;
                        leftColour -= negativevalue;
                        if (leftColour < 1)
                            leftColour = 1;

                    }
                    else
                    {

                        rightColour += value;
                        leftColour -= negativevalue;
                        if (leftColour < 1)
                            leftColour = 1;
                    }
                }

            }
            else if (alc is Ingredients ing)
            {   
                int amount = ing.GetValue(this);
                if (isCurrentItemName("Calmwind Incense"))
                {
                    
                    IncreaseHighestColour(amount);
                    ReduceLowestColour(ing.negativeValue);

                    EnchantProc();
                    OverloadTrigger();
                }

                IncreaseHighestColour(amount);
                ReduceLowestColour(ing.negativeValue);
                
            }
            else if (alc is Enchant e)
            {
                IncreaseLowestColour(e.GetValue(this));
            }
            else if (alc is Overload o)
            {
                int amount = o.GetValue(this);
                //overload doesnt work with earth antidote so we need to compensate     
                IncreaseHighestColour(amount);
            }
        }
        else if (c is Cut cut) 
        {
            for (int i = 0; i < cutCounter; i++)
            {
                for (int j = 0; j < cut.repeatAmount; j++)
                {
                    IncreaseRandomColour(c.GetValue(this));
                }           
            }
            IncreaseRandomColour(c.GetValue(this));
        }
        else
        {
            int value = c.GetValue(this);
            IncreaseRandomColour(value);
        }
        if (!(c is Cut))
        {
            cutCounter = 0;
        }

        //if (c is ForgeCard fCard && fCard.isArtisan)
          // ReforgeTrigger();
    }

    private void IncreaseRandomColour(int amount)
    {
        float chance = Random.Range(0f, 1f);
        if (chance < 0.5f)
            leftColour += amount;
        else
            rightColour += amount;
    }
    private void ReduceRandomColour(int amount)
    {
        float chance = Random.Range(0f, 1f);
        if (chance < 0.5f)
        {
            leftColour -= amount;
            if (leftColour < 1)
                leftColour = 1;
        }
        else
        {
            rightColour -= amount;
            if (rightColour < 1)
                rightColour = 1;
        }

        
    }

    private void ReduceLowestColour(int amount)
    {
        if(didWeReversal)
        {
            IncreaseHighestColour(amount * reversalMultiplier);
        }
        else
        {
            if (leftColour < rightColour)
            {
                leftColour -= amount;
                if (leftColour < 1)
                    leftColour = 1;
            }
            else
            {
                rightColour -= amount;
                if (rightColour < 1)
                    rightColour = 1;
            }
        }
        
    }

    private void ReduceHighestColour(int amount)
    {
        if (isCurrentItemName("Earth Antidote"))
        {
            amount *= 2;
        }
        if (leftColour > rightColour)
        {
            leftColour -= amount;
            if (leftColour < 1)
                leftColour = 1;
        }
        else
        {
            rightColour -= amount;
            if (rightColour < 1)
                rightColour = 1;
        }
    }




    private void IncreaseLowestColour(int amount)
    {
        if (overchargeAmount > 0)
        {
            amount *= overchargeMultiplier;
            if (leftColour > rightColour)
            {
                leftColour += amount;
            }
            else
            {
                rightColour += amount;
            }

        }
        else
        {

            if (leftColour < rightColour)
            {
                leftColour += amount;
            }
            else
            {
                rightColour += amount;
            }
        }
    }

    private void IncreaseLowestLeftColour(int amount)
    {
        if (overchargeAmount > 0)
        {
            amount *= overchargeMultiplier;
            if (leftColour > rightColour)
            {
                leftColour += amount;
            }
            else
            {
                rightColour += amount;
            }

        }
        else
        {
            leftColour += amount;

        }
    }
    private void IncreaseLowestRightColour(int amount)
    {
        if (overchargeAmount > 0)
        {
            amount *= overchargeMultiplier;
            if (leftColour > rightColour)
            {
                leftColour += amount;
            }
            else
            {
                rightColour += amount;
            }

        }
        else
        {
            rightColour += amount;

        }
    }

    private void IncreaseHighestColour(int amount)
    {
        //Exception to overload is at overload section of calculation
        if (isCurrentItemName("Earth Antidote"))
        {
            amount *= 2;
        }
        if (leftColour > rightColour)
        {
            leftColour += amount;
        }
        else
        {
            rightColour += amount;
        }
    }

    private void ReduceBothColours(int amount)
    {
        if (isCurrentItemName("Earth Antidote"))
        {
            amount *= 2;
        }
        if (didWeHarmonize)
        {
            ReduceHighestColour(amount);
        }
        else if (didWeReversal)
        {
            IncreaseHighestColour(amount * reversalMultiplier);
        }
        else
        {
            ReduceLowestColour(amount);
            ReduceHighestColour(amount);
        }
    }
    private void IncreaseBothColours(int amount)
    {
        IncreaseHighestColour(amount);
        IncreaseLowestColour(amount);
    }

    private void AlchemyCounterCheck()
    {
        if (isCurrentItemName("Calming Warmdust") || isCurrentItemName("Soothing Tonic"))
        {
            if (leftColour > rightColour)
                leftColour += 3;
            else
                rightColour += 3;
        }
        else if (isCurrentItemName("Warmdust") || isCurrentItemName("Illusion Potion"))
        {
            if (leftColour < rightColour)
                leftColour += 1;
            else
                rightColour += 1;
        }
    }

    public bool isCurrentItemName(string name)
    {
        return itemAdjuster.GetCurrentItem().Name == name;
    }
    private bool hasFirstForgeCardPassed = false;
    private int firstForgeAmount = 0;
    public void FirstForgeCardPassed()
    {
        firstForgeAmount += 1;
    }
    
    public void CalculateDeck()
    {
        

        resultsList.Clear();
        cards.Clear();
        CreateDeck();

        

        for (int i = 0; i < iterationSlider.value; i++)
        {
            resultsList.Add(CalculateResults());
        }

        double average = resultsList.Average();
        AverageText.text = "The average is: " + average;

        double variance = resultsList.Average(v => System.Math.Pow(v - (float)average, 2));
        VarianceText.text = "";
        double stdDev = System.Math.Sqrt(variance);
        StandardDeviation.text = "The standard deviation is: " + stdDev;

        float minresult = resultsList.Min();
        MinText.text = "The lowest amount is: " + minresult;
        float maxresult = resultsList.Max();
        MaximumText.text = "The highest amount is: " + maxresult;


        float zeroStarCutoff = float.Parse(Stars.transform.GetChild(0).GetComponent<TMP_InputField>().text);
        int zeroCounter = 0;

        float oneStarCutoff = float.Parse(Stars.transform.GetChild(1).GetComponent<TMP_InputField>().text);
        int oneCounter = 0;

        float twoStarCutoff = float.Parse(Stars.transform.GetChild(2).GetComponent<TMP_InputField>().text);
        int twoCounter = 0;

        float threeStarCutoff = float.Parse(Stars.transform.GetChild(3).GetComponent<TMP_InputField>().text);
        int threeCounter = 0;

        float fourStarCutoff = float.Parse(Stars.transform.GetChild(4).GetComponent<TMP_InputField>().text);
        int fourCounter = 0;

        for (int i = 0; i < resultsList.Count; i++)
        {
            if (resultsList[i] < fourStarCutoff)
            {
                if (resultsList[i] < threeStarCutoff)
                {
                    if (resultsList[i] < twoStarCutoff)
                    {
                        if (resultsList[i] < oneStarCutoff)
                        {
                            if (resultsList[i] < zeroStarCutoff)
                            {

                            }
                            else
                                zeroCounter++;
                        }
                        else
                            oneCounter++;
                    }
                    else
                        twoCounter++;
                }
                else
                    threeCounter++;
            }
            else
                fourCounter++;
        }


        float zeroPercentage = Mathf.Round(zeroCounter / (float)iterationSlider.value * 1000) / 10f;
        float onePercentage = Mathf.Round(oneCounter / (float)iterationSlider.value * 1000) / 10f;
        float twoPercentage = Mathf.Round(twoCounter / (float)iterationSlider.value * 1000) / 10f;
        float threePercentage = Mathf.Round(threeCounter / (float)iterationSlider.value * 1000) / 10f;
        float fourPercentage = Mathf.Round(fourCounter / (float)iterationSlider.value * 1000) / 10f;


        Stars.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().text = zeroPercentage + "%";
        Stars.transform.GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = onePercentage + "%";
        Stars.transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = twoPercentage + "%";
        Stars.transform.GetChild(3).GetChild(2).GetComponent<TMP_Text>().text = threePercentage + "%";
        Stars.transform.GetChild(4).GetChild(2).GetComponent<TMP_Text>().text = fourPercentage + "%";

        Item currentItem = itemAdjuster.GetCurrentItem();
        WishPointText.text = "Average Wishpoints: " + (zeroPercentage * currentItem.ZeroStarWP + onePercentage * currentItem.OneStarWP + twoPercentage * currentItem.TwoStarWP + threePercentage * currentItem.ThreeStarWP + fourPercentage * currentItem.FourStarWP)/(zeroPercentage+onePercentage+twoPercentage+threePercentage+fourPercentage);
        CalculatingText.SetActive(false);
    }

    private void CreateDeck()
    {

        switch (itemAdjuster.Category)
        {
            case 0:
                for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()))
                    {
                        Card newCard = ScriptableObject.Instantiate(KitchenCards[ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()]);
                        cards.Add(newCard);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()))
                    {
                        Card newCard = ScriptableObject.Instantiate(ForgeCards[ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()]);
                        cards.Add(newCard);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()))
                    {
                        Card newCard = ScriptableObject.Instantiate(AlchemyCards[ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()]);
                        cards.Add(newCard);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
                {
                    Card newCard = ScriptableObject.Instantiate(EventCards[ActivePanel.cardSelectors[i].GetCurrentSelectedCardIndex()]);
                    cards.Add(newCard);
                }
                break;
        }
    }

    public void UpdateCardSelectors()
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            for (int j = 0; j < Panels[i].cardSelectors.Count; j++)
            {
                Panels[i].cardSelectors[j].DisplayCurrentDropdown();
            }
        }
    }

    
    public void OnSliderValueChanged()
    {
        SliderValueDisplay.text = iterationSlider.value.ToString();
    }





    public void CalculateOptimalDeck()
    {
        StartCoroutine(CalculateOptimalDeckRoutine());
    }
    public IEnumerator CalculateOptimalDeckRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                    {
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);
                    }
                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                    {
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                    }
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                    {
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                    }
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }

        

        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();

        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }
            permutationResults.Add(resultsList.Average());

            if (i % 20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);

        

        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }

    public void CalculateHighScoreDeck()
    {
        StartCoroutine(CalculateHighScoreDeckRoutine());
    }
    public IEnumerator CalculateHighScoreDeckRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);
                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }



        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();

        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }
            permutationResults.Add(resultsList.Max());

            if(i %20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);



        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }
    public void CalculateBestWishPointDeck()
    {
        StartCoroutine(CalculateBestWishPointDeckRoutine());
    }
    public IEnumerator CalculateBestWishPointDeckRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);

                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }

        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);


        List<double> permutationResults = new List<double>();
        Item currentItem = itemAdjuster.GetCurrentItem();
        double MaxValue = 0;

        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }



            int zeroStarCutoff = 0;
            int zeroCounter = 0;

            int oneStarCutoff = currentItem.OneStarScore;
            int oneCounter = 0;

            int twoStarCutoff = currentItem.TwoStarScore;
            int twoCounter = 0;

            int threeStarCutoff = currentItem.ThreeStarScore;
            int threeCounter = 0;

            int fourStarCutoff = currentItem.FourStarScore;
            int fourCounter = 0;

            for (int k = 0; k < resultsList.Count; k++)
            {
                if (resultsList[k] < fourStarCutoff)
                {
                    if (resultsList[k] < threeStarCutoff)
                    {
                        if (resultsList[k] < twoStarCutoff)
                        {
                            if (resultsList[k] < oneStarCutoff)
                            {
                                if (resultsList[k] < zeroStarCutoff)
                                {

                                }
                                else
                                    zeroCounter++;
                            }
                            else
                                oneCounter++;
                        }
                        else
                            twoCounter++;
                    }
                    else
                        threeCounter++;
                }
                else
                    fourCounter++;
            }


            float zeroPercentage = Mathf.Round(zeroCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float onePercentage = Mathf.Round(oneCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float twoPercentage = Mathf.Round(twoCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float threePercentage = Mathf.Round(threeCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float fourPercentage = Mathf.Round(fourCounter / (float)OptimizationIterationCount * 1000) / 10f;


            double result = (zeroPercentage * currentItem.ZeroStarWP + onePercentage * currentItem.OneStarWP + twoPercentage * currentItem.TwoStarWP + threePercentage * currentItem.ThreeStarWP + fourPercentage * currentItem.FourStarWP) / (zeroPercentage + onePercentage + twoPercentage + threePercentage + fourPercentage);
            permutationResults.Add(result);
            if(result > MaxValue)
            {
                MaxValue = result;
            }

            if (i % 20 == 0)
                yield return null;
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        //double maxValue = permutationResults.Max();
        //int maxIndex = permutationResults.IndexOf(maxValue);

        

        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }

    private List<List<Card>> GetUniqueCombinations(Dictionary<Card, int> limits, int length)
    {
        List<List<Card>> results = new List<List<Card>>();
        var cardNames = new List<Card>(limits.Keys); // fixed order

        GenerateCombinations(new List<Card>(), limits, cardNames, 0, length, results);
        return results;
    }

    private void GenerateCombinations(List<Card> current, Dictionary<Card, int> available, List<Card> cardNames, int startIndex, int length, List<List<Card>> results)
    {
        if (current.Count == length)
        {
            results.Add(new List<Card>(current));
            return;
        }

        for (int i = startIndex; i < cardNames.Count; i++)
        {
            Card cardName = cardNames[i];
            int remaining = available[cardName];

            if (remaining > 0)
            {
                // Choose this card
                current.Add(cardName);

                // Reduce available copies
                var nextAvailable = new Dictionary<Card, int>(available);
                nextAvailable[cardName] = remaining - 1;

                // Keep i (not i+1) to allow multiple of same card
                GenerateCombinations(current, nextAvailable, cardNames, i, length, results);

                // Backtrack
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private IEnumerable<List<Card>> GetUniqueCombinationsStream(
    Dictionary<Card, int> limits,
    int length)
    {
        var cardKeys = new List<Card>(limits.Keys);
        var current = new List<Card>(length);

        foreach (var combo in GenerateCombinationsStream(current, limits, cardKeys, 0, length))
            yield return combo;
    }

    private IEnumerable<List<Card>> GenerateCombinationsStream(
        List<Card> current,
        Dictionary<Card, int> available,
        List<Card> cardKeys,
        int startIndex,
        int length)
    {
        if (current.Count == length)
        {
            // create a copy so downstream code can use it safely
            yield return new List<Card>(current);
            yield break;
        }

        for (int i = startIndex; i < cardKeys.Count; i++)
        {
            var card = cardKeys[i];
            int remaining;
            if (!available.TryGetValue(card, out remaining) || remaining == 0)
                continue;

            current.Add(card);
            available[card] = remaining - 1;

            foreach (var combo in GenerateCombinationsStream(current, available, cardKeys, i, length))
                yield return combo;

            available[card] = remaining;        // backtrack count
            current.RemoveAt(current.Count - 1);
        }
    }
    private void CreateDeckFromList(List<Card> cardlist)
    {
        for (int i = 0; i < cardlist.Count; i++)
        {
            Card newCard = ScriptableObject.Instantiate(cardlist[i]);
            cards.Add(newCard);
        }
    }

    public void CalculateOneStar()
    {
        StartCoroutine(CalculateOneStarRoutine());
    }
    public IEnumerator CalculateOneStarRoutine()
    {

        CalculatingText.SetActive(true);

        yield return null;
        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);

                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }



        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();
        Item currentItem = itemAdjuster.GetCurrentItem();
        double MaxValue = 0;
        int MaxIndex = 0;
        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }



            int zeroStarCutoff = 0;
            int zeroCounter = 0;

            int oneStarCutoff = currentItem.OneStarScore;
            int oneCounter = 0;

            int twoStarCutoff = currentItem.TwoStarScore;
            int twoCounter = 0;

            int threeStarCutoff = currentItem.ThreeStarScore;
            int threeCounter = 0;

            int fourStarCutoff = currentItem.FourStarScore;
            int fourCounter = 0;

            for (int k = 0; k < resultsList.Count; k++)
            {
                if (resultsList[k] < fourStarCutoff)
                {
                    if (resultsList[k] < threeStarCutoff)
                    {
                        if (resultsList[k] < twoStarCutoff)
                        {
                            if (resultsList[k] < oneStarCutoff)
                            {
                                if (resultsList[k] < zeroStarCutoff)
                                {

                                }
                                else
                                    zeroCounter++;
                            }
                            else
                                oneCounter++;
                        }
                        else
                            twoCounter++;
                    }
                    else
                        threeCounter++;
                }
                else
                    fourCounter++;
            }


            float zeroPercentage = Mathf.Round(zeroCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float onePercentage = Mathf.Round(oneCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float twoPercentage = Mathf.Round(twoCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float threePercentage = Mathf.Round(threeCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float fourPercentage = Mathf.Round(fourCounter / (float)OptimizationIterationCount * 1000) / 10f;


            double result = onePercentage + twoPercentage + threePercentage + fourPercentage;
            permutationResults.Add(result);
            if (result > MaxValue)
            {
                MaxValue = result;
                MaxIndex = i;
            }
            if (i % 20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);



        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }
    public void CalculateTwoStar()
    {
        StartCoroutine(CalculateTwoStarRoutine());
    }
    public IEnumerator CalculateTwoStarRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);

                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }



        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();
        Item currentItem = itemAdjuster.GetCurrentItem();
        double MaxValue = 0;
        int MaxIndex = 0;
        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }



            int zeroStarCutoff = 0;
            int zeroCounter = 0;

            int oneStarCutoff = currentItem.OneStarScore;
            int oneCounter = 0;

            int twoStarCutoff = currentItem.TwoStarScore;
            int twoCounter = 0;

            int threeStarCutoff = currentItem.ThreeStarScore;
            int threeCounter = 0;

            int fourStarCutoff = currentItem.FourStarScore;
            int fourCounter = 0;

            for (int k = 0; k < resultsList.Count; k++)
            {
                if (resultsList[k] < fourStarCutoff)
                {
                    if (resultsList[k] < threeStarCutoff)
                    {
                        if (resultsList[k] < twoStarCutoff)
                        {
                            if (resultsList[k] < oneStarCutoff)
                            {
                                if (resultsList[k] < zeroStarCutoff)
                                {

                                }
                                else
                                    zeroCounter++;
                            }
                            else
                                oneCounter++;
                        }
                        else
                            twoCounter++;
                    }
                    else
                        threeCounter++;
                }
                else
                    fourCounter++;
            }


            float zeroPercentage = Mathf.Round(zeroCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float onePercentage = Mathf.Round(oneCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float twoPercentage = Mathf.Round(twoCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float threePercentage = Mathf.Round(threeCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float fourPercentage = Mathf.Round(fourCounter / (float)OptimizationIterationCount * 1000) / 10f;


            double result = twoPercentage + threePercentage + fourPercentage;
            permutationResults.Add(result);
            if (result > MaxValue)
            {
                MaxValue = result;
                MaxIndex = i;
            }
            if (i % 20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);



        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }

    public void CalculateThreeStar()
    {
        StartCoroutine(CalculateThreeStarRoutine());
    }

    public IEnumerator CalculateThreeStarRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };

        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);

                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }



        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();
        Item currentItem = itemAdjuster.GetCurrentItem();
        double MaxValue = 0;
        int MaxIndex = 0;
        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }



            int zeroStarCutoff = 0;
            int zeroCounter = 0;

            int oneStarCutoff = currentItem.OneStarScore;
            int oneCounter = 0;

            int twoStarCutoff = currentItem.TwoStarScore;
            int twoCounter = 0;

            int threeStarCutoff = currentItem.ThreeStarScore;
            int threeCounter = 0;

            int fourStarCutoff = currentItem.FourStarScore;
            int fourCounter = 0;

            for (int k = 0; k < resultsList.Count; k++)
            {
                if (resultsList[k] < fourStarCutoff)
                {
                    if (resultsList[k] < threeStarCutoff)
                    {
                        if (resultsList[k] < twoStarCutoff)
                        {
                            if (resultsList[k] < oneStarCutoff)
                            {
                                if (resultsList[k] < zeroStarCutoff)
                                {

                                }
                                else
                                    zeroCounter++;
                            }
                            else
                                oneCounter++;
                        }
                        else
                            twoCounter++;
                    }
                    else
                        threeCounter++;
                }
                else
                    fourCounter++;
            }


            float zeroPercentage = Mathf.Round(zeroCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float onePercentage = Mathf.Round(oneCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float twoPercentage = Mathf.Round(twoCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float threePercentage = Mathf.Round(threeCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float fourPercentage = Mathf.Round(fourCounter / (float)OptimizationIterationCount * 1000) / 10f;


            double result = threePercentage + fourPercentage;
            permutationResults.Add(result);
            if (result > MaxValue)
            {
                MaxValue = result;
                MaxIndex = i;
            }
            if (i % 20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);



        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }

    public void CalculateFourStar()
    {
        StartCoroutine(CalculateFourStarRoutine());
    }
    private IEnumerator CalculateFourStarRoutine()
    {
        CalculatingText.SetActive(true);

        yield return null;

        //Create a list with all valid cards
        List<Card> allAvailableCards = new();

        // Define max allowed copies per card type
        Dictionary<Card, int> cardLimits = new Dictionary<Card, int>()
        {
        };


        switch (itemAdjuster.Category)
        {
            case 0: //Kitchen
                for (int i = 0; i < KitchenCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(0, i))
                        cardLimits.Add(KitchenCards[i], KitchenCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(0)]);

                }
                break;
            case 1: //Forge
                for (int i = 0; i < ForgeCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(1, i))
                        cardLimits.Add(ForgeCards[i], ForgeCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(1)]);
                }
                break;
            case 2: //Alchemy
                for (int i = 0; i < AlchemyCards.Count; i++)
                {
                    if (cardAjuster.IsCardActive(2, i))
                        cardLimits.Add(AlchemyCards[i], AlchemyCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(2)]);
                }
                break;
            case 3: //Events
                for (int i = 0; i < EventCards.Count; i++)
                {
                    cardLimits.Add(EventCards[i], EventCards[i].CardAmounts[cardAjuster.GetCurrentCategoryLevel(3)]);
                }
                break;
        }



        List<List<Card>> permutations = GetUniqueCombinations(cardLimits, itemAdjuster.GetCurrentItem().DeckSize);

        List<double> permutationResults = new List<double>();
        Item currentItem = itemAdjuster.GetCurrentItem();
        double MaxValue = 0;
        int MaxIndex = 0;
        for (int i = 0; i < permutations.Count; i++)
        {
            resultsList.Clear();
            cards.Clear();

            CreateDeckFromList(permutations[i]);


            for (int j = 0; j < OptimizationIterationCount; j++)
            {
                resultsList.Add(CalculateResults());
            }



            int zeroStarCutoff = 0;
            int zeroCounter = 0;

            int oneStarCutoff = currentItem.OneStarScore;
            int oneCounter = 0;

            int twoStarCutoff = currentItem.TwoStarScore;
            int twoCounter = 0;

            int threeStarCutoff = currentItem.ThreeStarScore;
            int threeCounter = 0;

            int fourStarCutoff = currentItem.FourStarScore;
            int fourCounter = 0;

            for (int k = 0; k < resultsList.Count; k++)
            {
                if (resultsList[k] < fourStarCutoff)
                {
                    if (resultsList[k] < threeStarCutoff)
                    {
                        if (resultsList[k] < twoStarCutoff)
                        {
                            if (resultsList[k] < oneStarCutoff)
                            {
                                if (resultsList[k] < zeroStarCutoff)
                                {

                                }
                                else
                                    zeroCounter++;
                            }
                            else
                                oneCounter++;
                        }
                        else
                            twoCounter++;
                    }
                    else
                        threeCounter++;
                }
                else
                    fourCounter++;
            }


            float zeroPercentage = Mathf.Round(zeroCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float onePercentage = Mathf.Round(oneCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float twoPercentage = Mathf.Round(twoCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float threePercentage = Mathf.Round(threeCounter / (float)OptimizationIterationCount * 1000) / 10f;
            float fourPercentage = Mathf.Round(fourCounter / (float)OptimizationIterationCount * 1000) / 10f;


            double result = fourPercentage;
            permutationResults.Add(result);
            if (result > MaxValue)
            {
                MaxValue = result;
                MaxIndex = i;
            }
            if (i % 20 == 0)
                yield return null;
        }

        if (permutationResults == null || permutationResults.Count == 0)
        {
            Debug.LogWarning("Not enough cards for this craft at the selected Level.");
            yield break; // or handle fallback logic
        }

        double maxValue = permutationResults.Max();
        int maxIndex = permutationResults.IndexOf(maxValue);



        for (int i = 0; i < ActivePanel.cardSelectors.Count; i++)
        {
            switch (itemAdjuster.Category)
            {
                case 0: //Kitchen
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, KitchenCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 1: //Forge
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, ForgeCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 2: //Alchemy
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, AlchemyCards.IndexOf(permutations[maxIndex][i]));
                    break;
                case 3: //Events
                    ActivePanel.cardSelectors[i].SetSpecificDropdown(itemAdjuster.Category, EventCards.IndexOf(permutations[maxIndex][i]));
                    break;
            }
        }

        CalculateDeck();
    }

    public void DisplayCalculating()
    {
        CalculatingText.SetActive(true);
        Canvas.ForceUpdateCanvases();
        Debug.Log("Calculating");
    }
}
