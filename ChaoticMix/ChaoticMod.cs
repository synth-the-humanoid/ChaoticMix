using KHMI;
using KHMI.Types;
using System.Numerics;

namespace ChaoticMix
{
    public class ChaoticMod : KHMod
    {
        public ChaoticMod(ModInterface mi) : base(mi) { }

        

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
            IntPtr camTargetPtr = modInterface.memoryInterface.nameToAddress("CameraTargetPtr");
            modInterface.memoryInterface.writeLong(camTargetPtr, target.EntityPtr);
        }
    }
}
