using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TVCommonLib;

public class SplinesCreator : MonoBehaviour
{
    [SerializeField] GameObject splinesPrefab;
    [SerializeField] Transform splinesParent;

    [SerializeField] Vector3 splinesGap = Vector3.forward * 0.1f;

    //[SerializeField] Toggle 
    [SerializeField] InputField textSplinesNumber;
    [SerializeField] InputField textSplinesSamplingStep;
    [SerializeField] Button instantiateButton;

    List<Spline> splines = new List<Spline>();

    private void Start()
    {
        instantiateButton.onClick.AddListener(()=>
        {
            CreateSplines();
        });
    }

    void CreateSplines()
    {

        splinesParent.DestroyAllChildren();
        splines = new List<Spline>();

        int n = int.Parse(textSplinesNumber.text);
        float samplingStep = float.Parse(textSplinesSamplingStep.text);
        Vector3 lPos = Vector3.zero;
        for(int i=0; i<n; i++)
        {
            var go = Instantiate(splinesPrefab, splinesParent);
            go.transform.localPosition = lPos;

            var spline = go.GetComponent<Spline>();
            spline.SamplingStepSize = samplingStep;
            splines.Add(spline);

            lPos += splinesGap;
        }
    }
}
