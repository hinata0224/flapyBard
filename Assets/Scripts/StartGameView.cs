using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGame
{
    public class StartGameView : MonoBehaviour
    {
        [SerializeField]
        private GameObject startView;

        private bool start = false;
        public void StartGame()
        {
            startView.SetActive(false);
            start = true;
        }

        public bool GetStart()
        {
            return start;
        }
    }
}