using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public struct AABB
{
    public Vector2 center;
    public Vector2 size;
    public Vector2 extents { get => size * 0.5f; }

    public Vector2 min { get { return center - extents; } set { SetMinMax(value, max); } }
    public Vector2 max { get { return center + extents; } set { SetMinMax(min, value); } }

    public AABB(Vector2 center, Vector2 size)
    {
        this.center = center;
        this.size = size;
    }

    public bool Contains(AABB aabb)
    {
        return (aabb.max.x >= min.x && aabb.min.x <= max.x) &&
                        (aabb.max.y >= min.y && aabb.min.y <= max.y);
    }

    public bool Contains(Vector2 point)
    {
        return (point.x >= min.x && point.x <= max.x) &&
                            (point.y >= min.y && point.y <= max.y);
    }

    public void SetMinMax(Vector2 min, Vector2 max)
    {
        size = (max - min);
        center = min + extents;
    }

    public void Expand(Vector2 point)
    {
        SetMinMax(Vector2.Min(min, point), Vector2.Max(max, point));
    }

    public void Expand(AABB aabb)
    {
        //SetMinMax(Vector2.Min(min,aabb), Vector2.Max(max,));
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector2(min.x, min.y), new Vector2(max.x, min.y), color);
        Debug.DrawLine(new Vector2(min.x, max.y), new Vector2(max.x, max.y), color);
        Debug.DrawLine(new Vector2(min.x, min.y), new Vector2(min.x, max.y), color);
        Debug.DrawLine(new Vector2(max.x, min.y), new Vector2(max.x, max.y), color);
    }
}
