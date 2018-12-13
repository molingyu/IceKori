using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.IceKori.Demo
{

    public class TypewriterEffect : MonoBehaviour
    {
        [Range(0, 0.2f)]
        public float CharsPerSecond = 0.1f;
        public string Message;

        public bool IsActive;
        private float _timer;
        private Text _myText;
        private int _currentPos;

        // Use this for initialization
        void Start()
        {
            _myText = GetComponent<Text>();
        }

        public void Refresh()
        {
            _timer = 0;
            IsActive = true;
            _myText.text = "";
        }


        void Update()
        {
            OnStartWriter();
        }

        public void StartEffect()
        {
            Refresh();
        }

        void OnStartWriter()
        {

            if (IsActive && Message.Length != 0)
            {
                _timer += Time.deltaTime;
                if (_timer >= CharsPerSecond)
                {
                    _timer = 0;
                    _myText.text += Message[_currentPos];
                    _currentPos += 1;
                    if (_currentPos == Message.Length)
                    {
                        OnFinish();
                    }
                }

            }
        }

        void OnFinish()
        {
            IsActive = false;
            _timer = 0;
            _currentPos = 0;
            _myText.text = Message;
        }

    }
}
