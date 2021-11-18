using System;
using CodeBase.AssetManagement;
using CodeBase.Services;

namespace CodeBase.SceneManagement
{
    public interface ISceneLoader : IService
    {
        void LoadScene(string assetPath,Action onLoaded = null);
    }
}