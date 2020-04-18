using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelScripts
{
    public class LevelProcessor : MonoBehaviour
    {
        private GameManager _gameManager;
        public LevelScript LevelScript;

        void Awake()
        {
            _gameManager = GameManager.Instance;
        }

        public void Launch()
        {
            StartCoroutine(LaunchCoroutine());
        }

        IEnumerator LaunchCoroutine()
        {
            foreach (var command in LevelScript.Commands)
            {
                switch (command)
                {
                    case ShootCommand shootCommand:
                        _gameManager.Enemies[shootCommand.ShooterIndex].Shoot();
                        break;
                    case WaitCommand waitCommand:
                        yield return new WaitForSeconds(waitCommand.TimeToWait / 1000f);
                        break;
                }
                
            }
        }
        
    }
}
