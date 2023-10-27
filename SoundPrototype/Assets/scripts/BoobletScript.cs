using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyPhysicsSurfaces
{
    public class BoobletScript : MonoBehaviour

    {
        [SerializeField] private float speed = 30f;
        public static Action<int> PlayerKilled = delegate { };
        public int playerIndex;
        IEnumerator DestroyBulletAfterTime()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }

        void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.gameObject.TryGetComponent<DeeathScript>(out DeeathScript deeathScriptComponent))
            {
               // PlayerKilled(PlayerIndex);
                deeathScriptComponent.TakeDamage(1);
            }

            Destroy(gameObject);
        }
        private void OnEnable()
        {

            StartCoroutine(DestroyBulletAfterTime());

        }

    }
}
