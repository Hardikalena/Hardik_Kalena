using System;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

// Manages in-app purchases and handles purchase flow
public class InAppPurchaseManager : MonoBehaviour, IDetailedStoreListener
{
    public static InAppPurchaseManager Instance;// Singleton instance for easy access

    [Header("IDs")]
    public string goldProductID;                // Product ID for purchasing gold
    public string diamondProductID;             // Product ID for purchasing diamonds

    [Header("UI")]
    public TMP_Text goldText;                   // UI text for displaying gold amount
    public TMP_Text diamondText;                // UI text for diamond product
    public TMP_Text noAdsUI;                    // UI text for no-ads status
        
    [Header("BackendConfiguration")]
    public int goldAmount;                      // Amount of gold owned by the user
    public string diamond;                      // Diamond purchase details
    public GameObject diamondProduct;           // Reference to diamond-related product object
    public bool noAds;                          // Indicates whether ads are disabled

    [Header("Store")]
    public GameObject storeUI;                  // Store UI GameObject
    public float countDown;                     // Countdown timer for no-ads expiry
    public TMP_Text countDownText;              // UI text for displaying countdown
    public int noAdsExpiaryTime;                // Total duration for no-ads validity

    private IStoreController storeController;   // Handles interactions with the app store

    private void Awake()
    {
        Instance = this;                        // Assign singleton instance
        diamondProduct.SetActive(false);        // Initially disable diamond product visibility
    }

    // Called when the IAP system initializes successfully
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Initialization has been Successful");
        goldText.text = "Gold : " + goldAmount;         // Update gold text
        storeController = controller;                   // Assign store controller
    }

    // Handles initialization failure
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        OnInitializeFailed(error, "InitializationFailed");
    }

    // Processes a successful purchase
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;   // Get purchased product details

        if (product.definition.id == goldProductID)
        {
            AddGold();                                  // Add gold if gold product is purchased
        }
        else if (product.definition.id == diamondProductID)
        {
            AddDiamond();                               // Unlock diamond product if diamond is purchased
        }

        return PurchaseProcessingResult.Complete;       // Mark purchase as complete
    }

    // Adds gold to the user's account
    private void AddGold()
    {
        Debug.Log("Gold has been Added");
        goldAmount += 50;                               // Increment gold amount
        goldText.text = "Gold : " + goldAmount;         // Update gold UI
    }

    // Unlocks the diamond product for the user
    private void AddDiamond()
    {
        Debug.Log("Product has been Purchased");
        diamondText.text = diamond;                     // Update diamond text
        diamondProduct.SetActive(true);                 // Show diamond product
    }

    // Initializes the IAP system and sets up products
    public void InitializePurchase()
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(goldProductID, ProductType.Consumable);      // Add gold as consumable product
        builder.AddProduct(diamondProductID, ProductType.Consumable);   // Add diamond as consumable product
        UnityPurchasing.Initialize(this, builder);                      // Initialize IAP system
    }

    // Initiates the purchase process for gold
    public void GoldPurchase()
    {
        storeController.InitiatePurchase(goldProductID);
    }

    // Initiates the purchase process for diamonds
    public void DiamondPurchase()
    {
        storeController.InitiatePurchase(diamondProductID);
    }

    private void Start()
    {
        storeUI.SetActive(false);   // Hide store UI at start
        noAds = false;              // Set no-ads to false
        noAdsUI.text = "False";     // Update no-ads UI text
        InitializePurchase();       // Start IAP initialization
    }

    // Toggles store UI visibility
    public void StoreUIActivate()
    {
        if (!noAds)
        {
            InterstitialAd.Instance.LoadAD();           // Load interstitial ad if ads are enabled
        }

        storeUI.SetActive(!storeUI.activeInHierarchy); // Toggle store UI visibility
    }

    // Disables ads and updates UI
    public void NoAds()
    {
        noAdsUI.text = "True"; // Update no-ads UI text
        noAds = true;          // Set no-ads to true
    }

    private void Update()
    {
        if (noAds)
        {
            countDown += Time.deltaTime;                                        // Update countdown timer
            countDownText.text = "Valid Till : " + countDown.ToString("F2");    // Update countdown UI

            if (countDown >= noAdsExpiaryTime)
            {
                // Reset no-ads status after expiry
                countDown = 0;
                noAds = false;
                noAdsUI.text = "False";
                countDownText.text = "Expired";
            }
        }
    }

    // Handles initialization failure with a custom message
    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("InitializationFailed");
    }

    // Handles purchase failure
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log("PurchaseFailed");
    }

    // Handles purchase failure with a reason
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        OnPurchaseFailed(product, PurchaseFailureReason.UserCancelled);
    }
}
