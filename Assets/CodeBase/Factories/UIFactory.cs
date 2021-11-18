using System.Threading.Tasks;
using CodeBase.AssetManagement;
using UnityEngine;

namespace CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private IAsset _asset;
        private GameObject _rootCanvas;

        public UIFactory(IAsset asset)
        {
            _asset = asset;
        }

        public async Task<GameObject> CreateMenu()
        {
            if (_rootCanvas == null)
            {
                await CreateRootCanvas();
            }

            return await _asset.Instantiate(UIAssetPath.MenuWindow, _rootCanvas.transform);
        }

        public async Task<GameObject> CreateBeckMenuButton()
        {
            if (_rootCanvas == null)
            {
                await CreateRootCanvas();
            }

            return await _asset.Instantiate(UIAssetPath.BeckMenuButton, _rootCanvas.transform);
        }

        private async Task CreateRootCanvas()
        {
            _rootCanvas = await _asset.Instantiate(UIAssetPath.RootCanvas);
        }
    }
}