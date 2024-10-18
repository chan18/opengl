

### Camera position
``` C#

Vector3 Position = new Vector3(0.0f,0.0f,3.0f);



```


# camera direction
```C#

Vector3 cameraTarget = Vector3.Zero;

Vector3 cameraDirection = Vector3.Normalize(CameraPos - cameraTarget);

```


# Right azis

``` C#
Vector3 up = Vector3.Unity;
Vector3 cameraRight = vector3.Normalize(Vector3.Cross(up,cameraDirection));

```


# Look Up

``` C#

Matrix4 view = Matrix4.LookUp(
    new Vector3(0.0f,0.0f,3.0f),
    new Vector3(0.0f,0.0f,0.0f),
    new Vector3(0.0f,1.0f,3.0f),
);

```

# walk around

``` C#
float speed = 1.5f;

Vector3 position = new Vector3(0.0f,0.0f, 3.0f);
Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);

view = Matrix4.LookAt(position, position + front, up);
```




