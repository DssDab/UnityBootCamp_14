using JetBrains.Annotations;
using UnityEngine;

public enum Projection
{
    Orthographic,
    Perspective
}
public enum FieldOfViewAxis
{
    Horizontal,
    Vertical
}

public class Sample2 : MonoBehaviour
{
    public Projection pro;
    public FieldOfViewAxis fovA;
    public float Fov;
    public float Near;
    public float Far;
    public bool PhysicalCamera;
}
