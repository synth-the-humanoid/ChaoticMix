using KHMI;
using KHMI.Types;
using System.Numerics;

namespace ChaoticMix
{
    public class ChaoticMod : KHMod
    {
        public ChaoticMod(ModInterface mi) : base(mi) { }

        public override void warpTableUpdate(WarpTable wt)
        {
            Warp[] warps = wt.Warps;
            Random r = new Random();
            r.Shuffle(warps);
            for(int i = 0; i < warps.Length; i++)
            {
                Warp currentEdit = wt.Warps[i];
                currentEdit.RoomID = warps[i].RoomID;
                currentEdit.PlayerPosition = warps[i].PlayerPosition;
                currentEdit.Party1Position = warps[i].Party1Position;
                currentEdit.Party2Position = warps[i].Party2Position;
                currentEdit.PlayerRotation = warps[i].PlayerRotation;
                currentEdit.Party1Rotation = warps[i].Party1Rotation;
                currentEdit.Party2Rotation = warps[i].Party2Rotation;
            }
        }

        public override void playerLoaded(Entity newPlayer)
        {
            EntityTable et = EntityTable.Current(modInterface.dataInterface);
            Entity[] entities = et.Entities;
            Random r = new Random();
            r.Shuffle(entities);
            for(int i = 0; i < entities.Length; i++)
            {
                Entity currentEdit = et.Entities[i];
                currentEdit.Position = entities[i].Position;
                currentEdit.Rotation = entities[i].Rotation;
            }
        }

        public override void onDamage(Entity target)
        {
            if (target.IsPartyMember)
            {
                IntPtr camTargetPtr = modInterface.memoryInterface.nameToAddress("CameraTargetPtr");
                modInterface.memoryInterface.writeLong(camTargetPtr, target.EntityPtr);
            }
        }
    }
}
