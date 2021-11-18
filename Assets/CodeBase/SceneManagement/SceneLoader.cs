using System;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace CodeBase.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public async void LoadScene(string assetPath,Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name.Equals(assetPath))
            {
                onLoaded?.Invoke();
                return;
            }

            await Addressables.LoadSceneAsync(assetPath).Task;

            onLoaded?.Invoke();
        }
    }
}