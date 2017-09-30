using System.Collections.Generic;


namespace OuroborosEngine.Interfaces
{
    public interface IEntityManager
    {
        ///////////////////////////////////////  ADD  /////////////////////////////////////
        IEntity AddEntity<T>(float xPos, float yPos, string idName) where T : IEntity, new();

        ///////////////////////////////////////  GETS  /////////////////////////////////////
        IEntity GetEntity<T>(IEntity entity) where T : IEntity;
        IEntity GetEntityByName(List<IEntity> entities, string name);
        IEntity GetEntityByNumber(List<IEntity> entities, int number);

        ///////////////////////////////////////  REMOVES  /////////////////////////////////////
        void RemoveEntity<T>(List<IEntity> entities, IEntity entity) where T : IEntity;
        void RemoveEntity(List<IEntity> entities, string name);
        void RemoveEntity(List<IEntity> entities, int number);

        ///////////////////////////////////////  LIST  /////////////////////////////////////
        List<IEntity> GetList();
    }
}
