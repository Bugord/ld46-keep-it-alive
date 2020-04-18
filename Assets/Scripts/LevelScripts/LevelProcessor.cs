using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LevelScripts.Commands;
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
                    case MoveToCommand moveToCommand:
                        if (moveToCommand.IsPresident)
                        {
                            _gameManager.President.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition);
                        }
                        else
                        {
                            _gameManager.Guards[moveToCommand.Index].transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition);
                        }
                        break;
                    case MoveCameraCommand moveCameraCommand:
                        Camera.main.GetComponent<CameraScript>().Move(moveCameraCommand.TargetPosition,
                            moveCameraCommand.Move ? moveCameraCommand.Speed : 0f);
                        break;
                    case SetAimingCommand setAimingCommand:
                        _gameManager.Enemies[setAimingCommand.Index].SetAiming(setAimingCommand.IsActive);
                        break;
                    case MoveByWaypointsCommand moveByWaypointsCommand:
                        if (moveByWaypointsCommand.IsPresident)
                        {
                            _gameManager.President.transform.GetChild(1).GetComponent<WayPointsScript>().MoveTo(moveByWaypointsCommand.Points);
                        }
                        else
                        {
                            _gameManager.Guards[moveByWaypointsCommand.Index].transform.GetChild(1).GetComponent<WayPointsScript>().MoveTo(moveByWaypointsCommand.Points);
                        }
                        break;
                    

                }

            }
        }
        
    }
}
