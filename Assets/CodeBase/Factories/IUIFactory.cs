using System.Threading.Tasks;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        Task<GameObject> CreateMenu();
        Task<GameObject> CreateBeckMenuButton();
    }
}