using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared.Math;
using SyBozz.GrandTheftMultiplayer.Server.ColShapeExample.Managers;

namespace SyBozz.GrandTheftMultiplayer.Server.ColShapeExample.CAPI
{
    public static class Capi
    {
        public static Cylinder2DColShape CreateCylinder2DColShape(Vector3 position, float range)
        {
            var shape = new Cylinder2DColShape(position, range);

            // Since we use shared, the colshape is not deleted on resource restart or stop.
            // To delete the colshape use API.deleteColShape().
            API.shared.registerCustomColShape(shape);

            return shape;
        }
    }
}
