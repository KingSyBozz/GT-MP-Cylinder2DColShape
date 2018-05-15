using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Server.Managers;

namespace SyBozz.GrandTheftMultiplayer.Server.ColShapeExample.Managers
{
    public class Cylinder2DColShape : ColShape
    {
        private float _range;
        private float _rangeSquared;
        private NetHandle _attachedNetHandle;

        public Vector3 Center;

        internal Cylinder2DColShape(Vector3 center, float range)
        {
            Center = center;
            Range = range;
        }

        public float Range
        {
            get => _range;
            set
            {
                _rangeSquared = value * value;
                _range = value;
            }
        }

        public override bool Check(Vector3 pos)
        {
            var center = Center;
            if (!_attachedNetHandle.IsNull)
                center = API.shared.getEntityPosition(_attachedNetHandle);

            return center.DistanceToSquared2D(pos) >= _rangeSquared;
        }

        public void AttachToEntity(NetHandle entity)
        {
            _attachedNetHandle = entity;
        }

        private void Detach()
        {
            _attachedNetHandle = new NetHandle(0);
        }
    }
}
