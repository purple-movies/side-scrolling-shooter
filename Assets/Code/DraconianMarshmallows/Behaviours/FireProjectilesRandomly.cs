using com.draconianmarshmallows.boilerplate;
using com.draconianmarshmallows.boilerplate.managers;
using UnityEngine;

namespace DraconianMarshmallows.Behaviours
{
    class FireProjectilesRandomly : DraconianBehaviour, IUpdateable
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectilesParent;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int randomValue = 3;

        protected override void Start()
        {
            base.Start();
            UpdateManager.Instance.AddUpdateable(this);
        }

        public void OnUpdate()
        {
            int rando = Random.Range(0, randomValue);
            Debug.Log("rando : " + rando);

            if (rando == 0)
            {
                // TODO:: implement projectile pooling. 
                Debug.Log("projectile pooling isn't implemented.");

                GameObject projectile = Instantiate(projectilePrefab, 
                    spawnPoint.position, spawnPoint.rotation);

                //projectile.transform.parent = projectilesParent;
                projectile.GetComponent<Projectile>().launch(-80f);
            }
        }
    }
}
