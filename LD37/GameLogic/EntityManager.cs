using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD37.Entities;

namespace LD37.GameLogic
{
    class EntityManager
    {
        #region Singleton logic

        private static readonly EntityManager instance = new EntityManager();

        static EntityManager()
        {

        }

        public static EntityManager Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Variables
        private List<AbstractEntity>    abstractEntityLists;
        private List<GameEntity>        gameEntityLists;
        private List<Item>              itemLists;
        #endregion

        #region Properties
        public  List<AbstractEntity>    AbstractEntityLists { get { return abstractEntityLists; }   set { abstractEntityLists = value; }    }
        public  List<GameEntity>        GameEntityLists     { get { return gameEntityLists; }       set { gameEntityLists = value; }        }
        public  List<Item>              ItemLists           { get { return itemLists; }             set { itemLists = value; }              }
        #endregion

        #region Constructors
        private EntityManager()
        {
            abstractEntityLists = new List<AbstractEntity>();
            gameEntityLists     = new List<GameEntity>();
            itemLists           = new List<Item>();
        }
        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion
    }
}
