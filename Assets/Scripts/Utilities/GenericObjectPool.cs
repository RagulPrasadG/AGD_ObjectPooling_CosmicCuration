using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : class
{
    private List<PooledObject<T>> pooledItems= new List<PooledObject<T>>();

    protected T GetObject()
    {
        if (pooledItems.Count > 0)
        {
            PooledObject<T> item = pooledItems.Find(obj => !obj.isUsed);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreatePooledItem();

    }

    public void ReturnItemToPool(T item)
    {
        PooledObject<T> pooledObject = pooledItems.Find(i => i.Item.Equals(item));
        pooledObject.isUsed = false;
    }


    private T CreatePooledItem()
    {
        PooledObject<T> pooledItem = new PooledObject<T>();
        pooledItem.Item = CreateItem();
        pooledItem.isUsed = true;
        pooledItems.Add(pooledItem);
        return pooledItem.Item;
    }

    protected virtual T CreateItem()
    {
        throw new NotImplementedException("Child class must implement CreateItem() method");
    }

    public class PooledObject<T>
        {
             public T Item;
             public bool isUsed;
        }


}
