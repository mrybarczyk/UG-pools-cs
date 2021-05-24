using System.Collections.Generic;
public static class Pula1
{
    private static List<PooledObject> _available = new List<PooledObject>();
    private static List<PooledObject> _inUse = new List<PooledObject>();

    public static PooledObject GetObject()
    {
        lock (_available)
        {
            if (_available.Count != 0)
            {
                PooledObject po = _available[0];
                _inUse.Add(po);
                _available.RemoveAt(0);
                return po;
            }
            else
            {
                PooledObject po = new Foo();
                _inUse.Add(po);
                return po;
            }

        }
    }

    public static void ReleaseObject(PooledObject po)
    {
        lock (_available)
        {
            _available.Add(po);
            _inUse.Remove(po);
        }
    }

}