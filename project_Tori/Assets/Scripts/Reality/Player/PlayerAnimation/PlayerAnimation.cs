using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Connector.Player;
using Virtuality.Player;

namespace Reality
{
    namespace Player
    {
        public class PlayerAnimation : MonoBehaviour
        {
            // PlayerÇÃAnimation ïœçXèàóù

            [Inject] private IPlayerInfoStateSentable _infoStateSentable;

            private Animator _animator;

            private readonly int _hoverFlg     = Animator.StringToHash("Hover");
            private readonly int _straightFlg  = Animator.StringToHash("Straight");
            private readonly int _rightFlg     = Animator.StringToHash("Right");
            private readonly int _leftFlg      = Animator.StringToHash("Left");
            private readonly int _flightFlg    = Animator.StringToHash("Flight");
            private readonly int _glideFlg     = Animator.StringToHash("Glide");

            // Start is called before the first frame update
            void Start()
            {
                _animator = GetComponent<Animator>();

               

                _infoStateSentable.GetPlayerMoveTypeObservable()
                    .Subscribe(x =>
                    {
                        AnimatorPramReset();

                        Debug.Log(x);

                        switch (x)
                        {
                            case PlayerMoveType.HOVER:
                                _animator.SetBool(_hoverFlg, true);
                                break;

                            case PlayerMoveType.FLIGHT_STRAIGHT:
                                _animator.SetBool(_straightFlg, true);
                                _animator.SetBool(_flightFlg, true);
                                break;

                            case PlayerMoveType.GLIDE_STRAIGHT:
                                _animator.SetBool(_straightFlg, true);
                                _animator.SetBool(_glideFlg, true);
                                break;

                            case PlayerMoveType.FLIGHT_RIGHT:
                                _animator.SetBool(_rightFlg, true);
                                _animator.SetBool(_flightFlg, true);
                                break;

                            case PlayerMoveType.GLIDE_RIGHT:
                                _animator.SetBool(_rightFlg, true);
                                _animator.SetBool(_glideFlg, true);
                                break;

                            case PlayerMoveType.FLIGHT_LEFT:
                                _animator.SetBool(_leftFlg, true);
                                _animator.SetBool(_flightFlg, true);
                                break;

                            case PlayerMoveType.GLIDE_LEFT:
                                _animator.SetBool(_leftFlg, true);
                                _animator.SetBool(_glideFlg, true);
                                break;

                            default:
                                throw new System.NotImplementedException("ó·äO");
                        }
                    });
            }


            // Animatorèâä˙âªÇÇ∑ÇÈ
            private void AnimatorPramReset()
            {
                _animator.SetBool(_hoverFlg, false);
                _animator.SetBool(_flightFlg, false);
                _animator.SetBool(_glideFlg, false);
                _animator.SetBool(_straightFlg, false);
                _animator.SetBool(_rightFlg, false);
                _animator.SetBool(_leftFlg, false);

            }

            // Update is called once per frame
            void Update()
            {
            }

            private void AnimationChange()
            {

            }
        }

    }
}
