using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class Addressables : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            assetReferenceGameObject.InstantiateAsync();
        }
    }
}
