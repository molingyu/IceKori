using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.IceKori.Demo
{
    public class MessageWindow : MonoBehaviour
    {
        private List<string> _messsages = new List<string>();
        private string _message;
        public Action EndAction;
        public Image MessageBox;
        public Image CharacterLeft;
        public Image CharacterRight;
        public Text Name;
        public Text Message;
        public TypewriterEffect Typewriter;

        void Start()
        {

        }

        void Update()
        {
            if (_messsages.Count != 0)
            {
                if (_message == null)
                {
                    _message = _messsages[0];
                    _messsages.RemoveAt(0);
                    Message.text = "";
                    Typewriter.Message = _message;
                    Typewriter.StartEffect();
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _message = null;
                if (_messsages.Count == 0)
                {
                    EndAction();
                }
            }

        }

        public void Show(List<string> messsages, string characterName, bool bg, Sprite character1, Sprite character2)
        {
            
            MessageBox.gameObject.SetActive(bg);
            Name.text = $"【{characterName}】";

            if (character1 == null)
            {
                CharacterLeft.gameObject.SetActive(false);
            }
            else
            {
                CharacterLeft.gameObject.SetActive(true);
                CharacterLeft.sprite = character1;
            }

            if (character2 == null)
            {
                CharacterRight.gameObject.SetActive(false);
            }
            else
            {
                CharacterRight.gameObject.SetActive(true);
                CharacterRight.sprite = character2;
            }

            _messsages = messsages;
        }

        public void HideWindow()
        {
            gameObject.SetActive(false);
        }
    }

}
