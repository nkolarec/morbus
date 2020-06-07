using System;
using System.Collections.Generic;

public class Measure
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Pros { get; set; }
    public string Cons { get; set; }
    public float InfectionPercentage { get; set; }
    public float Radius { get; set; }
    public float Happiness { get; set; }
    public int PeopleNumber { get; set; }

    public static Dictionary<int, List<Measure>> measures = new Dictionary<int, List<Measure>>()
    {
        {
            1, new List<Measure>()
            {
                new Measure {
                    Name="Social Distancing",
                    Description="People must be 1m apart.",
                    Pros="Radius of contact will be expanded to 1m.",
                    Cons="There are no consequences.",
                    InfectionPercentage=0f,
                    Radius=1f,
                    Happiness=0f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Social Distancing",
                    Description="People must be 2m apart.",
                    Pros="Radius of contact will be expanded to 2m.",
                    Cons="People's happiness will drop by 5%",
                    InfectionPercentage=0f,
                    Radius=2f,
                    Happiness=-0.05f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Social Distancing",
                    Description="People must be 3m apart.",
                    Pros="Radius of contact will be expanded to 3m.",
                    Cons="People's happiness will drop by 10%",
                    InfectionPercentage=0f,
                    Radius=3f,
                    Happiness=-0.1f,
                    PeopleNumber=0
                }
            }
        },
        {
            2, new List<Measure>()
            {
                new Measure {
                    Name="Masks",
                    Description="People are RECOMMENDED to wear masks.",
                    Pros="Infection will be reduced by 5% and radius will be expanded to 1m.",
                    Cons="People's happiness will drop by 10%.",
                    InfectionPercentage=-0.05f,
                    Radius=1f,
                    Happiness=-0.1f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Masks",
                    Description="People are OBLIGED to wear masks.",
                    Pros="Infection will be reduced by 10% and radius will be expanded to 2m.",
                    Cons="People's happiness will drop by 20%.",
                    InfectionPercentage=-0.1f,
                    Radius=2f,
                    Happiness=-0.2f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Fully equipped",
                    Description="People are OBLIGED to wear masks and gloves.",
                    Pros="Infection will be reduced by 20% and radius will be expanded to 3m.",
                    Cons="People's appiness will drop by 30%.",
                    InfectionPercentage=-0.2f,
                    Radius=3f,
                    Happiness=-0.3f,
                    PeopleNumber=0
                }
            }
        },
        {
            3,  new List<Measure>()
            {
                new Measure {
                    Name="Wash your hands!",
                    Description="People are RECOMMENDED to wash hands.",
                    Pros="Infection will be reduced by 5%",
                    Cons="People will not be social distancing.",
                    InfectionPercentage=-0.05f,
                    Radius=0f,
                    Happiness=0f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Wash your hands!",
                    Description="People are OBLIGED to wash hands.",
                    Pros="Infection will be reduced by 10%",
                    Cons="People will not be social distancing and their happiness will drop by 5%.",
                    InfectionPercentage=-0.1f,
                    Radius=0f,
                    Happiness=-0.05f,
                    PeopleNumber=0
                },
                new Measure {
                    Name="Sanitize",
                    Description="People are OBLIGED to wash hands and use sanitary products.",
                    Pros="Infection will be reduced by 20%",
                    Cons="People will not be social distancing and their happiness will drop by 10%.",
                    InfectionPercentage=-0.2f,
                    Radius=0f,
                    Happiness=-0.1f,
                    PeopleNumber=0
                }
            }
 
        },
        {
            4,  new List<Measure>() 
            {
                new Measure {
                    Name="#stayathome",
                    Description="People are RECOMMENDED to stay at home.",
                    Pros="Infection will be reduced by 5% and 3 people less will come.",
                    Cons="Happiness will drop by 10%.",
                    InfectionPercentage=-0.05f,
                    Radius=0f,
                    Happiness=-0.15f,
                    PeopleNumber=-3
               },
                new Measure {
                    Name="#stayathome",
                    Description="People are OBLIGED to stay at home.",
                    Pros="Infection will be reduced by 10% and 5 people less will come.",
                    Cons="Happiness will drop by 30%.",
                    InfectionPercentage=0.1f,
                    Radius=0f,
                    Happiness=-0.3f,
                    PeopleNumber=-5
               },
                new Measure {
                    Name="Isolation",
                    Description="People must completely isolate at home if they are infected.",
                    Pros="Infection will be reduced by 25% and 7 people less will come.",
                    Cons="Happiness will drop by 40%.",
                    InfectionPercentage=-0.25f,
                    Radius=0f,
                    Happiness=-0.4f,
                    PeopleNumber=-7
                }
            }
        },
        {
           5,  new List<Measure>()
           {
               new Measure {
                    Name="Clean it up!",
                    Description="Workers have to clean their workspace after every workday.",
                    Pros="Infection will be reduced by 5%.",
                    Cons="Two more people will come.",
                    InfectionPercentage=-0.05f,
                    Radius=0f,
                    Happiness=0f,
                    PeopleNumber=2
               }, 
               new Measure {
                    Name="Clean it up!",
                    Description="Workers have to to clean their workspace after every product usage.",
                    Pros="Infection will be reduced by 10%.",
                    Cons="3 more people will come.",
                    InfectionPercentage=-0.1f,
                    Radius=0f,
                    Happiness=0f,
                    PeopleNumber=3
               },
               new Measure {
                    Name="Cristal clear",
                    Description="Workers must completely sanitize their workspace and products.",
                    Pros="Infection will be reduced by 10%.",
                    Cons="5 more people will come.",
                    InfectionPercentage=-0.05f,
                    Radius=0f,
                    Happiness=0f,
                    PeopleNumber=5
               }
           }
        }
    };
    public static List<Measure> GetActiveMeasures()
    {
        HashSet<int> types = new HashSet<int>();
        var activeMeasures = new List<Measure>();
        var rand = new Random();
        var i = 3;
        while (i > 0)
        {
            var chosenNumber = rand.Next(1, 5);
            if ((types.Count == 0 || !types.Contains(chosenNumber)) && measures.ContainsKey(chosenNumber))
            {
                activeMeasures.Add(measures[chosenNumber][0]);
                measures[chosenNumber].RemoveAt(0);
                if (measures[chosenNumber].Count == 0)
                {
                    measures.Remove(chosenNumber);
                }
            }
        }
        return activeMeasures;
    }
}

