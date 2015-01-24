using UnityEngine;
using UnityEditor;
using System.Collections;

public class MultibleObjectsCustomPlanes : ScriptableWizard
{
    
    public Orientation orientation = Orientation.Horizontal;
    public AnchorPoint anchor = AnchorPoint.Center;
    public int widthSegments = 1;
    public int lengthSegments = 1;
    public float width = 1.0f;
    public float length = 1.0f;
    public bool addCollider = false;
    public bool createAtOrigin = true;
    public bool twoSided = false;
    public string optionalName;
    public int limit;
    private int x = 0;
    public int creationRange1;
    public int creationRange2;
    public Texture selectedTexture;
    public int heightLimit;
    public int objectsSelector;
    public int SpinStartValue;
    public int SpinEnd;
    GameObject obj;
    static Camera cam;
    static Camera lastUsedCam;
 
    public enum Orientation
    {
        Horizontal,
        Vertical
    }


     //tweak for wizard
    void Instantiate()
    {

        while (x < limit)
        {

            float xSpin = UnityEngine.Random.Range(SpinStartValue, SpinEnd);
            float ySpin = UnityEngine.Random.Range(SpinStartValue, SpinEnd);
            float zSpin = UnityEngine.Random.Range(SpinStartValue, SpinEnd);



            x++;
            if (objectsSelector == 0)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
                
            }
            if (objectsSelector == 1)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
              
            }
            if (objectsSelector == 2)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
                
            }
            if (objectsSelector == 3)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Plane);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
                
            }
            if (objectsSelector == 4)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Quad);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
                
            }
            if (objectsSelector == 5)
            {
                obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                obj.transform.position = new Vector3(UnityEngine.Random.Range(0, creationRange1), UnityEngine.Random.Range(0, heightLimit), UnityEngine.Random.Range(0, creationRange2));
                obj.renderer.sharedMaterial.mainTexture = selectedTexture;
                obj.transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);
                
            }




        }
    }

    void OnWizardUpdate()
    {
        widthSegments = Mathf.Clamp(widthSegments, 1, 254);
        lengthSegments = Mathf.Clamp(lengthSegments, 1, 254);
    }
    public enum AnchorPoint
    {
        TopLeft,
        TopHalf,
        TopRight,
        RightHalf,
        BottomRight,
        BottomHalf,
        BottomLeft,
        LeftHalf,
        Center
    }

    void OnWizardCreate()
    {
       
        GameObject obj = new GameObject();
        Instantiate();
        if (!string.IsNullOrEmpty(optionalName))
            obj.name = optionalName;
       

        if (!createAtOrigin && cam)
            obj.transform.position = cam.transform.position + cam.transform.forward * 5.0f;
       

        Vector2 anchorOffset;
        string anchorId;
        switch (anchor)
        {
            case AnchorPoint.TopLeft:
                anchorOffset = new Vector2(-width / 2.0f, length / 2.0f);
                anchorId = "T";
                break;
            case AnchorPoint.TopHalf:
                anchorOffset = new Vector2(0.0f, length / 2.0f);
                anchorId = "TH";
                break;
            case AnchorPoint.TopRight:
                anchorOffset = new Vector2(width / 2.0f, length / 2.0f);
                anchorId = "TR";
                break;
            case AnchorPoint.RightHalf:
                anchorOffset = new Vector2(width / 2.0f, 0.0f);
                anchorId = "RH";
                break;
            case AnchorPoint.BottomRight:
                anchorOffset = new Vector2(width / 2.0f, -length / 2.0f);
                anchorId = "BR";
                break;
            case AnchorPoint.BottomHalf:
                anchorOffset = new Vector2(0.0f, -length / 2.0f);
                anchorId = "BH";
                break;
            case AnchorPoint.BottomLeft:
                anchorOffset = new Vector2(-width / 2.0f, -length / 2.0f);
                anchorId = "BL";
                break;
            case AnchorPoint.LeftHalf:
                anchorOffset = new Vector2(-width / 2.0f, 0.0f);
                anchorId = "LH";
                break;
            case AnchorPoint.Center:
            default:
                anchorOffset = Vector2.zero;
                anchorId = "C";
                break;
        }
    

    
        
    

     MeshFilter meshFilter = (MeshFilter)obj.AddComponent(typeof(MeshFilter));
        obj.AddComponent(typeof(MeshRenderer));

        string planeAssetName = obj.name + widthSegments + "x" + lengthSegments + "W" + width + "L" + length + (orientation == Orientation.Horizontal ? "H" : "V") + anchorId + ".asset";
        Mesh m = (Mesh)AssetDatabase.LoadAssetAtPath("Assets/Editor/" + planeAssetName, typeof(Mesh));

        if (m == null)
        {
            m = new Mesh();
            m.name = obj.name;

            int hCount2 = widthSegments + 1;
            int vCount2 = lengthSegments + 1;
            int numTriangles = widthSegments * lengthSegments * 6;
            if (twoSided)
            {
                numTriangles *= 2;
            }
            int numVertices = hCount2 * vCount2;

            Vector3[] vertices = new Vector3[numVertices];
            Vector2[] uvs = new Vector2[numVertices];
            int[] triangles = new int[numTriangles];

            int index = 0;
            float uvFactorX = 1.0f / widthSegments;
            float uvFactorY = 1.0f / lengthSegments;
            float scaleX = width / widthSegments;
            float scaleY = length / lengthSegments;
            for (float y = 0.0f; y < vCount2; y++)
            {
                for (float x = 0.0f; x < hCount2; x++)
                {
                    if (orientation == Orientation.Horizontal)
                    {
                        vertices[index] = new Vector3(x * scaleX - width / 2f - anchorOffset.x, 0.0f, y * scaleY - length / 2f - anchorOffset.y);
                    }
                    else
                    {
                        vertices[index] = new Vector3(x * scaleX - width / 2f - anchorOffset.x, y * scaleY - length / 2f - anchorOffset.y, 0.0f);
                    }
                    uvs[index++] = new Vector2(x * uvFactorX, y * uvFactorY);
                }
            }

            index = 0;
            for (int y = 0; y < lengthSegments; y++)
            {
                for (int x = 0; x < widthSegments; x++)
                {
                    triangles[index] = (y * hCount2) + x;
                    triangles[index + 1] = ((y + 1) * hCount2) + x;
                    triangles[index + 2] = (y * hCount2) + x + 1;

                    triangles[index + 3] = ((y + 1) * hCount2) + x;
                    triangles[index + 4] = ((y + 1) * hCount2) + x + 1;
                    triangles[index + 5] = (y * hCount2) + x + 1;
                    index += 6;
                }
                if (twoSided)
                {
                    // Same tri vertices with order reversed, so normals point in the opposite direction
                    for (int x = 0; x < widthSegments; x++)
                    {
                        triangles[index] = (y * hCount2) + x;
                        triangles[index + 1] = (y * hCount2) + x + 1;
                        triangles[index + 2] = ((y + 1) * hCount2) + x;

                        triangles[index + 3] = ((y + 1) * hCount2) + x;
                        triangles[index + 4] = (y * hCount2) + x + 1;
                        triangles[index + 5] = ((y + 1) * hCount2) + x + 1;
                        index += 6;
                    }
                }
            }

            m.vertices = vertices;
            m.uv = uvs;
            m.triangles = triangles;
            m.RecalculateNormals();

            AssetDatabase.CreateAsset(m, "Assets/Editor/" + planeAssetName);
            AssetDatabase.SaveAssets();
        }

        meshFilter.sharedMesh = m;
        m.RecalculateBounds();

        if (addCollider)
            obj.AddComponent(typeof(BoxCollider));

        Selection.activeObject = obj;
    }


   

    [MenuItem("GameObject/Create Other/Create Multible Objects")]
    static void CreateWizard()
    {
        cam = Camera.current;
        // Hack because camera.current doesn't return editor camera if scene view doesn't have focus
        if (!cam)
            cam = lastUsedCam;
        else
            lastUsedCam = cam;
        ScriptableWizard.DisplayWizard("Create Multible Objects", typeof(MultibleObjectsCustomPlanes));
    }

}
