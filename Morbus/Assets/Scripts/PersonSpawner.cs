using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{

    public GameObject PersonPrefab;
    public GameObject PersonParent;

    [Header("Spawn Area")]

    public Rect SpawnArea;
    public int SpawnAreaHeight;

    [Header("Spawn Time")]

    public Vector2 SpawnTimeInterval;

    private List<int> _indexesOfInfectedPeople = new List<int>();
    private int _numberOfPeople;
    private int _totalNumberOfPeople;

    private bool _distance;
    private bool _mask;
    private bool _maskRandomize;
    private float _percentage;

    private float _distanceRadius;
    private float _spreadRadius;

    private float _timer;

    private bool _spawn = true;

    private void Start()
    {

        _distance = false;
        _mask = false;
        _maskRandomize = false;
        _percentage = 0.5f;

        _totalNumberOfPeople = LevelManager.LM.NumberOfPeopleInLevel;

        _distanceRadius = Constants.RADIUS_NO_DISTANCE;
        _spreadRadius = Constants.RADIUS_CORONA_NO_MASK;

        List<int> activeMeasuresIndex = GameManager.GM.ActiveMeasures;
        List<Measure> allMeasures = Measure.GetAllMeasuresInAList();

        foreach (Measure measure in allMeasures)
        {
            if (activeMeasuresIndex.Contains(measure.Identifier))
            {
                _totalNumberOfPeople += measure.PeopleNumber;
                _percentage += measure.InfectionPercentage;

                if (Mathf.Abs(measure.Radius - 1) <= 0.05f && _distanceRadius < Constants.RADIUS_DISTANCE_1M)
                {
                    _distance = true;
                    _distanceRadius = Constants.RADIUS_DISTANCE_1M;
                }

                if (Mathf.Abs(measure.Radius - 2) <= 0.05f && _distanceRadius < Constants.RADIUS_DISTANCE_2M)
                {
                    _distance = true;
                    _distanceRadius = Constants.RADIUS_DISTANCE_2M;
                }

                if (Mathf.Abs(measure.Radius - 3) <= 0.05f)
                {
                    _distance = true;
                    _distanceRadius = Constants.RADIUS_DISTANCE_3M;
                }

                if (measure.Mask > 0 && _mask == false)
                {
                    if (measure.Mask == 1)
                    {
                        _mask = false;
                        _maskRandomize = true;
                    }
                    else
                    {
                        _mask = true;
                        _maskRandomize = false;
                        _spreadRadius = Constants.RADIUS_CORONA_MASK;
                    }
                }

            }

        }

        FindObjectOfType<LevelUserInterfaceManager>().UpdateTotal(_totalNumberOfPeople);
        LevelManager.LM.UpdateNumberOfPeople(_totalNumberOfPeople);

        // Iz GameManager-a izvući listu svih aktivnih mjera i prema njima odrediti koliko dodatnih
        // zaraženih ljudi treba dodati, trebaju li osobe držati razmak i koliko, itd. Prema tome
        // mijenjati vrijednosti.

        while (_indexesOfInfectedPeople.Count < LevelManager.LM.NumberOfInfectedPeopleInLevel)
        {
            int index = Random.Range(0, LevelManager.LM.NumberOfPeopleInLevel);
            if (_indexesOfInfectedPeople.Contains(index) == false)
                _indexesOfInfectedPeople.Add(index);
        }

    }

    private void Update()
    {

        if (_spawn == false)
            return;

        _timer -= Time.deltaTime;

        if (_timer > 0)
            return;

        _timer = Random.Range(SpawnTimeInterval.x, SpawnTimeInterval.y);
        Spawn();

    }

    private void Spawn()
    {

        Vector3 position = new Vector3(Random.Range(SpawnArea.x, SpawnArea.x + SpawnArea.width), SpawnAreaHeight, Random.Range(SpawnArea.y, SpawnArea.y + SpawnArea.height));
        GameObject person = Instantiate(PersonPrefab, position, Quaternion.identity, PersonParent.transform);

        bool mask = _mask;
        float spreadRadius = _spreadRadius;

        if (_maskRandomize)
        {
            mask = (Random.Range(0.0f, 1.0f) < 0.5f) ? true : false;
            spreadRadius = (mask) ? Constants.RADIUS_CORONA_MASK : Constants.RADIUS_CORONA_NO_MASK;
        }

        person.GetComponentInChildren<CoronaController>().Initialize(_indexesOfInfectedPeople.Contains(_numberOfPeople) ? true : false, _percentage, _distance, mask);
        person.GetComponentInChildren<CoronaController>().transform.localScale = new Vector3(spreadRadius, 0.005f, spreadRadius);

        person.GetComponent<PersonController>().DistanceKeeper.GetComponent<SphereCollider>().radius = _distanceRadius;

        // Dodati dodatne uvjete za CoronaController (nosi li osoba masku, dezinficira li ruke), a za radius isto postaviti vrijednost u ovisnosti o
        // aktivnim mjerama.

        _numberOfPeople++;

        if (_numberOfPeople == _totalNumberOfPeople)
            _spawn = false;

    }

}
