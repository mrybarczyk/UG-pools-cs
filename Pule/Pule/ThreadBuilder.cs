using System.Collections.Generic;
using System.Threading;
using System.Linq;


public interface IBuilder
{
    int number { get; set; }
    List<PooledObject> values { get; set; }
    int ReturnValues(string nazwa, int i);
}
public class ThreadBuilder : IBuilder
{
    public int number { get; set; }
    public List<PooledObject> values { get; set; }
    public int ReturnValues(string nazwa, int i)
    {
        number = i;
        List<PooledObject> values = new List<PooledObject>();
        PooledObject value = null;
        Thread t1 = new Thread(() => {
            switch (nazwa)
            {
                case "Pula1":
                    for (int n = 0; n < i; n++)
                    {
                        value = Pula1.GetObject();
                        values.Add(value);
                    }
                    break;
                case "Pula2":
                    for (int n = 0; n < i; n++)
                    {
                        value = Pula2.GetObject();
                        values.Add(value);
                    }
                    break;
                case "Pula3":
                    for (int n = 0; n < i; n++)
                    {
                        value = Pula3.GetObject();
                        values.Add(value);
                    }
                    break;
                default:
                    break;
            }

        });
        t1.Start();
        t1.Join();
        switch (nazwa)
        {
            case "Pula1":
                for (int n = 0; n < i; n++)
                {
                    Pula1.ReleaseObject(values.ElementAt(n));
                }
                break;
            case "Pula2":
                for (int n = 0; n < i; n++)
                {
                    Pula2.ReleaseObject(values.ElementAt(n));
                }
                break;
            case "Pula3":
                for (int n = 0; n < i; n++)
                {
                    Pula3.ReleaseObject(values.ElementAt(n));
                }
                break;
            default:
                break;
        }
        var res = values.Sum(v => v.Points);
        return res;

    }
}