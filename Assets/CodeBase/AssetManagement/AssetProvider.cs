using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.AssetManagement
{
    public class AssetProvider : IAsset
    {
        public AssetProvider()
        {
            Initialization();
        }

        private void Initialization()
        {
            Addressables.InitializeAsync();
        }

        public Task<GameObject> Instantiate(string assetPath)
        {
            return Addressables.InstantiateAsync(assetPath).Task;
        }

        public Task<GameObject> Instantiate(string assetPath, Transform parent)
        {
            return Addressables.InstantiateAsync(assetPath, parent).Task;
        }
    }
}