using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all of the models available for the user
/// </summary>
public class ModelManager : MonoBehaviour
{
    //List of all possible models for user to select
    [SerializeField] List<GameObject> modelList;

    List<string> modelSpawnNames = new List<string>();
    List<ModelController> _modelControllers = new List<ModelController>();
    GameObject currentARModel;
    List<Vector3> modelSpawnLocations = new List<Vector3>();
    List<Vector3> modelSpawnRotations = new List<Vector3>();
    Vector3 currentARModelSpawnPosition;
    Vector3 currentARModelSpawnRotation;

    float MeterToFtConversion = 0.3048f;

    private void Start()
    {
        foreach (GameObject go in modelList)
        {
            modelSpawnLocations.Add(go.transform.localPosition);
            modelSpawnRotations.Add(go.transform.localEulerAngles);
            modelSpawnNames.Add(go.name);
            _modelControllers.Add(go.GetComponent<ModelController>());
        }
        

        currentARModel = modelList[0];
        currentARModelSpawnPosition = modelSpawnLocations[0];
        currentARModelSpawnRotation = modelSpawnRotations[0];
    }

    public void SelectARModel(string modelName)
    {
        currentARModel.SetActive(false);
        currentARModel.transform.localPosition = currentARModelSpawnPosition;
        currentARModel.transform.localEulerAngles = currentARModelSpawnRotation;
        for (int i = 0; i < modelSpawnNames.Count; i++)
        {
            if (modelName == modelSpawnNames[i])
            {
                currentARModelSpawnPosition = modelSpawnLocations[i];
                currentARModelSpawnRotation = modelSpawnRotations[i];
                modelList[i].SetActive(true);
                currentARModel = modelList[i];
            }
        }
    }
    public void ChangeModelColor(Material material)
    {
        foreach (ModelController controller in _modelControllers)
        {
            controller.ChangeColor(material);
        }
    }


}
