using System.Threading.Tasks;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.AssetManagement
{
    public interface IAsset : IService
    {
        Task<GameObject> Instantiate(string assetPath);
        Task<GameObject> Instantiate(string assetPath,Transform parent);
    }
}