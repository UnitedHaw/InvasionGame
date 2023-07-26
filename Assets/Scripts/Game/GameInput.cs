using Assets.Scripts.Prototypes.GridSystem;
using Code.Hexasphere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    internal class GameInput
    {    
        private Touch _touch;

        public GameInput()
        {
            
        }

        public void TouchInput(Func<Vector3, Territory> beganEvent = null, Action movedEvent = null, Action stationaryEvent = null,
            Func<Vector3, Territory> endedEvent = null, Action canceledEvent = null)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                switch (_touch.phase)
                {
                    case TouchPhase.Began:
                        beganEvent?.Invoke(_touch.position);
                        break;
                    case TouchPhase.Moved:
                        movedEvent?.Invoke();
                        break;
                    case TouchPhase.Stationary:
                        stationaryEvent?.Invoke();
                        break;
                    case TouchPhase.Ended:
                        endedEvent?.Invoke(_touch.position);
                        break;
                    case TouchPhase.Canceled:
                        canceledEvent?.Invoke();
                        break;
                }
            }
        }
    }
}
