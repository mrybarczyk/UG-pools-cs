using System;
public abstract class PooledObject
{
    private int points = new Random().Next(101);
    public abstract PooledObject Clone();
    public int Points
    {
        get { return points; }
    }

    public string TempData { get; set; }
}

public class Foo : PooledObject
{
    public override PooledObject Clone()
    {
        return (PooledObject)this.MemberwiseClone();
    }
}