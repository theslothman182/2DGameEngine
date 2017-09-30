using System.Collections.Generic;

namespace OuroborosEngine.Interfaces
{
    public interface ICollisionManager
    {
        ///////////////////////////////////////  COLLISION HANDLING  /////////////////////////////////////
        // no longer defined within here, because the method is static
        //void CollisionType(ICollidable item1, ICollidable item2, string collisionType, bool physics);

        ///////////////////////////////////////  COLLISION LIST  /////////////////////////////////////
        List<ICollidable> GetCollidableList(List<IEntity> entities);
    }
}
