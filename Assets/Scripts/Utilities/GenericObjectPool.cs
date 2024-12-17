using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.IsUsed);
                if(item != null)
                {
                    item.IsUsed = true;
                    return item.Item;
                }
            }

            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.IsUsed = true;
            pooledItems.Add(newItem);

            return newItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child class doesn't have implementation of CreateItem()");
        }

        public void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
            pooledItem.IsUsed = false;
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool IsUsed;
        }
    }
}