using com.draconianmarshmallows.boilerplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DraconianMarshmallows.Behaviours
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    class Spawner : DraconianBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnParent;
        [SerializeField] private Collider2D triggerCollider;
        [SerializeField] private bool spawnOnce = true;

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.Equals(triggerCollider))
            {
                // TODO:: implement pooling.
                Debug.LogWarning("Enemy pooling needs implementing !");
                GameObject spawned = Instantiate(prefab, transform.localPosition, transform.localRotation);
                spawned.transform.parent = spawnParent;

                if (spawnOnce) Destroy(gameObject);
            }
        }
    }
}
