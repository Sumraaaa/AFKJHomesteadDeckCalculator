using UnityEngine;

public class MasterLoader : MonoBehaviour
{
    public static MasterLoader Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public GameObject Panel7;
    public GameObject Panel8;
    public GameObject Panel9;

    public void LoadPanelWithCorrectSize(int size)
    {
        SaveCurrentItem();
        
        switch (size)
        {
            case 3:
                UnloadAllPanels();

                Panel3.gameObject.SetActive(true);
                
                break;
            case 4:
                UnloadAllPanels();

                Panel4.gameObject.SetActive(true);
                
                break;
            case 5:
                UnloadAllPanels();

                Panel5.gameObject.SetActive(true);
                
                break;
            case 6:
                UnloadAllPanels();

                Panel6.gameObject.SetActive(true);
                
                break;
            case 7:
                UnloadAllPanels();

                Panel7.gameObject.SetActive(true);
                
                break;
            case 8:
                UnloadAllPanels();

                Panel8.gameObject.SetActive(true);

                break;
            case 9:
                UnloadAllPanels();
                Panel9.gameObject.SetActive(true);

                break;
            default:
                break;
        }
        HomesteadManager.Instance.SetActivePanel();
    }

   
    private void UnloadAllPanels()
    {
        Panel3.gameObject.SetActive(false);
        Panel4.gameObject.SetActive(false);
        Panel5.gameObject.SetActive(false);
        Panel6.gameObject.SetActive(false);
        Panel7.gameObject.SetActive(false);
        Panel8.gameObject.SetActive(false);
        Panel9.gameObject.SetActive(false);
    }

    private int categoryData;
    private int itemNumber;
    private void SaveCurrentItem()
    {
        categoryData = HomesteadManager.Instance.itemAdjuster.Category;
        itemNumber = HomesteadManager.Instance.itemAdjuster.GetCurrentItemIndex();
    }

    public void UpdateAllCardSelectors()
    {
        HomesteadManager.Instance.UpdateCardSelectors();
    }
}
