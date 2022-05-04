using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    public Vector2 center;
    public float radius;

    public override float size { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override float area => throw new System.NotImplementedException();

    public Circle(Vector2 center, float radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public Circle(Body body)
    {
        this.center = body.position;
        this.radius = ((CircleShape)body.shape).radius;
    }

    public static bool Intersects(Circle circleA, Circle circleB)
    {
        Vector2 direction = circleA.center - circleB.center;
        float distance = direction.magnitude;
        float radius = (circleA.radius + circleB.radius);

        return (distance <= radius);
    }

    public override AABB GetAABB(Vector2 position)
    {
        return new AABB(position, Vector2.one * size);
    }
}
