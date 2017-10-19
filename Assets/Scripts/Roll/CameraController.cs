using UnityEngine;
using System.Collections;
using ReGameVR.Games.Roll;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class CameraController : MonoBehaviour {

                public GameObject player;
                private Vector3 offset;

                void Start() {
                    offset = transform.position - player.transform.position;
                }

                void LateUpdate() {
                    transform.position = player.transform.position + offset;
                }
            }
        }
    }
}