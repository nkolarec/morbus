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

    private float _timer;

    private void Start()
    {

        // Iz GameManager-a izvući listu svih aktivnih mjera i prema njima odrediti koliko dodatnih
        // zaraženih ljudi treba dodati, trebaju li osobe držati razmak i koliko, itd.

        while (_indexesOfInfectedPeople.Count <= LevelManager.LM.NumberOfInfectedPeopleInLevel)
        {
            int index = Random.Range(0, LevelManager.LM.NumberOfPeopleInLevel);
            if (_indexesOfInfectedPeople.Contains(index) == false)
                _indexesOfInfectedPeople.Add(index);
        }

    }

    private void Update()
    {

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
        person.GetComponentInChildren<CoronaController>().Initialize(_indexesOfInfectedPeople.Contains(_numberOfPeople) ? true : false);
        person.GetComponent<PersonController>().DistanceKeeper.GetComponent<SphereCollider>().radius = Constants.RADIUS_NO_DISTANCE;

        // Dodati dodatne uvjete za CoronaController (nosi li osoba masku, dezinficira li ruke), a za radius isto postaviti vrijednost u ovisnosti o
        // aktivnim mjerama.

        _numberOfPeople++;

        if (_numberOfPeople == LevelManager.LM.NumberOfPeopleInLevel)
            Destroy(this);

    }

}
