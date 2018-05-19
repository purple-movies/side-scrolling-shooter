using com.draconianmarshmallows.boilerplate;
using com.draconianmarshmallows.boilerplate.controllers;
using com.draconianmarshmallows.boilerplate.managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DraconianMarshmallows.Controllers
{
    class LevelController : BaseLevelController, IUpdateable
    {
        [SerializeField] private Transform levelParent;

        private Vector3 levelParentPositionTemp;

        protected override void Start()
        {
            base.Start();
            startLevel();
        }

        public override void startLevel()
        {
            base.startLevel();
            UpdateManager.Instance.AddUpdateable(this);
        }

        public void OnUpdate()
        {
            //Debug.Log("this is me : " + this);

            levelParentPositionTemp = levelParent.position;
            levelParentPositionTemp.x -= .005f;
            levelParent.position = levelParentPositionTemp;
        }

        private void OnDestroy()
        {
            UpdateManager.Instance.RemoveUpdateable(this);
        }
    }
}
