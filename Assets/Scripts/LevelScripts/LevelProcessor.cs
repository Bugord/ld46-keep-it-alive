using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LevelScripts.Commands;
using LevelScripts.Commands;
using UnityEngine;

namespace Assets.Scripts.LevelScripts
{
    public class LevelProcessor : MonoBehaviour
    {
        private GameManager _gameManager;
        public LevelScript LevelScript;

        public FirstLevelScript FirstLevelScript;
        public TestLevel FirstLevelRestartScript;

        private Coroutine cor;
        
        void Start()
        {
            _gameManager = GameManager.Instance;
        }

        public void LoadFirst()
        {
            LevelScript = FirstLevelScript;
        } 
        
        public void LoadSecond()
        {
            LevelScript = FirstLevelRestartScript;
        }

        public void Launch()
        {
            if (cor != null)
            {
                StopCoroutine(cor);
            }

            try
            {
                cor = StartCoroutine(LaunchCoroutine());
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw;
            } 
        }

        IEnumerator LaunchCoroutine()
        {
            
            Debug.Log(LevelScript);
            Debug.Log(_gameManager);
            
            foreach (var command in LevelScript.Commands)
            {
                switch (command)
                {
                    case ShootCommand shootCommand:
                        Debug.Log("shootCommand");
                        _gameManager.Enemies[shootCommand.ShooterIndex].NewAttack(shootCommand.WeaponType);
                        break;
                    case WaitCommand waitCommand:
                        Debug.Log("waitCommand");
                        yield return new WaitForSeconds(waitCommand.TimeToWait / 1000f);
                        break;
                    case MoveToCommand moveToCommand:
                        Debug.Log("moveToCommand");
                        if (moveToCommand.IsPresident)
                        {
                            _gameManager.President.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition);
                        }
                        else
                        {
                            _gameManager.Guards[moveToCommand.Index].transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition, moveToCommand.Speed);
                        }
                        break;
                    case MoveCameraCommand moveCameraCommand:
                        Debug.Log("moveCameraCommand");
                        Camera.main.GetComponent<CameraScript>().Move(moveCameraCommand.TargetPosition,
                            moveCameraCommand.Move ? moveCameraCommand.Speed : 0f);
                        break;
                    case SetAimingCommand setAimingCommand:
                        Debug.Log("setAimingCommand");
                        //_gameManager.Enemies[setAimingCommand.Index].SetAiming(setAimingCommand.IsActive);
                        break;
                    case MoveByWaypointsCommand moveByWaypointsCommand:
                        Debug.Log("moveByWaypointsCommand");
                        if (moveByWaypointsCommand.IsPresident)
                        {
                            _gameManager.President.transform.GetChild(1).GetComponent<WayPointsScript>().MoveTo(moveByWaypointsCommand.Points);
                        }
                        else
                        {
                            _gameManager.Guards[moveByWaypointsCommand.Index].transform.GetChild(1).GetComponent<WayPointsScript>().MoveTo(moveByWaypointsCommand.Points);
                        }
                        break;
                    case StartHeliScript startHeliScript:
                        Debug.Log("startHeliScript");
                        _gameManager.HeliScript.Launch();
                        break;
                    case SpawnPresident spawnPresident:
                        Debug.Log("spawnPresident");
                        _gameManager.President.SetActive(true);
                        break;
                    case SpeakCommand speakCommand:
                        Debug.Log("speakCommand");
                        List<string> messages = new List<string>
                        {
                            "Pizza with pineaple is FINE!",
                            "Dota is better then LoL!"
                        };
                        _gameManager.President.GetComponentInChildren<SpeachController>().Speak(messages[new System.Random().Next(0, messages.Count)]);
                        break;

                }

            }
           
            
        }
        
    }
}
