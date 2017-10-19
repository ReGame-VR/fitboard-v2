using UnityEngine;
using System.Collections;
using ReGameVR.Games.Roll;

namespace ReGameVR {
    namespace Games {
        namespace Roll {
            public class EnemyMover : MonoBehaviour {

                public float moveSpeed = 10f;
                private float inputX, inputZ;
                public GameObject player;

                private Rigidbody rb;

                void Start() {
                    rb = GetComponent<Rigidbody>();
                }

                void Update() {
                    inputX = Input.GetAxis("Horizontal");
                    inputZ = Input.GetAxis("Vertical");

                    float moveX = inputX * moveSpeed * Time.deltaTime;
                    float moveZ = inputZ * moveSpeed * Time.deltaTime;

                    rb.AddForce(moveX, 0f, moveZ);
                }
            }
        }
    }
}