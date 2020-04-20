using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LevelScripts.Commands;
using LevelScripts.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.LevelScripts
{
    public class LevelProcessor : MonoBehaviour
    {
        private GameManager _gameManager;
        public LevelScript LevelScript;

        public LevelScript FirstLevelScript;
        public LevelScript FirstLevelRestartScript;

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
            foreach (var command in LevelScript.Commands)
            {
                switch (command)
                {
                    case ShootCommand shootCommand:
                        _gameManager.Enemies[shootCommand.ShooterIndex].NewAttack(shootCommand.WeaponType);
                        break;
                    case WaitCommand waitCommand:
                        yield return new WaitForSeconds(waitCommand.TimeToWait / 1000f);
                        break;
                    case MoveToCommand moveToCommand:
                        if (moveToCommand.IsPresident)
                        {                            
                            if (moveToCommand.Speed < 1)
                            {
                                _gameManager.President.GetComponentsInChildren<SpriteRenderer>().ToList().ForEach(s => s.sortingOrder = 0);
                                _gameManager.President.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition);
                            }
                            else 
                            {
                                if(_gameManager.President.GetComponentInChildren<ThrowScript>() != null)
                                _gameManager.President.GetComponentInChildren<ThrowScript>().enabled = true;
                                _gameManager.President.GetComponentsInChildren<SpriteRenderer>().ToList().ForEach(s => s.sortingOrder = -10);
                                _gameManager.President.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition, moveToCommand.Speed);
                            }                            
                        }
                        else
                        {
                            _gameManager.Guards[moveToCommand.Index].transform.GetChild(1).GetComponent<MoveScript>().MoveTo(moveToCommand.TargetPosition, moveToCommand.Speed);
                        }
                        break;
                    case MoveCameraCommand moveCameraCommand:
                        Camera.main.GetComponent<CameraScript>().Move(moveCameraCommand.TargetPosition,
                            moveCameraCommand.Move ? moveCameraCommand.Speed : 0f);
                        break;
                    case SetAimingCommand setAimingCommand:
                        //_gameManager.Enemies[setAimingCommand.Index].SetAiming(setAimingCommand.IsActive);
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
                    case StartHeliScript startHeliScript:
                        _gameManager.HeliScript.Launch();
                        break;
                    case StartCarScript startCarScript:
                        Debug.Log("startCarScript");
                        _gameManager.CarScript.Launch();
                        break;
                    case SpawnPresident spawnPresident:                        
                        _gameManager.President.SetActive(true);
                        break;
                    case SpeakCommand speakCommand:
                        List<string> messages = new List<string>
                        {
                            "Pizza with pineaple is FINE!",
                            "Dota is better then LoL!",
                            "Your waifu is trash!",
                            "Point the laser at me!",
                            "Sponsor of my speach is Raid Shadow Legends!"
                        };
                        _gameManager.President.GetComponentInChildren<SpeachController>().Speak(messages[new System.Random().Next(0, messages.Count)]);
                        break;

                    case LastLevelCommand lastLevelCommand:
                        SceneManager.LoadScene("Level2");
                        break;
                        

                }

            }
           
            
        }
        
    }
}
