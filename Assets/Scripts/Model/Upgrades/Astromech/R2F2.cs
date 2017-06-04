﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upgrade;

namespace UpgradesList
{

    public class R2F2 : GenericUpgrade
    {

        public R2F2() : base()
        {
            Type = UpgradeSlot.Astromech;
            Name = ShortName = "R2-F2";
            ImageUrl = "https://vignette4.wikia.nocookie.net/xwing-miniatures/images/8/86/R2-F2.jpg";
            isUnique = true;
        }

        public override void AttachToShip(Ship.GenericShip host)
        {
            base.AttachToShip(host);

            host.AfterAvailableActionListIsBuilt += R2F2AddAction;
        }

        private void R2F2AddAction(Ship.GenericShip host)
        {
            ActionsList.GenericAction action = new ActionsList.R2F2Action();
            action.ImageUrl = ImageUrl;
            host.AddAvailableAction(action);
        }

    }

}

namespace ActionsList
{ 

    public class R2F2Action : ActionsList.GenericAction
    {
        private Ship.GenericShip host;

        public R2F2Action()
        {
            Name = EffectName = "R2-F2: Increase Agility";
        }

        public override void ActionTake()
        {
            host = Selection.ThisShip;
            host.ChangeAgility(+1);
            Phases.OnEndPhaseStart += R2F2DecreaseAgility;
        }

        private void R2F2DecreaseAgility()
        {
            host.ChangeAgility(-1);
        }

    }

}