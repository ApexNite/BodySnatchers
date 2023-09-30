using BepInEx;
using UnityEngine;

namespace BodySnatchers {
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin {
        private const string pluginGuid = "apexlite.worldbox.bodysnatchers";
        private const string pluginName = "BodySnatchers";
        private const string pluginVersion = "1.0.0";
        private Squad squad;

        void Update() {
            Squad.UpdateAll();
            ControlledActor.Update();

            if (Input.GetKeyDown(KeyCode.P)) {
                Actor actor = ControlledActor.GetActor() == null ? MapBox.instance.getActorNearCursor() : null;
                ControlledActor.SetActor(actor);
                squad = new Squad(actor, 8);
            }

            if (Input.GetKeyDown(KeyCode.Y)) {
                squad.HireActor(MapBox.instance.getActorNearCursor());
            }

            if (Input.GetKeyDown(KeyCode.H)) {
                squad.FireActor(MapBox.instance.getActorNearCursor());
            }

            if (Input.GetKeyDown(KeyCode.G)) {
                squad.lineX++;
            }

            if (Input.GetKeyDown(KeyCode.J)) {
                squad.lineX--;
            }

            if (Input.GetKeyDown(KeyCode.L)) {
                squad.lineY++;
            }

            if (Input.GetKeyDown(KeyCode.B)) {
                squad.lineY--;
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                squad.CycleFormation();
            }

            if (Input.GetKeyDown(KeyCode.V)) {
                squad.CycleAction();
            }
        }
    }
}
