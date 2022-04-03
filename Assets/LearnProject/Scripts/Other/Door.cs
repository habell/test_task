using UnityEngine;

namespace Learning.Scripts.Other
{
    [RequireComponent(typeof(AudioSource))]
    public class Door : MonoBehaviour
    {
        private float _defYpos;
        [SerializeField]
        private bool _doorStatus;
        public Button button1;
        public Button button2;
        private AudioSource _audioSource;
        private AudioClip _clip;

    
        void Start()
        {
            _defYpos = transform.position.y;
            _audioSource = GetComponent<AudioSource>();
        }
        public void OpenDoor()
        {
            if (button1.ButtonStatus && button2.ButtonStatus) _doorStatus = !_doorStatus;
            _audioSource.clip = _clip;
            _audioSource.Play();
        }

        private void FixedUpdate()
        {
            if(!_doorStatus && _defYpos < 0)
            {
                _defYpos += Time.deltaTime;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }
            if (_doorStatus && _defYpos > -1)
            {
                _defYpos -= Time.deltaTime;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }
        }
    }
}
