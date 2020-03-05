using System.Collections;
using System.Linq;
using UnityEngine;
using Object = System.Object;

namespace Player
{
    public class PlayerFollower : MonoBehaviour
    {
        // ========================================================================
        // FIELDS
        // ========================================================================

        public GameObject MasterObject;
        public int Offset;

        private PlayerTrail _masterTrail;
        //private Animator _playerAnimator;
        private bool _smoothBool;

        // ========================================================================
        // METHODS
        // ========================================================================

        void Start()
        {
            //_playerAnimator = gameObject.GetComponent<Animator>();
            _masterTrail = MasterObject.GetComponent<PlayerTrail>();
            _smoothBool = true;
        }

        void Update()
        {
            if (_masterTrail.LeaderTrail.Count < Offset)
            {
                if (_masterTrail.LeaderTrail.Count < Offset / 2)
                {
                    /*_playerAnimator.SetFloat("Magnitude", 0);*/
                    return;
                }

                _smoothBool = !_smoothBool;
                if (!_smoothBool) return;

                Vector3 direction = _masterTrail.LeaderTrail.Peek() - transform.position;
                transform.position = _masterTrail.LeaderTrail.Peek();

                /*_playerAnimator.SetFloat("Magnitude", 1);
                _playerAnimator.SetFloat("Horizontal", direction.x);
                _playerAnimator.SetFloat("Vertical", direction.z);*/
                _masterTrail.LeaderTrail.Dequeue();
            }
            else
            {
                Vector3 direction = _masterTrail.LeaderTrail.Peek() - transform.position;
                transform.position = _masterTrail.LeaderTrail.Peek();

                /*_playerAnimator.SetFloat("Magnitude", 1);
                _playerAnimator.SetFloat("Horizontal", direction.x);
                _playerAnimator.SetFloat("Vertical", direction.z);*/
                _masterTrail.LeaderTrail.Dequeue();
            }
        }
    }
}