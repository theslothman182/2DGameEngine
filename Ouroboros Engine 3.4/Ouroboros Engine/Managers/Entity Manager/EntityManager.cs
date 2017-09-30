using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.EntityManager
{
    public class EntityManager : IEntityManager
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: a list of IEntity objects that is to be returned
        private List<IEntity> entityList; 

        // CREATE: a static int that that will give entities an ID number
        private static int idNumber;


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        public EntityManager()
        {
            // INSTANTIATE: the ID number
            idNumber = 1; 
            // INSTANTIATE: the IEntity list
            entityList = new List<IEntity>();
        }


        ///////////////////////////////////////  ADD  /////////////////////////////////////


        /// <summary>METHOD: for taking in a request of an object of type IEntity and returning it, giving it both position and a unique ID</summary>
        /// <typeparam name="T">Type of IEntity passed in</typeparam>
        /// <param name="xPos">Position for x axis</param>
        /// <param name="yPos">Position for y axis</param>
        /// <param name="idName">The unique name given to an IEntity</param>
        /// <returns>A newly created IEntity</returns>
        public IEntity AddEntity<T>(float xPos, float yPos, string idName) where T : IEntity, new()// the object, T, must be of type IEntity and create a new instance of that object
        {
            // CREATE: an IEntity object and INSTANTIATE it as the type defined as T
            IEntity entity = new T();

            // IF: the unique ID name has not been set
            if (idName == null)
            {
                // THEN: set the entities ID name using it's texture name and ID number, and give it an ID number
                entity.setID("NA" + idNumber, idNumber); // entity.setID(entity.Image + idNumber, idNumber);
            }
            // ELSE:
            else
            {
                //THEN: set the entities ID name using idName, and give it an ID number
                entity.setID(idName, idNumber);
            }

            // SET: the position of the entity using xPos, and yPos
            entity.Position = new Vector2(xPos, yPos);

            // INCREMENT: the idNumber by one, so that no two entites can have the same ID number
            idNumber++;
            // RETURN: the entity that you have requested
            return entity;
        }


        ///////////////////////////////////////  GETS  /////////////////////////////////////


        /// <summary>METHOD: for finding a certain IEntity object, can be used to find objects of type within a list, using the entity</summary>
        /// <typeparam name="T">Type of IEntity passed in</typeparam>
        /// <param name="entity">The entity that you want to be returned</param>
        /// <returns>The IEntity you wanted returned</returns>
        public IEntity GetEntity<T>(IEntity entity) where T : IEntity
        {
            // RETURN: the entity that you requested
            return entity;
        }

        /// <summary>METHOD: for retrieving an IEntity from a list, using its unique ID name</summary>
        /// <param name="entities">The list of entities containing the IEntity you wish to get</param>
        /// <param name="name">The unique ID name to the entity you want to get</param>
        /// <returns>The IEntity you wanted returned</returns>
        public IEntity GetEntityByName(List<IEntity> entities, string name)
        {
            // CREATE: an empty IEntity object
            IEntity entity = null;

            // CREATE: an array of IEntity objects, adding the entity that you want to get by using its unique ID name
            IEntity[] entityArray = entities.Where(x => x.IdName == name).ToArray();
            // IF: the array of IEntity's IS NOT empty
            if (entityArray.Count() != 0)
            {
                // SET: entity to equal the first member of the array
                entity = entityArray[0];
            }

            // RETURN: the entity that yu have requested
            return entity;
        }

        /// <summary>METHOD: for retrieving an IEntity from a list, using its unique ID number</summary>
        /// <param name="entities">The list of entities containing the IEntity you wish to get</param>
        /// <param name="number">The unique ID number to the entity you want to get</param>
        /// <returns>The IEntity you wanted returned</returns>
        public IEntity GetEntityByNumber(List<IEntity> entities, int number)
        {
            // CREATE: an empty IEntity object
            IEntity entity = null;

            // CREATE: an array of IEntity objects, adding the entity that you want to get by using its unique ID number
            IEntity[] entityArray = entities.Where(x => x.IdNumber == number).ToArray();
            // IF: the array of IEntity's IS NOT empty
            if (entityArray.Count() != 0)
            {
                // SET: entity to equal the first member of the array
                entity = entityArray[0];
            }

            // RETURN: the entity that yu have requested
            return entity;
        }


        ///////////////////////////////////////  REMOVES  /////////////////////////////////////


        /// <summary>METHOD: for removing a specific IEntity from a list of entities</summary>
        /// <typeparam name="T">Type of IEntity passed in</typeparam>
        /// <param name="entities">The list of entities you wish to remove from</param>
        /// <param name="entity">The entity that you want to be removed</param>
        public void RemoveEntity<T>(List<IEntity> entities, IEntity entity) where T : IEntity
        {
            // REMOVE: the entity you have requested from the list of entities
            entities.Remove(entity);
        }

        /// <summary>METHOD: for removing an IEntity from a list, using its unique ID same</summary>
        /// <param name="entities">The list of entities containing the IEntity you wish to remove</param>
        /// <param name="name">The unique ID name to the entity you want to remove</param>
        public void RemoveEntity(List<IEntity> entities, string name)
        {
            // CREATE: an empty IEntity object
            IEntity entity = null;

            // CREATE: an array of IEntity objects, adding the entity that you want to get by using its unique ID name
            IEntity[] entityArray = entities.Where(x => x.IdName == name).ToArray();
            // IF: the array of IEntity's IS NOT empty
            if (entityArray.Count() != 0)
            {
                // SET: entity to equal the first member of the array
                entity = entityArray[0];
            }

            // REMOVE: the entity you have requested from the list of entities
            entities.Remove(entity);
        }

        /// <summary>METHOD: for removing an IEntity from a list, using its unique ID number</summary>
        /// <param name="entities">The list of entities containing the IEntity you wish to remove</param>
        /// <param name="number">The unique ID number to the entity you want to remove</param>
        public void RemoveEntity(List<IEntity> entities, int number)
        {
            // CREATE: an empty IEntity object
            IEntity entity = null;

            // CREATE: an array of IEntity objects, adding the entity that you want to get by using its unique ID number
            IEntity[] entityArray = entities.Where(x => x.IdNumber == number).ToArray();
            // IF: the array of IEntity's IS NOT empty
            if (entityArray.Count() != 0)
            {
                // SET: entity to equal the first member of the array
                entity = entityArray[0];
            }

            // REMOVE: the entity you have requested from the list of entities
            entities.Remove(entity);
        }


        ///////////////////////////////////////  LIST  /////////////////////////////////////


        /// <summary>METHOD: for getting a List of IEntity's that can be used to set one in the game scene</summary>
        /// <returns>A blank List of IEntity's</returns>
        public List<IEntity> GetList()
        {
            // RETURN: the a blank list of IEntity's
            return entityList;
        }
    }
}
