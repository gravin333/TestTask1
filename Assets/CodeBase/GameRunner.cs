using System;
using UnityEngine;

namespace CodeBase
{
    public class GameRunner : MonoBehaviour
    {
        public GameObject GameBootstrapPref; 
        private void Awake()
        {
            if (FindObjectOfType<GameBootstrap>()==null)
            {
                Instantiate(GameBootstrapPref);
            }
        }
    }
}
